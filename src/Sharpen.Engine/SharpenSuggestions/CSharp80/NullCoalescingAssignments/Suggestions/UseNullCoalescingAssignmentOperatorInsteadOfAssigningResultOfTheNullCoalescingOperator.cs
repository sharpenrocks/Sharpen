namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullCoalescingAssignments.Suggestions
{
    internal sealed class UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator : ISharpenSuggestion
    {
        private UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.NullCoalescingAssignments.Instance;

        public string FriendlyName { get; } = "Use ??= operator instead of assigning result of the ?? operator";

        public static readonly UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator Instance = new UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator();
    }
}