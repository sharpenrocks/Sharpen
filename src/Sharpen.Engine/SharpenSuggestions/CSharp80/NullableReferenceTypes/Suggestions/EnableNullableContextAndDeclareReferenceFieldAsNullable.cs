namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareReferenceFieldAsNullable : ISharpenSuggestion
    {
        private EnableNullableContextAndDeclareReferenceFieldAsNullable() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.NullableReferenceTypes.Instance;

        public string FriendlyName { get; } = "Enable nullable context and declare reference field as nullable";

        public static readonly EnableNullableContextAndDeclareReferenceFieldAsNullable Instance = new EnableNullableContextAndDeclareReferenceFieldAsNullable();
    }
}