namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareReferenceVariableAsNullable : ISharpenSuggestion
    {
        private EnableNullableContextAndDeclareReferenceVariableAsNullable() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.NullableReferenceTypes.Instance;

        public string FriendlyName { get; } = "Enable nullable context and declare reference variable as nullable";

        public static readonly EnableNullableContextAndDeclareReferenceVariableAsNullable Instance = new EnableNullableContextAndDeclareReferenceVariableAsNullable();
    }
}