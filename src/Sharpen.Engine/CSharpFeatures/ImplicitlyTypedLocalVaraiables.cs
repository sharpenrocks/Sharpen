using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sharpen.Engine.CSharpLanguageVersions;

namespace Sharpen.Engine.CSharpFeatures
{
    class ImplicitlyTypedLocalVaraiables : ICSharpFeature
    {

        private ImplicitlyTypedLocalVaraiables() { }

        public ImmutableArray<string> LanguageVersions { get; } = ImmutableArray.CreateRange(new[] { CSharp30 ,CSharp50, CSharp60, CSharp70 , CSharp71});

        public string FriendlyName { get; } = "Implicitly Typed Local Variables";

        public static readonly ImplicitlyTypedLocalVaraiables Instance = new ImplicitlyTypedLocalVaraiables();

    }
}
