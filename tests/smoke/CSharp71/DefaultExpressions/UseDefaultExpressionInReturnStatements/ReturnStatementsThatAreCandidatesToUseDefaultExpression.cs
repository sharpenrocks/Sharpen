// ReSharper disable All

// Expected number of suggestions: 52

using System;
using System.Collections;
using System.Drawing;

namespace CSharp71.DefaultExpressions.UseDefaultExpressionInReturnStatements
{
    public class ReturnStatementsThatAreCandidatesToUseDefaultExpressionInMethods
    {
        public int ReturnInt01()
        {
            return default(int);
        }

        public System.Int32 ReturnInt02()
        {
            return default(int);
        }

        public int ReturnInt03()
        {
            return default(System.Int32);
        }

        public string ReturnString01()
        {
            return default(string);
        }

        public System.String ReturnString02()
        {
            return default(string);
        }

        public string ReturnString03()
        {
            return default(System.String);
        }

        public IEnumerable ReturnIEnumerable01()
        {
            return default(IEnumerable);
        }

        public System.Collections.IEnumerable ReturnIEnumerable02()
        {
            return default(IEnumerable);
        }

        public IEnumerable ReturnIEnumerable03()
        {
            return default(System.Collections.IEnumerable);
        }

        public Point ReturnPoint01()
        {
            return default(Point);
        }

        public System.Drawing.Point ReturnPoint02()
        {
            return default(Point);
        }

        public Point ReturnPoint03()
        {
            return default(System.Drawing.Point);
        }

        public T0 ReturnT0<T0>()
        {
            return default(T0);
        }
    }

    public class ReturnStatementsThatAreCandidatesToUseDefaultExpressionInPropertyGetters<T0>
    {
        public int IntProperty01
        {
            get { return default(int); }
        }

        public System.Int32 IntProperty02
        {
            get { return default(int); }
        }

        public int IntProperty03
        {
            get { return default(System.Int32); }
        }

        public string StringProperty01
        {
            get { return default(string); }
        }

        public System.String StringProperty02
        {
            get { return default(string); }
        }

        public string StringProperty03
        {
            get { return default(System.String); }
        }

        public IEnumerable IEnumerableProperty01
        {
            get { return default(IEnumerable); }
        }

        public System.Collections.IEnumerable IEnumerableProperty02
        {
            get { return default(IEnumerable); }
        }

        public IEnumerable IEnumerableProperty03
        {
            get { return default(System.Collections.IEnumerable); }
        }

        public Point PointProperty01
        {
            get { return default(Point); }
        }

        public System.Drawing.Point PointProperty02
        {
            get { return default(Point); }
        }

        public Point PointProperty03
        {
            get { return default(System.Drawing.Point); }
        }

        public T0 T0Property
        {
            get { return default(T0); }
        }
    }

    public class ReturnStatementsThatAreCandidatesToUseDefaultExpressionInIndexerGetters<T0>
    {
        public int this[int index]
        {
            get { return default(int); }
        }

        public System.Int32 this[byte index]
        {
            get { return default(int); }
        }

        public int this[long index]
        {
            get { return default(System.Int32); }
        }

        public string this[string index]
        {
            get { return default(string); }
        }

        public System.String this[object index]
        {
            get { return default(string); }
        }

        public string this[Type index]
        {
            get { return default(System.String); }
        }

        public IEnumerable this[IEnumerable index]
        {
            get { return default(IEnumerable); }
        }

        public System.Collections.IEnumerable this[IList index]
        {
            get { return default(IEnumerable); }
        }

        public IEnumerable this[ICollection index]
        {
            get { return default(System.Collections.IEnumerable); }
        }

        public Point this[Point index]
        {
            get { return default(Point); }
        }

        public System.Drawing.Point this[Rectangle index]
        {
            get { return default(Point); }
        }

        public Point this[RectangleF index]
        {
            get { return default(System.Drawing.Point); }
        }

        public T0 this[T0 index]
        {
            get { return default(T0); }
        }
    }

    public class ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0>
    {
        public static int operator +(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, int second)
        {
            return default(int);
        }

        public static System.Int32 operator -(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, int second)
        {
            return default(int);
        }

        public static int operator *(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, int second)
        {
            return default(System.Int32);
        }

        public static string operator +(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, string second)
        {
            return default(string);
        }

        public static System.String operator -(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, string second)
        {
            return default(string);
        }

        public static string operator *(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, string second)
        {
            return default(System.String);
        }

        public static IEnumerable operator +(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, IEnumerable second)
        {
            return default(IEnumerable);
        }

        public static System.Collections.IEnumerable operator -(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, IEnumerable second)
        {
            return default(IEnumerable);
        }

        public static IEnumerable operator *(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, IEnumerable second)
        {
            return default(System.Collections.IEnumerable);
        }

        public static Point operator +(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, Point second)
        {
            return default(Point);
        }

        public static System.Drawing.Point operator -(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, Point second)
        {
            return default(Point);
        }

        public static Point operator *(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, Point second)
        {
            return default(System.Drawing.Point);
        }

        public static T0 operator +(ReturnStatementsThatAreCandidatesToUseDefaultExpressionInOperators<T0> first, T0 second)
        {
            return default(T0);
        }
    }
}