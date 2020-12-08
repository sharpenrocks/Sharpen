using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class ExpressionBodiedMembers : ICSharpFeature
    {
        private ExpressionBodiedMembers() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp60, CSharp70 });

        public string FriendlyName { get; } = "Expression-bodied members";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members";

        public static readonly ExpressionBodiedMembers Instance = new ExpressionBodiedMembers();
    }
}
