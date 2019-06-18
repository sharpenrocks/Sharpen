namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareLocalFunctionParameterAsNullable : BaseEnableNullableContextAndDeclareIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareLocalFunctionParameterAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare local function parameter as nullable";

        public static readonly EnableNullableContextAndDeclareLocalFunctionParameterAsNullable Instance = new EnableNullableContextAndDeclareLocalFunctionParameterAsNullable();
    }
}