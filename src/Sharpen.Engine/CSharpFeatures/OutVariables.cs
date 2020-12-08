using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class OutVariables : ICSharpFeature
    {
        private OutVariables() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp70 });

        public string FriendlyName { get; } = "Out variables";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier#calling-a-method-with-an-out-argument";

        public static readonly OutVariables Instance = new OutVariables();
    }
}