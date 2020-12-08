using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class UsingDeclarations : ICSharpFeature
    {
        private UsingDeclarations() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp80 });

        public string FriendlyName { get; } = "Using declarations";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations";

        public static readonly UsingDeclarations Instance = new UsingDeclarations();
    }
}