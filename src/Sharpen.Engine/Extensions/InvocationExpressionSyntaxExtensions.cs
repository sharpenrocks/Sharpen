using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.Extensions
{
    internal static class InvocationExpressionSyntaxExtensions
    {
        public static bool IsInvokedWithinLambdaOrAnonymousMethod(this InvocationExpressionSyntax invocation)
        {
            return invocation.FirstAncestorOrSelf<AnonymousFunctionExpressionSyntax>() != null;
        }

        public static string GetInvokedMethodName(this InvocationExpressionSyntax invocation)
        {
            if (invocation.Expression == null) return string.Empty;

            switch (invocation.Expression)
            {
                case MemberAccessExpressionSyntax memberAccess:
                    return memberAccess.Name.Identifier.ValueText;
                case IdentifierNameSyntax identifierName:
                    return identifierName.Identifier.ValueText;
            }

            return string.Empty;
        }
    }
}