// ReSharper disable All

using System;
using System.Linq;

namespace CSharp70.UseExpressionBodyForSetAccessors
{
    public class SetAccessorsThatAreNotCandidatesToHaveExpressionBody
    {
        public string S { get; set; }
        private int i;
        public static string StaticS { get; set; }
        private static int StaticI;

        public static int StaticIntProperty
        {
            get => 0;
            set
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
            }
        }

        public static string StaticStringProperty
        {
            get => string.Empty;
            set
            {
                StaticI = 0;
                Console.WriteLine(string.Empty);
            }
        }

        public static double StaticDoubleProperty
        {
            get => 0;
            set
            {
                StaticI = 0;
                StaticS = string.Empty;
            }
        }

        public static float StaticFloatProperty
        {
            get => 0;
            set
            {
                StaticI = 0;
                StaticS = string.Empty ?? throw new ArgumentNullException("");
            }
        }

        public static bool StaticBoolProperty
        {
            get => true;
            set
            {
                foreach (var item in Enumerable.Empty<int>()) { }
            }
        }

        public static decimal StaticDecimalProperty
        {
            get => 0;
            set
            {
                if (StaticI == 0) StaticS = string.Empty;
            }
        }

        public int IntProperty
        {
            get => 0;
            set
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
            }
        }

        public string StringProperty
        {
            get => string.Empty;
            set
            {
                i = 0;
                Console.WriteLine(string.Empty);
            }
        }

        public double DoubleProperty
        {
            get => 0;
            set
            {
                i = 0;
                S = string.Empty;
            }
        }

        public float FloatProperty
        {
            get => 0;
            set
            {
                i = 0;
                S = string.Empty ?? throw new ArgumentNullException("");
            }
        }

        public bool BoolProperty
        {
            get => true;
            set
            {
                foreach (var item in Enumerable.Empty<int>()) { }
            }
        }

        public decimal DecimalProperty
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
        public static string StaticS { get; set; }
        private static int StaticI;

        public static int StaticIntProperty
        {
            set
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
            }
        }

        public static string StaticStringProperty
        {
            set
            {
                StaticI = 0;
                Console.WriteLine(string.Empty);
            }
        }

        public static double StaticDoubleProperty
        {
            set
            {
                StaticI = 0;
                StaticS = string.Empty;
            }
        }

        public static float StaticFloatProperty
        {
            set
            {
                StaticI = 0;
                StaticS = string.Empty ?? throw new ArgumentNullException("");
            }
        }

        public static bool StaticBoolProperty
        {
            set
            {
                foreach (var item in Enumerable.Empty<int>()) { }
            }
        }

        public static decimal StaticDecimalProperty
        {
            set
            {
                if (StaticI == 0) StaticS = string.Empty;
            }
        }

        public int IntProperty
        {
            set
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
            }
        }

        public string StringProperty
        {
            set
            {
                i = 0;
                Console.WriteLine(string.Empty);
            }
        }

        public double DoubleProperty
        {
            set
            {
                i = 0;
                S = string.Empty;
            }
        }

        public float FloatProperty
        {
            set
            {
                i = 0;
                S = string.Empty ?? throw new ArgumentNullException("");
            }
        }

        public bool BoolProperty
        {
            set
            {
                foreach (var item in Enumerable.Empty<int>()) { }
            }
        }

        public decimal DecimalProperty
        {
            set
            {
                if (i == 0) S = string.Empty;
            }
        }
    }
}