// ReSharper disable All

using System;

namespace CSharp70.UseExpressionBodyForFinalizers
{
    public class FinalizersThatAlreadyHaveExpressionBody01
    {
        ~FinalizersThatAlreadyHaveExpressionBody01() => Console.WriteLine(string.Empty);
    }

    public class FinalizersThatAlreadyHaveExpressionBody02
    {
        private int i;

        ~FinalizersThatAlreadyHaveExpressionBody02() => i = 0;
    }

    public class FinalizersThatAlreadyHaveExpressionBody03
    {
        public string S { get; private set; }

        ~FinalizersThatAlreadyHaveExpressionBody03() => S = string.Empty;
    }

    public class FinalizersThatAlreadyHaveExpressionBody04
    {
        public string S { get; private set; }

        ~FinalizersThatAlreadyHaveExpressionBody04() => S = string.Empty ?? throw new ArgumentNullException("");
    }

    public class FinalizersThatAlreadyHaveExpressionBodyWithComments01
    {
        ~FinalizersThatAlreadyHaveExpressionBodyWithComments01() =>
            // This is some comment.
            Console.WriteLine(string.Empty);
    }

    public class FinalizersThatAlreadyHaveExpressionBodyWithComments02
    {
        private int i;

        ~FinalizersThatAlreadyHaveExpressionBodyWithComments02() =>
            // This is some comment.
            i = 0;
    }

    public class FinalizersThatAlreadyHaveExpressionBodyWithComments03
    {
        public string S { get; private set; }

        ~FinalizersThatAlreadyHaveExpressionBodyWithComments03() =>
            // This is some comment.
            S = string.Empty;
    }

    public class FinalizersThatAlreadyHaveExpressionBodyWithComments04
    {
        public string S { get; private set; }

        ~FinalizersThatAlreadyHaveExpressionBodyWithComments04() =>
            // This is some comment.
            S = string.Empty ?? throw new ArgumentNullException("");
    }
}