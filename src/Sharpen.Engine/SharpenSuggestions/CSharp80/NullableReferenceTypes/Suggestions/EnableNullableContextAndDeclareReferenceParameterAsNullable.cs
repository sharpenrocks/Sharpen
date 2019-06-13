namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareReferenceParameterAsNullable : BaseEnableNullableContextAndDeclareReferenceIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareReferenceParameterAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare reference parameter as nullable";

        public static readonly EnableNullableContextAndDeclareReferenceParameterAsNullable Instance = new EnableNullableContextAndDeclareReferenceParameterAsNullable();
    }
}