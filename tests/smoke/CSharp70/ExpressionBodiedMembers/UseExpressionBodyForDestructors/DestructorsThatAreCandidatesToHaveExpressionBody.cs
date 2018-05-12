// ReSharper disable All

// Expected number of suggestions: 8

using System;

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForDestructors
{
    public class DestructorsThatAreCandidatesToHaveExpressionBody01
    {
        ~DestructorsThatAreCandidatesToHaveExpressionBody01()
        {
            Console.WriteLine(string.Empty);
        }
    }

    public class DestructorsThatAreCandidatesToHaveExpressionBody02
    {
        private int i;

        ~DestructorsThatAreCandidatesToHaveExpressionBody02()
        {
            i = 0;
        }
    }

    public class DestructorsThatAreCandidatesToHaveExpressionBody03
    {
        public string S { get; private set; }

        ~DestructorsThatAreCandidatesToHaveExpressionBody03()
        {
            S = string.Empty;
        }
    }

    public class DestructorsThatAreCandidatesToHaveExpressionBody04
    {
        public string S { get; private set; }

        ~DestructorsThatAreCandidatesToHaveExpressionBody04()
        {
            S = string.Empty ?? throw new ArgumentNullException("");
        }
    }

    public class DestructorsThatAreCandidatesToHaveExpressionBodyWithComments01
    {
        ~DestructorsThatAreCandidatesToHaveExpressionBodyWithComments01()
        {
            // This is some comment.
            Console.WriteLine(string.Empty);
        }
    }

    public class DestructorsThatAreCandidatesToHaveExpressionBodyWithComments02
    {
        private int i;

        ~DestructorsThatAreCandidatesToHaveExpressionBodyWithComments02()
        {
            // This is some comment.
            i = 0;
        }
    }

    public class DestructorsThatAreCandidatesToHaveExpressionBodyWithComments03
    {
        public string S { get; private set; }

        ~DestructorsThatAreCandidatesToHaveExpressionBodyWithComments03()
        {
            // This is some comment.
            S = string.Empty;
        }
    }

    public class DestructorsThatAreCandidatesToHaveExpressionBodyWithComments04
    {
        public string S { get; private set; }

        ~DestructorsThatAreCandidatesToHaveExpressionBodyWithComments04()
        {
            // This is some comment.
            S = string.Empty ?? throw new ArgumentNullException("");
        }
    }
}