using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class IndicesAndRanges : ICSharpFeature
    {
        private IndicesAndRanges() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp80 });

        public string FriendlyName { get; } = "Indices and ranges";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes";

        public static readonly IndicesAndRanges Instance = new IndicesAndRanges();
    }
}