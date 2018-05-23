using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp60.NameofExpressions
{
    internal sealed class UseNameofExpressionForThrowingArgumentExceptions : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        class ArgumentExceptionInfo
        {
            public string ExceptionName { get; }
            public string ExceptionNamespace { get; }
            public string ParameterName { get; }

            public ArgumentExceptionInfo(string exceptionName, string exceptionNamespace, string parameterName)
            {
                ExceptionName = exceptionName;
                ExceptionNamespace = exceptionNamespace;
                ParameterName = parameterName;
            }
        }

        private UseNameofExpressionForThrowingArgumentExceptions() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp60;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.NameofExpressions.Instance;

        public string FriendlyName { get; } = "Use nameof expression for throwing argument exceptions";

        public static readonly UseNameofExpressionForThrowingArgumentExceptions Instance = new UseNameofExpressionForThrowingArgumentExceptions();

        private static readonly ArgumentExceptionInfo[] ArgumentExceptions =
        {
            new ArgumentExceptionInfo("ArgumentNullException", "System", "paramName"),
            new ArgumentExceptionInfo("ArgumentException", "System", "paramName"),
            new ArgumentExceptionInfo("ArgumentOutOfRangeException", "System", "paramName"),
            new ArgumentExceptionInfo("InvalidEnumArgumentException", "System.ComponentModel", "argumentName")
            // TODO-SETTINGS: Allow users to define their own argument exceptions.
        };

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<ThrowStatementSyntax>()
                .Select(@throw => new
                {
                    ThrowStatement = @throw,
                    ParameterNameArgument = GetParameterNameArgumentIfThrowThrowsArgumentExceptionWithProperParameterName(@throw)
                })
                .Where(throwWithParameterName => throwWithParameterName.ParameterNameArgument != null)
                .Select(@throw => new AnalysisResult
                (
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    @throw.ParameterNameArgument.GetFirstToken(),
                    @throw.ThrowStatement.Expression
                ));

            ArgumentSyntax GetParameterNameArgumentIfThrowThrowsArgumentExceptionWithProperParameterName(ThrowStatementSyntax throwStatementSyntax)
            {
                // Let's first do fast checks that quickly and cheaply eliminate obvious non-candidates.
                // We want to use the semantic model only if we are sure that we have candidates that are
                // very likely throw statements that we are looking for.
                if (!(throwStatementSyntax.Expression is ObjectCreationExpressionSyntax objectCreationExpression)) return null;

                if (!ArgumentExceptions.Select(exception => exception.ExceptionName).Any(name =>
                    objectCreationExpression.Type.ToString().EndsWith(name, StringComparison.Ordinal)))
                    return null;

                var argumentsThatCouldBeParameterNames = objectCreationExpression.ArgumentList.Arguments
                    .Where(argument =>
                        argument.Expression.IsKind(SyntaxKind.StringLiteralExpression) &&
                        ((LiteralExpressionSyntax) argument.Expression).Token.ValueText.CouldBePotentialParameterName()
                    )
                    .ToList();

                if (!argumentsThatCouldBeParameterNames.Any()) return null;

                var parameterNamesAvailableInScopeOfThrow = throwStatementSyntax.GetParameterNamesVisibleInScope();

                var argumentsThatAreParameterNames = argumentsThatCouldBeParameterNames
                    .Where(argument => parameterNamesAvailableInScopeOfThrow.Contains(((LiteralExpressionSyntax) argument.Expression).Token.ValueText))
                    .ToList();

                if (!argumentsThatAreParameterNames.Any()) return null;

                // If we reach this point it means that we have a throw statement that has a constructor call
                // that creates an exception whose name pretty much surely fits the name of the argument exceptions and whose
                // constructor argument, any or more of them, are strings that appear in the surrounding parameters names.
                // Which means we are in a real case most likely 99% percent sure that we have a fit. Cool :-)
                // Still, we have to check for those 1% since we could have a something like this:
                // throw new AlmostArgumentNullException("A message, although the first parameter should be parameter name ;-)", "parameterName");
                // For that check, we need semantic analysis.

                var constructorSymbol = (IMethodSymbol)semanticModel.GetSymbolInfo(objectCreationExpression).Symbol;
                if (constructorSymbol == null) return null;

                var exceptionName = constructorSymbol.ContainingType?.Name;
                var exceptionNamespace = constructorSymbol.ContainingType?.ContainingNamespace;

                // 1. Check that the created object is 100% one of the argument exceptions.
                var argumentException = ArgumentExceptions.FirstOrDefault(exception =>
                                                                    exceptionName == exception.ExceptionName &&
                                                                    exceptionNamespace.FullNameIsEqualTo(exception.ExceptionNamespace));
                if (argumentException == null) return null;

                // 2. Check that the constructor arguments that are strings with enclosing parameter names
                //    are passed as proper constructor parameters.
                return argumentsThatAreParameterNames.FirstOrDefault(argument =>
                           GetParameterNameBehindTheArgument(argument) == argumentException.ParameterName);


                string GetParameterNameBehindTheArgument(ArgumentSyntax argument)
                {
                    // If we are lucky and have a named argument ;-)
                    if (argument.NameColon != null)
                    {
                        var parameterNameText = argument.NameColon.Name?.Identifier.ValueText;
                        return parameterNameText ?? string.Empty;
                    }

                    // We were nor lucky. We have a normal positional argument in the list of arguments.
                    var index = ((ArgumentListSyntax)argument.Parent).Arguments.IndexOf(argument);
                    return index < 0 || index >= constructorSymbol.Parameters.Length
                        ? string.Empty
                        : constructorSymbol.Parameters[index].Name;
                }
            }
        }
    }
}