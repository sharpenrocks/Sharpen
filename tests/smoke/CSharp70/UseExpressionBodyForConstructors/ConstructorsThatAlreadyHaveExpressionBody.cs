// ReSharper disable All

using System;

namespace CSharp70.UseExpressionBodyForConstructors
{
    public class ConstructorsThatAlreadyHaveExpressionBody
    {
        public string S { get; }
        private readonly int i;

        public ConstructorsThatAlreadyHaveExpressionBody() => Console.WriteLine(string.Empty);
        public ConstructorsThatAlreadyHaveExpressionBody(int i) => this.i = i;
        public ConstructorsThatAlreadyHaveExpressionBody(string s) => S = s;

        public ConstructorsThatAlreadyHaveExpressionBody(int i, string s) => S = s ?? throw new ArgumentNullException(nameof(s));
        public ConstructorsThatAlreadyHaveExpressionBody(int i, string s, double d) : this(i, s) => S = s ?? throw new ArgumentNullException(nameof(s));
    }

    public class ConstructorsThatAlreadyHaveExpressionBodyBodyWithComments
    {
        public string S { get; }
        private readonly int i;

        public ConstructorsThatAlreadyHaveExpressionBodyBodyWithComments() =>
            // This is some comment.
            Console.WriteLine(string.Empty);
        public ConstructorsThatAlreadyHaveExpressionBodyBodyWithComments(int i) =>
            // This is some comment.
            this.i = i;
        public ConstructorsThatAlreadyHaveExpressionBodyBodyWithComments(string s) =>
            // This is some comment.
            S = s;
        public ConstructorsThatAlreadyHaveExpressionBodyBodyWithComments(int i, string s) =>
            // This is some comment.
            S = s ?? throw new ArgumentNullException(nameof(s));
        public ConstructorsThatAlreadyHaveExpressionBodyBodyWithComments(int i, string s, double d) : this(i, s) =>
            // This is some comment.
            S = s ?? throw new ArgumentNullException(nameof(s));
    }
}
