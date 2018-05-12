// ReSharper disable All

using System;
using System.Linq;

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForGetAccessorsInIndexers
{
    public class GetAccessorsThatAreNotCandidatesToHaveExpressionBody
    {
        public string S { get; set; }
        private int i;

        public int this[int index]
        {
            get
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
                return 0;
            }
            set { }
        }

        public string this[string index]
        {
            get
            {
                i = 0;
                Console.WriteLine(string.Empty);
                return string.Empty;
            }
            set { }
        }

        public double this[double index]
        {
            get
            {
                i = 0;
                S = string.Empty;
                return 0;
            }
            set { }
        }

        public float this[float index]
        {
            get
            {
                i = 0;
                S = string.Empty ?? throw new ArgumentNullException("");
                return 0;
            }
            set { }
        }

        public bool this[bool index]
        {
            get
            {
                foreach (var item in Enumerable.Empty<int>()) { }
                return true;
            }
            set { }
        }

        public decimal this[decimal index]
        {
            get
            {
                if (i == 0) S = string.Empty;
                return 0;
            }
            set { }
        }
    }

    public class GetAccessorsThatAreNotCandidatesToHaveExpressionBodyBecauseThereIsNoSetter
    {
        // Basically, they should be converted to indexers with expression body, without the get keyword ;-)
        public string S { get; }
        private int i;

        public int this[int index]
        {
            get { return i; }
        }
        public string this[string index]
        {
            get { return S ?? throw new ArgumentNullException(nameof(S)); }
        }
        public double this[double index]
        {
            get { return Convert.ToDouble(S.ToUpper().ToLower()); }
        }
    }
}