using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class SwitchExpressions : ICSharpFeature
    {
        private SwitchExpressions() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp80 });

        public string FriendlyName { get; } = "Switch expressions";

        public static readonly SwitchExpressions Instance = new SwitchExpressions();
    }
}