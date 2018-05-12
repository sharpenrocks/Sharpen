// ReSharper disable All

using System;

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForDestructors
{
    public class DestructorsThatAlreadyHaveExpressionBody01
    {
        ~DestructorsThatAlreadyHaveExpressionBody01() => Console.WriteLine(string.Empty);
    }

    public class DestructorsThatAlreadyHaveExpressionBody02
    {
        private int i;

        ~DestructorsThatAlreadyHaveExpressionBody02() => i = 0;
    }

    public class DestructorsThatAlreadyHaveExpressionBody03
    {
        public string S { get; private set; }

        ~DestructorsThatAlreadyHaveExpressionBody03() => S = string.Empty;
    }

    public class DestructorsThatAlreadyHaveExpressionBody04
    {
        public string S { get; private set; }

        ~DestructorsThatAlreadyHaveExpressionBody04() => S = string.Empty ?? throw new ArgumentNullException("");
    }

    public class DestructorsThatAlreadyHaveExpressionBodyWithComments01
    {
        ~DestructorsThatAlreadyHaveExpressionBodyWithComments01() =>
            // This is some comment.
            Console.WriteLine(string.Empty);
    }

    public class DestructorsThatAlreadyHaveExpressionBodyWithComments02
    {
        private int i;

        ~DestructorsThatAlreadyHaveExpressionBodyWithComments02() =>
            // This is some comment.
            i = 0;
    }

    public class DestructorsThatAlreadyHaveExpressionBodyWithComments03
    {
        public string S { get; private set; }

        ~DestructorsThatAlreadyHaveExpressionBodyWithComments03() =>
            // This is some comment.
            S = string.Empty;
    }

    public class DestructorsThatAlreadyHaveExpressionBodyWithComments04
    {
        public string S { get; private set; }

        ~DestructorsThatAlreadyHaveExpressionBodyWithComments04() =>
            // This is some comment.
            S = string.Empty ?? throw new ArgumentNullException("");
    }
}