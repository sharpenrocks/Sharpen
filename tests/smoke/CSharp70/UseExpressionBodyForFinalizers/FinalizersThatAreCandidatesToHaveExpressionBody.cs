// ReSharper disable All

using System;

namespace CSharp70.UseExpressionBodyForFinalizers
{
    public class FinalizersThatAreCandidatesToHaveExpressionBody01
    {
        ~FinalizersThatAreCandidatesToHaveExpressionBody01()
        {
            Console.WriteLine(string.Empty);
        }
    }

    public class FinalizersThatAreCandidatesToHaveExpressionBody02
    {
        private int i;

        ~FinalizersThatAreCandidatesToHaveExpressionBody02()
        {
            i = 0;
        }
    }

    public class FinalizersThatAreCandidatesToHaveExpressionBody03
    {
        public string S { get; private set; }

        ~FinalizersThatAreCandidatesToHaveExpressionBody03()
        {
            S = string.Empty;
        }
    }

    public class FinalizersThatAreCandidatesToHaveExpressionBody04
    {
        public string S { get; private set; }

        ~FinalizersThatAreCandidatesToHaveExpressionBody04()
        {
            S = string.Empty ?? throw new ArgumentNullException("");
        }
    }

    public class FinalizersThatAreCandidatesToHaveExpressionBodyWithComments01
    {
        ~FinalizersThatAreCandidatesToHaveExpressionBodyWithComments01()
        {
            // This is some comment.
            Console.WriteLine(string.Empty);
        }
    }

    public class FinalizersThatAreCandidatesToHaveExpressionBodyWithComments02
    {
        private int i;

        ~FinalizersThatAreCandidatesToHaveExpressionBodyWithComments02()
        {
            // This is some comment.
            i = 0;
        }
    }

    public class FinalizersThatAreCandidatesToHaveExpressionBodyWithComments03
    {
        public string S { get; private set; }

        ~FinalizersThatAreCandidatesToHaveExpressionBodyWithComments03()
        {
            // This is some comment.
            S = string.Empty;
        }
    }

    public class FinalizersThatAreCandidatesToHaveExpressionBodyWithComments04
    {
        public string S { get; private set; }

        ~FinalizersThatAreCandidatesToHaveExpressionBodyWithComments04()
        {
            // This is some comment.
            S = string.Empty ?? throw new ArgumentNullException("");
        }
    }
}