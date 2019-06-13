namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclarePropertyAsNullable : BaseEnableNullableContextAndDeclareReferenceIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclarePropertyAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare property as nullable";

        public static readonly EnableNullableContextAndDeclarePropertyAsNullable Instance = new EnableNullableContextAndDeclarePropertyAsNullable();
    }
}