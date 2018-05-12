// ReSharper disable All

using System;
using System.Linq;

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForLocalFunctions
{
    public class LocalFunctionsThatAreNotCandidatesToHaveExpressionBody
    {
        public string S { get; set; }
        private int i;

        void LocalFunction01()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
        }
        void LocalFunction02(int i)
        {
            this.i = i;
            Console.WriteLine(string.Empty);
        }
        void LocalFunction03(string s)
        {
            i = 0;
            S = s;
        }
        void LocalFunction04(int i, string s)
        {
            S = s ?? throw new ArgumentNullException(nameof(s));
            this.i = i;
        }
        void LocalFunction05(int i, string s, double d)
        {
            S = s ?? throw new ArgumentNullException(nameof(s));
            this.i = i;
        }

        void LocalFunction06(int i, string s, double d, float f)
        {
            foreach (var item in Enumerable.Empty<int>()) { }
        }
        void LocalFunction07(int i, string s, double d, float f, bool b)
        {
            if (i == 0) S = s;
        }
    }
}