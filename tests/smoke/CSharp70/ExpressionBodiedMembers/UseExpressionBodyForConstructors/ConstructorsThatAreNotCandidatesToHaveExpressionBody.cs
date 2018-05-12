// ReSharper disable All

using System;
using System.Linq;

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForConstructors
{
    public class ConstructorsThatAreNotCandidatesToHaveExpressionBody
    {
        public string S { get; }
        private readonly int i;

        static ConstructorsThatAreNotCandidatesToHaveExpressionBody()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
        }
        public ConstructorsThatAreNotCandidatesToHaveExpressionBody()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
        }
        public ConstructorsThatAreNotCandidatesToHaveExpressionBody(int i)
        {
            this.i = i;
            Console.WriteLine(string.Empty);
        }
        public ConstructorsThatAreNotCandidatesToHaveExpressionBody(string s)
        {
            i = 0;
            S = s;
        }
        public ConstructorsThatAreNotCandidatesToHaveExpressionBody(int i, string s)
        {
            S = s ?? throw new ArgumentNullException(nameof(s));
            this.i = i;
        }
        public ConstructorsThatAreNotCandidatesToHaveExpressionBody(int i, string s, double d) : this(i, s)
        {
            S = s ?? throw new ArgumentNullException(nameof(s));
            this.i = i;
        }

        public ConstructorsThatAreNotCandidatesToHaveExpressionBody(int i, string s, double d, float f) : this(i, s)
        {
            foreach (var item in Enumerable.Empty<int>()) { }
        }
        public ConstructorsThatAreNotCandidatesToHaveExpressionBody(int i, string s, double d, float f, bool b) : this(i, s)
        {
            if (i == 0) S = s;
        }
    }
}