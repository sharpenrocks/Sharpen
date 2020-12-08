using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class AsynchronousStreams : ICSharpFeature
    {
        private AsynchronousStreams() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp80 });

        public string FriendlyName { get; } = "Asynchronous streams";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#asynchronous-streams";

        public static readonly AsynchronousStreams Instance = new AsynchronousStreams();
    }
}
