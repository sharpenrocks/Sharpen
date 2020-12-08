using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class NullCoalescingAssignments : ICSharpFeature
    {
        private NullCoalescingAssignments() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp80 });

        public string FriendlyName { get; } = "Null-coalescing assignments";

        public string LearnMoreUrl => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator";

        public static readonly NullCoalescingAssignments Instance = new NullCoalescingAssignments();
    }
}
