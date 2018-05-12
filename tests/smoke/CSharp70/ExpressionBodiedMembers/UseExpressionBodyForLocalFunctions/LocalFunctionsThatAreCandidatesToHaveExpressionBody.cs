// ReSharper disable All

// Expected number of suggestions: 10

using System;

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForLocalFunctions
{
    public class LocalFunctionsThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; set; }
        private int i;

        public void Method()
        {
            void LocalFunction01()
            {
                Console.WriteLine(string.Empty);
            }
            void LocalFunction02(int i)
            {
                this.i = i;
            }
            void LocalFunction03(string s)
            {
                S = s;
            }
            void LocalFunction04(int i, string s)
            {
                S = s ?? throw new ArgumentNullException(nameof(s));
            }
            void LocalFunction05(int i, string s, double d)
            {
                S = s ?? throw new ArgumentNullException(nameof(s));
            }
        }
    }

    public class LocalFunctionsThatAreCandidatesToHaveExpressionBodyWithComments
    {
        public string S { get; set; }
        private int i;

        public void Method()
        {
            void LocalFunction01()
            {
                // This is some comment.
                Console.WriteLine(string.Empty);
            }
            void LocalFunction02(int i)
            {
                // This is some comment.
                this.i = i;
            }
            void LocalFunction03(string s)
            {
                // This is some comment.
                S = s;
            }
            void LocalFunction04(int i, string s)
            {
                // This is some comment.
                S = s ?? throw new ArgumentNullException(nameof(s));
            }
            void LocalFunction05(int i, string s, double d)
            {
                // This is some comment.
                S = s ?? throw new ArgumentNullException(nameof(s));
            }
        }
    }
}