namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions
{
    internal sealed class EnableNullableContextAndDeclareReferenceParameterAsNullable : ISharpenSuggestion
    {
        private EnableNullableContextAndDeclareReferenceParameterAsNullable() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.NullableReferenceTypes.Instance;

        public string FriendlyName { get; } = "Enable nullable context and declare reference parameter as nullable";

        public static readonly EnableNullableContextAndDeclareReferenceParameterAsNullable Instance = new EnableNullableContextAndDeclareReferenceParameterAsNullable();
    }
}