// ReSharper disable All

using System;
using System.Linq;

namespace CSharp60.UseExpressionBodyForGetOnlyProperties
{
    public class GetOnlyPropertiesThatAreNotCandidatesToHaveExpressionBody
    {
        public string S { get; set; }
        private int i;
        public static string StaticS { get; set; }
        private static int StaticI;

        public static int StaticIntProperty
        {
            get
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
                return 0;
            }
        }

        public static string StaticStringProperty
        {
            get
            {
                StaticI = 0;
                Console.WriteLine(string.Empty);
                return string.Empty;
            }
        }

        public static double StaticDoubleProperty
        {
            get
            {
                StaticI = 0;
                StaticS = string.Empty;
                return 0;
            }
        }

        public static float StaticFloatProperty
        {
            get
            {
                StaticI = 0;
                StaticS = string.Empty ?? throw new ArgumentNullException("");
                return 0;
            }
        }

        public static bool StaticBoolProperty
        {
            get
            {
                foreach (var item in Enumerable.Empty<int>()) { }
                return true;
            }
        }

        public static decimal StaticDecimalProperty
        {
            get
            {
                if (StaticI == 0) StaticS = string.Empty;
                return 0;
            }
        }

        public int IntProperty
        {
            get
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
                return 0;
            }
        }

        public string StringProperty
        {
            get
            {
                i = 0;
                Console.WriteLine(string.Empty);
                return string.Empty;
            }
        }

        public double DoubleProperty
        {
            get
            {
                i = 0;
                S = string.Empty;
                return 0;
            }
        }

        public float FloatProperty
        {
            get
            {
                i = 0;
                S = string.Empty ?? throw new ArgumentNullException("");
                return 0;
            }
        }

        public bool BoolProperty
        {
            get
            {
                foreach (var item in Enumerable.Empty<int>()) { }
                return true;
            }
        }

        public decimal DecimalProperty
        {
            get
            {
                if (i == 0) S = string.Empty;
                return 0;
            }
        }
    }
}