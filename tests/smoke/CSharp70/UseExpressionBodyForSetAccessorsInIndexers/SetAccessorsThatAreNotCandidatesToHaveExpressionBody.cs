// ReSharper disable All

using System;
using System.Linq;

namespace CSharp70.UseExpressionBodyForSetAccessorsInIndexers
{
    public class SetAccessorsThatAreNotCandidatesToHaveExpressionBody
    {
        public string S { get; set; }
        private int i;

        public int this[int index]
        {
            get => 0;
            set
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
            }
        }

        public string this[string index]
        {
            get => string.Empty;
            set
            {
                i = 0;
                Console.WriteLine(string.Empty);
            }
        }

        public double this[double index]
        {
            get => 0;
            set
            {
                i = 0;
                S = string.Empty;
            }
        }

        public float this[float index]
        {
            get => 0;
            set
            {
                i = 0;
                S = string.Empty ?? throw new ArgumentNullException("");
            }
        }

        public bool this[bool index]
        {
            get => true;
            set
            {
                foreach (var item in Enumerable.Empty<int>()) { }
            }
        }

        public decimal this[decimal index]
        {
            get => 0;
            set
            {
                if (i == 0) S = string.Empty;
            }
        }
    }

    public class SetAccessorsWithoutGettersThatAreNotCandidatesToHaveExpressionBody
    {
        public string S { get; set; }
        private int i;

        public int this[int index]
        {
            set
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
            }
        }

        public string this[string index]
        {
            set
            {
                i = 0;
                Console.WriteLine(string.Empty);
            }
        }

        public double this[double index]
        {
            set
            {
                i = 0;
                S = string.Empty;
            }
        }

        public float this[float index]
        {
            set
            {
                i = 0;
                S = string.Empty ?? throw new ArgumentNullException("");
            }
        }

        public bool this[bool index]
        {
            set
            {
                foreach (var item in Enumerable.Empty<int>()) { }
            }
        }

        public decimal this[decimal index]
        {
            set
            {
                if (i == 0) S = string.Empty;
            }
        }
    }
}