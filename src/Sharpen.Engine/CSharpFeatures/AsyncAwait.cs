using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class AsyncAwait : ICSharpFeature
    {
        private AsyncAwait() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp50 });

        public string FriendlyName { get; } = "Async and await";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/";

        public static readonly AsyncAwait Instance = new AsyncAwait();
    }
}
