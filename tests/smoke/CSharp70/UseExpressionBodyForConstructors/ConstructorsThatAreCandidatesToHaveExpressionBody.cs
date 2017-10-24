// ReSharper disable All

// Expected number of suggestions: 11

using System;

namespace CSharp70.UseExpressionBodyForConstructors
{
    public class ConstructorsThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; }
        private readonly int i;

        static ConstructorsThatAreCandidatesToHaveExpressionBody()
        {
            Console.WriteLine(string.Empty);
        }
        public ConstructorsThatAreCandidatesToHaveExpressionBody()
        {
            Console.WriteLine(string.Empty);
        }
        public ConstructorsThatAreCandidatesToHaveExpressionBody(int i)
        {
            this.i = i;
        }
        public ConstructorsThatAreCandidatesToHaveExpressionBody(string s)
        {
            S = s;
        }
        public ConstructorsThatAreCandidatesToHaveExpressionBody(int i, string s)
        {
            S = s ?? throw new ArgumentNullException(nameof(s));
        }
        public ConstructorsThatAreCandidatesToHaveExpressionBody(int i, string s, double d) : this(i, s)
        {
            S = s ?? throw new ArgumentNullException(nameof(s));
        }
    }

    public class ConstructorsThatAreCandidatesToHaveExpressionBodyWithComments
    {
        public string S { get; }
        private readonly int i;

        public ConstructorsThatAreCandidatesToHaveExpressionBodyWithComments()
        {
            // This is some comment.
            Console.WriteLine(string.Empty);
        }
        public ConstructorsThatAreCandidatesToHaveExpressionBodyWithComments(int i)
        {
            // This is some comment.
            this.i = i;
        }
        public ConstructorsThatAreCandidatesToHaveExpressionBodyWithComments(string s)
        {
            // This is some comment.
            S = s;
        }
        public ConstructorsThatAreCandidatesToHaveExpressionBodyWithComments(int i, string s)
        {
            // This is some comment.
            S = s ?? throw new ArgumentNullException(nameof(s));
        }
        public ConstructorsThatAreCandidatesToHaveExpressionBodyWithComments(int i, string s, double d) : this(i, s)
        {
            // This is some comment.
            S = s ?? throw new ArgumentNullException(nameof(s));
        }
    }
}
