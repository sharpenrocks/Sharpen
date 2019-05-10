using System.Collections.Immutable;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    public class ImplicitlyTypedLocalVariables : ICSharpFeature
    {
        private ImplicitlyTypedLocalVariables() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp30 });

        public string FriendlyName { get; } = "Implicitly typed local variables";

        public static readonly ImplicitlyTypedLocalVariables Instance = new ImplicitlyTypedLocalVariables();
    }
}
