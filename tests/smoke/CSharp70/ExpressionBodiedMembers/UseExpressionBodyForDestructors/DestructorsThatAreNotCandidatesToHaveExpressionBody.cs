// ReSharper disable All

using System;
using System.Linq;

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForDestructors
{
    public class DestructorsThatAreNotCandidatesToHaveExpressionBody01
    {
        ~DestructorsThatAreNotCandidatesToHaveExpressionBody01()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
        }
    }

    public class DestructorsThatAreNotCandidatesToHaveExpressionBody02
    {
        private int i;

        ~DestructorsThatAreNotCandidatesToHaveExpressionBody02()
        {
            i = 0;
            Console.WriteLine(string.Empty);
        }
    }

    public class DestructorsThatAreNotCandidatesToHaveExpressionBody03
    {
        public string S { get; private set; }
        private int i;

        ~DestructorsThatAreNotCandidatesToHaveExpressionBody03()
        {
            i = 0;
            S = string.Empty;
        }
    }

    public class DestructorsThatAreNotCandidatesToHaveExpressionBody04
    {
        public string S { get; private set; }
        private int i;

        ~DestructorsThatAreNotCandidatesToHaveExpressionBody04()
        {
            S = string.Empty ?? throw new ArgumentNullException("");
            i = 0;
        }
    }

    public class DestructorsThatAreNotCandidatesToHaveExpressionBody05
    {
        ~DestructorsThatAreNotCandidatesToHaveExpressionBody05()
        {
            foreach (var item in Enumerable.Empty<int>()) { }
        }
    }

    public class DestructorsThatAreNotCandidatesToHaveExpressionBody06
    {
        public string S { get; private set; }
        private int i;

        ~DestructorsThatAreNotCandidatesToHaveExpressionBody06()
        {
            if (i == 0) S = string.Empty;
        }
    }
}