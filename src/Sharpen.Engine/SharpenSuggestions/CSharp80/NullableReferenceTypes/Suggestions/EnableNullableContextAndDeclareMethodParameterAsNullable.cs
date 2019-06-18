namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareMethodParameterAsNullable : BaseEnableNullableContextAndDeclareIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareMethodParameterAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare method parameter as nullable";

        public static readonly EnableNullableContextAndDeclareMethodParameterAsNullable Instance = new EnableNullableContextAndDeclareMethodParameterAsNullable();
    }
}