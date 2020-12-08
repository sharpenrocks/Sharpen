using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class DefaultExpressions : ICSharpFeature
    {
        private DefaultExpressions() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp71 });

        public string FriendlyName { get; } = "Default expressions";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/default#default-literal";

        public static readonly DefaultExpressions Instance = new DefaultExpressions();
    }
}
