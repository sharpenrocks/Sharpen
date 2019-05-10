namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareReferencePropertyAsNullable : ISharpenSuggestion
    {
        private EnableNullableContextAndDeclareReferencePropertyAsNullable() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.NullableReferenceTypes.Instance;

        public string FriendlyName { get; } = "Enable nullable context and declare reference property as nullable";

        public static readonly EnableNullableContextAndDeclareReferencePropertyAsNullable Instance = new EnableNullableContextAndDeclareReferencePropertyAsNullable();
    }
}