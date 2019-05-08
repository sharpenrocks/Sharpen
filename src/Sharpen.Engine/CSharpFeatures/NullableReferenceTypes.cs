using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class NullableReferenceTypes : ICSharpFeature
    {
        private NullableReferenceTypes() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp80 });

        public string FriendlyName { get; } = "Nullable reference types";

        public static readonly NullableReferenceTypes Instance = new NullableReferenceTypes();
    }
}
