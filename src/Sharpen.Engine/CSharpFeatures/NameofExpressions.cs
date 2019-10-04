using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class NameofExpressions : ICSharpFeature
    {
        private NameofExpressions() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp60 });

        public string FriendlyName { get; } = "Nameof expressions";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/nameof";

        public static readonly NameofExpressions Instance = new NameofExpressions();
    }
}
