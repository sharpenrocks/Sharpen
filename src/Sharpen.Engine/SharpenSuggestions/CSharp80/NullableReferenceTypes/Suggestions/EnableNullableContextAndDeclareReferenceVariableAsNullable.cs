namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareReferenceVariableAsNullable : BaseEnableNullableContextAndDeclareReferenceIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareReferenceVariableAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare reference variable as nullable";

        public static readonly EnableNullableContextAndDeclareReferenceVariableAsNullable Instance = new EnableNullableContextAndDeclareReferenceVariableAsNullable();
    }
}