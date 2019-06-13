namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareReferencePropertyAsNullable : BaseEnableNullableContextAndDeclareReferenceIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareReferencePropertyAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare reference property as nullable";

        public static readonly EnableNullableContextAndDeclareReferencePropertyAsNullable Instance = new EnableNullableContextAndDeclareReferencePropertyAsNullable();
    }
}