using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class IndicesAndRanges : ICSharpFeature
    {
        private IndicesAndRanges() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp80 });

        public string FriendlyName { get; } = "Indices and ranges";

        public static readonly IndicesAndRanges Instance = new IndicesAndRanges();
    }
}