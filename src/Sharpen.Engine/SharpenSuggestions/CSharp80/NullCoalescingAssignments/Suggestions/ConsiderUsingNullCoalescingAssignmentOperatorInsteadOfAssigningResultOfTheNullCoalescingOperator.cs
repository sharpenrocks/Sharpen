namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullCoalescingAssignments.Suggestions
{
    internal sealed class ConsiderUsingNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator : ISharpenSuggestion
    {
        private ConsiderUsingNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.NullCoalescingAssignments.Instance;

        public string FriendlyName { get; } = "Consider using ??= operator instead of assigning result of the ?? operator";

        public static readonly ConsiderUsingNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator Instance = new ConsiderUsingNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator();
    }
}