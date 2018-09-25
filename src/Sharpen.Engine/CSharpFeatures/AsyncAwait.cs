using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class AsyncAwait : ICSharpFeature
    {
        private AsyncAwait() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp50 });

        public string FriendlyName { get; } = "Async-await"; // TODO: Is this the best friendly name?

        public static readonly AsyncAwait Instance = new AsyncAwait();
    }
}
