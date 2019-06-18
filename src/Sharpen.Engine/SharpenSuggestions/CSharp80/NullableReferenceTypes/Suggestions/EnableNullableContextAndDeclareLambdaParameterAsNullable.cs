namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareLambdaParameterAsNullable : BaseEnableNullableContextAndDeclareIdentifierAsNullableSuggestion
    {
        private EnableNullableContextAndDeclareLambdaParameterAsNullable() { }
        public override string FriendlyName { get; } = "Enable nullable context and declare lambda parameter as nullable";

        public static readonly EnableNullableContextAndDeclareLambdaParameterAsNullable Instance = new EnableNullableContextAndDeclareLambdaParameterAsNullable();
    }
}