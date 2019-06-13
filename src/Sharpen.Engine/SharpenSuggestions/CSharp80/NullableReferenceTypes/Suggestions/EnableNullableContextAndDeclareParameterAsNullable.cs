namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareParameterAsNullable : BaseEnableNullableContextAndDeclareIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareParameterAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare parameter as nullable";

        public static readonly EnableNullableContextAndDeclareParameterAsNullable Instance = new EnableNullableContextAndDeclareParameterAsNullable();
    }
}