namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareLocalVariableAsNullable : BaseEnableNullableContextAndDeclareReferenceIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareLocalVariableAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare local variable as nullable";

        public static readonly EnableNullableContextAndDeclareLocalVariableAsNullable Instance = new EnableNullableContextAndDeclareLocalVariableAsNullable();
    }
}