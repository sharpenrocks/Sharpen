namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareFieldAsNullable : BaseEnableNullableContextAndDeclareReferenceIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareFieldAsNullable() { }

        public override string FriendlyName { get; } = "Enable nullable context and declare field as nullable";

        public static readonly EnableNullableContextAndDeclareFieldAsNullable Instance = new EnableNullableContextAndDeclareFieldAsNullable();
    }
}