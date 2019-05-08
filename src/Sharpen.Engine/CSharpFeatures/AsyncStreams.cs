using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class AsyncStreams : ICSharpFeature
    {
        private AsyncStreams() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp80 });

        public string FriendlyName { get; } = "Async streams";

        public static readonly AsyncStreams Instance = new AsyncStreams();
    }
}
