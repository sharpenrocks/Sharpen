namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareReferenceFieldAsNullable : BaseEnableNullableContextAndDeclareReferenceIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareReferenceFieldAsNullable() { }

        public override string FriendlyName { get; } = "Enable nullable context and declare reference field as nullable";

        public static readonly EnableNullableContextAndDeclareReferenceFieldAsNullable Instance = new EnableNullableContextAndDeclareReferenceFieldAsNullable();
    }
}