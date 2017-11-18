// ReSharper disable All

using System;
using System.Linq;

namespace CSharp60.UseExpressionBodyForGetOnlyIndexers
{
    public class GetOnlyIndexersThatAreNotCandidatesToHaveExpressionBody
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
        }

        public string this[string index]
        {
            get
            {
                i = 0;
                Console.WriteLine(string.Empty);
                return string.Empty;
            }
        }

        public double this[double index]
        {
            get
            {
                i = 0;
                S = string.Empty;
                return 0;
            }
        }

        public float this[float index]
        {
            get
            {
                i = 0;
                S = string.Empty ?? throw new ArgumentNullException("");
                return 0;
            }
        }

        public bool this[bool index]
        {
            get
            {
                foreach (var item in Enumerable.Empty<int>()) { }
                return true;
            }
        }

        public decimal this[decimal index]
        {
            get
            {
                if (i == 0) S = string.Empty;
                return 0;
            }
        }
    }
}