namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareConstructorParameterAsNullable : BaseEnableNullableContextAndDeclareIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareConstructorParameterAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare constructor parameter as nullable";

        public static readonly EnableNullableContextAndDeclareConstructorParameterAsNullable Instance = new EnableNullableContextAndDeclareConstructorParameterAsNullable();
    }
}