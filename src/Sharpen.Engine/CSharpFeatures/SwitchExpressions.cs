using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class SwitchExpressions : ICSharpFeature
    {
        private SwitchExpressions() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp80 });

        public string FriendlyName { get; } = "Switch expressions";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions";

        public static readonly SwitchExpressions Instance = new SwitchExpressions();
    }
}