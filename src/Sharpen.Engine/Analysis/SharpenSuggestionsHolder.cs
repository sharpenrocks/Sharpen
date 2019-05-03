using Sharpen.Engine.SharpenSuggestions.CSharp30.ImplicitlyTypedLocalVariables;
using Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait;
using Sharpen.Engine.SharpenSuggestions.CSharp60.ExpressionBodiedMembers;
using Sharpen.Engine.SharpenSuggestions.CSharp60.NameofExpressions;
using Sharpen.Engine.SharpenSuggestions.CSharp70.ExpressionBodiedMembers;
using Sharpen.Engine.SharpenSuggestions.CSharp70.OutVariables;
using Sharpen.Engine.SharpenSuggestions.CSharp71.DefaultExpressions;

namespace Sharpen.Engine.Analysis
{
    // There is no need to complicate here. We do not need any complex collector so far.
    // No need for MEF based instance searches or similar. New suggestions are added rather
    // rarely and at the moment it is very easy to keep this list manually up-to-date.
    internal static class SharpenSuggestionsHolder
    {
        public static readonly ISharpenSuggestion[] Suggestions =
        {
            // C# 3.0
            UseVarKeywordInVariableDeclarationWithObjectCreation.Instance,

            // C# 5.0.
            ConsiderAwaitingEquivalentAsynchronousMethod.Instance,
            AwaitEquivalentAsynchronousMethod.Instance,
            AwaitTaskDelayInsteadOfCallingThreadSleep.Instance,
            AwaitTaskInsteadOfCallingTaskWait.Instance,
            AwaitTaskInsteadOfCallingTaskResult.Instance,
            AwaitTaskWhenAllInsteadOfCallingTaskWaitAll.Instance,
            AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny.Instance,

            // C# 6.0.
            UseExpressionBodyForGetOnlyProperties.Instance,
            UseExpressionBodyForGetOnlyIndexers.Instance,

            UseNameofExpressionForThrowingArgumentExceptions.Instance,
            UseNameofExpressionInDependencyPropertyDeclarations.Instance,

            // C# 7.0.
            UseExpressionBodyForConstructors.Instance,
            UseExpressionBodyForDestructors.Instance,
            UseExpressionBodyForGetAccessorsInProperties.Instance,
            UseExpressionBodyForGetAccessorsInIndexers.Instance,
            UseExpressionBodyForSetAccessorsInProperties.Instance,
            UseExpressionBodyForSetAccessorsInIndexers.Instance,
            UseExpressionBodyForLocalFunctions.Instance,

            UseOutVariablesInMethodInvocations.Instance,
            UseOutVariablesInObjectCreations.Instance,
            DiscardOutVariablesInMethodInvocations.Instance,
            DiscardOutVariablesInObjectCreations.Instance,

            // C# 7.1.
            UseDefaultExpressionInReturnStatements.Instance,
            UseDefaultExpressionInOptionalMethodParameters.Instance,
            UseDefaultExpressionInOptionalConstructorParameters.Instance
        };
    }
}