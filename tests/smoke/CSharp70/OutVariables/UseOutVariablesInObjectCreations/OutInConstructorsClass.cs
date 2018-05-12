using System.Collections.Generic;
using System.Linq;

namespace CSharp70.OutVariables.UseOutVariablesInObjectCreations
{
    class OutInConstructorsClass
    {
        public OutInConstructorsClass(int i, out int j, ref int l)
        {
            j = 0;
            l = l == 0 ? 1: 0;
        }

        public OutInConstructorsClass(int i, out int j)
        {
            j = 0;
        }

        public OutInConstructorsClass(int i)
        {
        }

        public OutInConstructorsClass(out int i, out int j)
        {
            i = 0;
            j = 0;
        }

        public IEnumerable<T> EnumerableMethod<T>(out int i)
        {
            i = 0;
            return Enumerable.Empty<T>();
        }

        public bool Bool => true;
        public int Int => 0;

        public bool GetBool(bool value) => value;
    }
}