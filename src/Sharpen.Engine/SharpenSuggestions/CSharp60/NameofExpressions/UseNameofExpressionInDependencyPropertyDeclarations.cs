using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp60.NameofExpressions
{
    internal sealed class UseNameofExpressionInDependencyPropertyDeclarations : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private static readonly SyntaxKind[] RequiredDependencyPropertyFieldModifiers = { SyntaxKind.ReadOnlyKeyword, SyntaxKind.StaticKeyword };

        private UseNameofExpressionInDependencyPropertyDeclarations() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp60;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.NameofExpressions.Instance;

        public string FriendlyName { get; } = "Use nameof expression in dependency property declarations";

        public static readonly UseNameofExpressionInDependencyPropertyDeclarations Instance = new UseNameofExpressionInDependencyPropertyDeclarations();

        private static string GetRegisterMethodDisplayText(SyntaxNode syntaxNode) // SyntaxNode is actually ArgumentSyntax.
        {
            return syntaxNode.FirstAncestorOrSelf<InvocationExpressionSyntax>().ToString();
        }

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<FieldDeclarationSyntax>()
                .Select(GetPropertyNameArgumentsIfFieldDeclarationIsDependencyPropertyDeclaration)
                .Where(propertyNames => propertyNames.Length > 0)
                .SelectMany(propertyNames => propertyNames)
                .Select(propertyName => new AnalysisResult
                (
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    propertyName.GetFirstToken(),
                    propertyName,
                    GetRegisterMethodDisplayText
                ));
            
            ArgumentSyntax[] GetPropertyNameArgumentsIfFieldDeclarationIsDependencyPropertyDeclaration(FieldDeclarationSyntax fieldDeclaration)
            {
                // Let's first do fast checks that quickly and cheaply eliminate obvious non-candidates.
                // We want to use the semantic model only if we are sure that we have candidates that are
                // very likely field declarations that we are looking for.

                if (!(RequiredDependencyPropertyFieldModifiers.All(modifier =>
                    fieldDeclaration.Modifiers.Select(token => token.Kind()).Contains(modifier)) &&
                    fieldDeclaration.Declaration.Type.GetLastToken().ValueText == "DependencyProperty"))
                    return Array.Empty<ArgumentSyntax>();

                return fieldDeclaration
                    .Declaration
                    .Variables
                    .Where(variableDeclaration => 
                        variableDeclaration.Identifier.ValueText.EndsWith("Property", StringComparison.Ordinal) &&
                        variableDeclaration.Initializer != null &&
                        variableDeclaration.Initializer.Value.IsKind(SyntaxKind.InvocationExpression))
                    .Select(variableDeclaration => new
                    {
                        FieldName = variableDeclaration.Identifier.ValueText,
                        Invocation = (InvocationExpressionSyntax)variableDeclaration.Initializer.Value
                    })
                    .Where(fieldNameAndInvocation => 
                        fieldNameAndInvocation.Invocation.Expression.GetLastToken().ValueText == "Register" &&
                        fieldNameAndInvocation.Invocation.ArgumentList.Arguments.Count > 0 &&
                        fieldNameAndInvocation.Invocation.ArgumentList.Arguments[0].Expression.IsKind(SyntaxKind.StringLiteralExpression) &&
                        fieldNameAndInvocation.Invocation.ArgumentList.Arguments[0].Expression.GetLastToken().ValueText is string propertyName &&
                        fieldNameAndInvocation.FieldName.StartsWith(propertyName, StringComparison.Ordinal) &&
                        fieldNameAndInvocation.FieldName.Length == propertyName.Length + "Property".Length && // Check that they are equal without creating temporary strings.
                        InstancePropertyWithPropertyNameExists(propertyName, fieldNameAndInvocation.Invocation)
                        &&
                        // If we reach this point it means that we have a field declaration that in a real case most likely
                        // 99.9999 % percent sure represents a dependency property declaration. Cool :-)
                        // Still, we have to check for those 0.00001% since we could have a situation sketched
                        // in the smoke tests, where the Register method or the DependencyProperty class are not the "real" one.
                        // I am asking myself now if this level of paranoia is really appropriate considering the cost of
                        // this additional analysis. Hmmm.
                        // TODO-THINK: We can provide an analysis option like "Use optimistic analysis" that would skip the below test.
                        semanticModel.GetSymbolInfo(fieldNameAndInvocation.Invocation).Symbol is IMethodSymbol method &&
                        method.ContainingType?.Name == "DependencyProperty" &&
                        (method.ContainingType.ContainingType == null || method.ContainingType.ContainingType.IsNamespace) && // It must not be nested in another type.
                        method.ContainingType.ContainingNamespace.FullNameIsEqualTo("System.Windows")
                        // To be really sure, we should check here that the DependencyProperty type is
                        // really the System.Windows.DependencyProperty. And this check would add a whole
                        // bunch of super crazy paranoia on already paranoid check ;-)
                        // Basically, the only possibility for this check to fail would be if someone
                        // introduces it's own type named DependencyProperty that implicitly converts
                        // the System.Windows.DependencyProperty to itself. This is demonstrated in
                        // smoke tests but it is completely crazy. Who would ever do that?
                        // And since this check would be quite complex to implement, we will simply skip it.
                    )
                    .Select(fieldNameAndInvocation => fieldNameAndInvocation.Invocation.ArgumentList.Arguments[0])
                    .ToArray();

                bool InstancePropertyWithPropertyNameExists(string propertyName, SyntaxNode anyChildNodeWithinTypeDeclaration)
                {
                    var typeDeclaration = anyChildNodeWithinTypeDeclaration.FirstAncestorOrSelf<TypeDeclarationSyntax>();
                    if (typeDeclaration == null) return false;

                    // We could cache the information about non static properties per type declaration
                    // to avoid traversing the tree every time.
                    // But in the real world the number of dependency properties per type is very moderate.
                    // This would most likely be a premature optimization.
                    // So let's leave it this way.
                    return typeDeclaration
                        .DescendantNodes()
                        .OfType<PropertyDeclarationSyntax>(
                        )
                        .Any(property =>
                            property.Modifiers.All(token => !token.IsKind(SyntaxKind.StaticKeyword)) &&
                            property.Identifier.ValueText == propertyName
                        );
                }
            }
        }
    }
}