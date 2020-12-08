namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareAnonymousDelegateParameterAsNullable : BaseEnableNullableContextAndDeclareIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareAnonymousDelegateParameterAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare delegate parameter as nullable";

        public static readonly EnableNullableContextAndDeclareAnonymousDelegateParameterAsNullable Instance = new EnableNullableContextAndDeclareAnonymousDelegateParameterAsNullable();
    }
}