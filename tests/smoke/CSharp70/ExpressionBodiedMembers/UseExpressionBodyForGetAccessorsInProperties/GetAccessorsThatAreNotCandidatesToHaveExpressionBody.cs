// ReSharper disable All

using System;
using System.Linq;

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForGetAccessorsInProperties
{
    public class GetAccessorsThatAreNotCandidatesToHaveExpressionBody
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
            set { }
        }

        public static string StaticStringProperty
        {
            get
            {
                StaticI = 0;
                Console.WriteLine(string.Empty);
                return string.Empty;
            }
            set { }
        }

        public static double StaticDoubleProperty
        {
            get
            {
                StaticI = 0;
                StaticS = string.Empty;
                return 0;
            }
            set { }
        }

        public static float StaticFloatProperty
        {
            get
            {
                StaticI = 0;
                StaticS = string.Empty ?? throw new ArgumentNullException("");
                return 0;
            }
            set { }
        }

        public static bool StaticBoolProperty
        {
            get
            {
                foreach (var item in Enumerable.Empty<int>()) { }
                return true;
            }
            set { }
        }

        public static decimal StaticDecimalProperty
        {
            get
            {
                if (StaticI == 0) StaticS = string.Empty;
                return 0;
            }
            set { }
        }

        public int IntProperty
        {
            get
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
                return 0;
            }
            set { }
        }

        public string StringProperty
        {
            get
            {
                i = 0;
                Console.WriteLine(string.Empty);
                return string.Empty;
            }
            set { }
        }

        public double DoubleProperty
        {
            get
            {
                i = 0;
                S = string.Empty;
                return 0;
            }
            set { }
        }

        public float FloatProperty
        {
            get
            {
                i = 0;
                S = string.Empty ?? throw new ArgumentNullException("");
                return 0;
            }
            set { }
        }

        public bool BoolProperty
        {
            get
            {
                foreach (var item in Enumerable.Empty<int>()) { }
                return true;
            }
            set { }
        }

        public decimal DecimalProperty
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
        // Basically, they should be converted to property with expression body, without the get keyword ;-)
        public string S { get; }
        private int i;

        public int IntProperty
        {
            get { return i; }
        }
        public string StringProperty
        {
            get { return S ?? throw new ArgumentNullException(nameof(S)); }
        }
        public double DoubleProperty
        {
            get { return Convert.ToDouble(S.ToUpper().ToLower()); }
        }
    }
}