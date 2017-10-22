// ReSharper disable All

using System;
using System.Linq;

namespace CSharp70.UseExpressionBodyForFinalizers
{
    public class FinalizersThatAreNotCandidatesToHaveExpressionBody01
    {
        ~FinalizersThatAreNotCandidatesToHaveExpressionBody01()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
        }
    }

    public class FinalizersThatAreNotCandidatesToHaveExpressionBody02
    {
        private int i;

        ~FinalizersThatAreNotCandidatesToHaveExpressionBody02()
        {
            i = 0;
            Console.WriteLine(string.Empty);
        }
    }

    public class FinalizersThatAreNotCandidatesToHaveExpressionBody03
    {
        public string S { get; private set; }
        private int i;

        ~FinalizersThatAreNotCandidatesToHaveExpressionBody03()
        {
            i = 0;
            S = string.Empty;
        }
    }

    public class FinalizersThatAreNotCandidatesToHaveExpressionBody04
    {
        public string S { get; private set; }
        private int i;

        ~FinalizersThatAreNotCandidatesToHaveExpressionBody04()
        {
            S = string.Empty ?? throw new ArgumentNullException("");
            i = 0;
        }
    }

    public class FinalizersThatAreNotCandidatesToHaveExpressionBody05
    {
        ~FinalizersThatAreNotCandidatesToHaveExpressionBody05()
        {
            foreach (var item in Enumerable.Empty<int>()) { }
        }
    }

    public class FinalizersThatAreNotCandidatesToHaveExpressionBody06
    {
        public string S { get; private set; }
        private int i;

        ~FinalizersThatAreNotCandidatesToHaveExpressionBody06()
        {
            if (i == 0) S = string.Empty;
        }
    }
}