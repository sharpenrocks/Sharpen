using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersion;

namespace Sharpen.Engine.CSharpFeatures
{
    public class ExpressionBodiedMembers : ICSharpFeature
    {
        private ExpressionBodiedMembers() { }

        public ImmutableArray<CSharpLanguageVersion> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp60, CSharp70 });

        public string FriendlyName { get; } = "Expression-bodied members";

        public static readonly ExpressionBodiedMembers Instance = new ExpressionBodiedMembers();
    }
}
