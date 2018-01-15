using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class OutVariables : ICSharpFeature
    {
        private OutVariables() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp70 });

        public string FriendlyName { get; } = "Out variables";

        public static readonly OutVariables Instance = new OutVariables();
    }
}