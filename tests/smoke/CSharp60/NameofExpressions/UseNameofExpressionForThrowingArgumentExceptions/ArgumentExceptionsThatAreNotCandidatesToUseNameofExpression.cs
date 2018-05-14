// ReSharper disable All

using System;
using System.ComponentModel;

namespace CSharp71.NameofExpressions.UseNameofExpressionForThrowingArgumentExceptions
{
    public class ArgumentExceptionsThatHaveMisspelledParameterNames
    {
        void Invocation01(string name)
        {
            throw new ArgumentException("message", "namex");
            throw new ArgumentException("message", "namex", new Exception());
        }

        void Invocation02(string name)
        {
            throw new ArgumentNullException("namex", "message");
        }

        void Invocation03(string name)
        {
            throw new ArgumentOutOfRangeException("namex");
            throw new ArgumentOutOfRangeException("namex", "message");
            throw new ArgumentOutOfRangeException("namex", name, "message");
        }

        void Invocation04(SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException("someEnumx", (int) someEnum, someEnum.GetType());
        }

        ArgumentExceptionsThatHaveMisspelledParameterNames(string name)
        {
            throw new ArgumentException("message", "namex");
            throw new ArgumentException("message", "namex", new Exception());
        }


        ArgumentExceptionsThatHaveMisspelledParameterNames(string name, int a)
        {
            throw new ArgumentNullException("namex", "message");
        }

        ArgumentExceptionsThatHaveMisspelledParameterNames(string name, object o)
        {
            throw new ArgumentOutOfRangeException("namex");
            throw new ArgumentOutOfRangeException("namex", "message");
            throw new ArgumentOutOfRangeException("namex", name, "message");
        }

        ArgumentExceptionsThatHaveMisspelledParameterNames(SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException("someEnumx", (int)someEnum, someEnum.GetType());
        }

        string Property01
        {
            set
            {
                throw new ArgumentException("message", "valuex");
                throw new ArgumentException("message", "valuex", new Exception());
            }
        }


        string Property02
        {
            set
            {
                throw new ArgumentNullException("valuex", "message");
            }
        }

        string Property03
        {
            set
            {
                throw new ArgumentOutOfRangeException("valuex");
                throw new ArgumentOutOfRangeException("valuex", "message");
                throw new ArgumentOutOfRangeException("valuex", value, "message");
            }
        }

        SomeEnum Property04
        {
            set
            {
                throw new InvalidEnumArgumentException("valuex", (int)value, value.GetType());
            }
        }

        int this[string name]
        {
            set
            {
                throw new ArgumentException("message", "namex");
                throw new ArgumentException("message", "namex", new Exception());
                throw new ArgumentException("message", "valuex");
                throw new ArgumentException("message", "valuex", new Exception());
            }
        }

        int this[string name, int a]
        {
            set
            {
                throw new ArgumentNullException("namex", "message");
                throw new ArgumentNullException("valuex", "message");
            }
        }

        int this[string name, object o]
        {
            set
            {
                throw new ArgumentOutOfRangeException("namex");
                throw new ArgumentOutOfRangeException("namex", "message");
                throw new ArgumentOutOfRangeException("namex", name, "message");
            }
        }

        int this[SomeEnum someEnum]
        {
            set
            {
                throw new InvalidEnumArgumentException("someEnumx", (int)someEnum, someEnum.GetType());
            }
        }

        Action<string> Lambda01 = name =>
        {
            throw new ArgumentException("message", "namex");
            throw new ArgumentException("message", "namex", new Exception());
        };

        Action<string> Lambda02 = name =>
        {
            throw new ArgumentNullException("namex", "message");
        };

        Action<string> Lambda03 = name =>
        {
            throw new ArgumentOutOfRangeException("namex");
            throw new ArgumentOutOfRangeException("namex", "message");
            throw new ArgumentOutOfRangeException("namex", name, "message");
        };

        Action<SomeEnum> Lambda04 = someEnum =>
        {
            throw new InvalidEnumArgumentException("someEnumx", (int) someEnum, someEnum.GetType());
        };

        Action<string> Delegate01 = delegate (string name)
        {
            throw new ArgumentException("message", "namex");
            throw new ArgumentException("message", "namex", new Exception());
        };

        Action<string> Delegate02 = delegate (string name)
        {
            throw new ArgumentNullException("namex", "message");
        };

        Action<string> Delegate03 = delegate (string name)
        {
            throw new ArgumentOutOfRangeException("namex");
            throw new ArgumentOutOfRangeException("namex", "message");
            throw new ArgumentOutOfRangeException("namex", name, "message");
        };

        Action<SomeEnum> Delegate04 = delegate (SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException("someEnumx", (int)someEnum, someEnum.GetType());
        };

        event EventHandler Event01
        {
            add
            {
                throw new ArgumentException("message", "valuex");
                throw new ArgumentException("message", "valuex", new Exception());
            }
            remove
            {
                throw new ArgumentException("message", "valuex");
                throw new ArgumentException("message", "valuex", new Exception());
            }
        }

        event EventHandler Event02
        {
            add
            {
                throw new ArgumentNullException("valuex", "message");
            }
            remove
            {
                throw new ArgumentNullException("valuex", "message");
            }
        }

        event EventHandler Event03
        {
            add
            {
                throw new ArgumentOutOfRangeException("valuex");
                throw new ArgumentOutOfRangeException("valuex", "message");
                throw new ArgumentOutOfRangeException("valuex", value, "message");
            }
            remove
            {
                throw new ArgumentOutOfRangeException("valuex");
                throw new ArgumentOutOfRangeException("valuex", "message");
                throw new ArgumentOutOfRangeException("valuex", value, "message");
            }
        }

        event EventHandler Event04
        {
            add
            {
                throw new InvalidEnumArgumentException("valuex", 0, value.GetType());
            }
            remove
            {
                throw new InvalidEnumArgumentException("valuex", 0, value.GetType());
            }
        }
    }

    public class ArgumentExceptionsThatAlreadyUseNameofExpression
    {
        void Invocation01(string name)
        {
            throw new ArgumentException("message", nameof(name));
            throw new ArgumentException("message", nameof(name), new Exception());
        }    

        void Invocation02(string name)
        {
            throw new ArgumentNullException(nameof(name), "message");
        }

        void Invocation03(string name)
        {
            throw new ArgumentOutOfRangeException(nameof(name));
            throw new ArgumentOutOfRangeException(nameof(name), "message");
            throw new ArgumentOutOfRangeException(nameof(name), name, "message");
        }

        void Invocation04(SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException(nameof(someEnum), (int)someEnum, someEnum.GetType());
        }

        ArgumentExceptionsThatAlreadyUseNameofExpression(string name)
        {
            throw new ArgumentException("message", nameof(name));
            throw new ArgumentException("message", nameof(name), new Exception());
        }


        ArgumentExceptionsThatAlreadyUseNameofExpression(string name, int a)
        {
            throw new ArgumentNullException(nameof(name), "message");
        }

        ArgumentExceptionsThatAlreadyUseNameofExpression(string name, object o)
        {
            throw new ArgumentOutOfRangeException(nameof(name));
            throw new ArgumentOutOfRangeException(nameof(name), "message");
            throw new ArgumentOutOfRangeException(nameof(name), name, "message");
        }

        ArgumentExceptionsThatAlreadyUseNameofExpression(SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException(nameof(someEnum), (int)someEnum, someEnum.GetType());
        }

        string Property01
        {
            set
            {
                throw new ArgumentException("message", nameof(value));
                throw new ArgumentException("message", nameof(value), new Exception());
            }
        }


        string Property02
        {
            set
            {
                throw new ArgumentNullException(nameof(value), "message");
            }
        }

        string Property03
        {
            set
            {
                throw new ArgumentOutOfRangeException(nameof(value));
                throw new ArgumentOutOfRangeException(nameof(value), "message");
                throw new ArgumentOutOfRangeException(nameof(value), value, "message");
            }
        }

        SomeEnum Property04
        {
            set
            {
                throw new InvalidEnumArgumentException(nameof(value), (int)value, value.GetType());
            }
        }

        int this[string name]
        {
            set
            {
                throw new ArgumentException("message", nameof(name));
                throw new ArgumentException("message", nameof(name), new Exception());
                throw new ArgumentException("message", nameof(value));
                throw new ArgumentException("message", nameof(value), new Exception());
            }
        }

        int this[string name, int a]
        {
            set
            {
                throw new ArgumentNullException(nameof(name), "message");
                throw new ArgumentNullException(nameof(value), "message");
            }
        }

        int this[string name, object o]
        {
            set
            {
                throw new ArgumentOutOfRangeException(nameof(name));
                throw new ArgumentOutOfRangeException(nameof(name), "message");
                throw new ArgumentOutOfRangeException(nameof(name), name, "message");
                throw new ArgumentOutOfRangeException(nameof(value));
                throw new ArgumentOutOfRangeException(nameof(value), "message");
                throw new ArgumentOutOfRangeException(nameof(value), value, "message");
            }
        }

        SomeEnum this[SomeEnum someEnum]
        {
            set
            {
                throw new InvalidEnumArgumentException(nameof(someEnum), (int)someEnum, someEnum.GetType());
                throw new InvalidEnumArgumentException(nameof(value), (int)value, value.GetType());
            }
        }

        Action<string> Lambda01 = name =>
        {
            throw new ArgumentException("message", nameof(name));
            throw new ArgumentException("message", nameof(name), new Exception());
        };

        Action<string> Lambda02 = name =>
        {
            throw new ArgumentNullException(nameof(name), "message");
        };

        Action<string> Lambda03 = name =>
        {
            throw new ArgumentOutOfRangeException(nameof(name));
            throw new ArgumentOutOfRangeException(nameof(name), "message");
            throw new ArgumentOutOfRangeException(nameof(name), name, "message");
        };

        Action<SomeEnum> Lambda04 = someEnum =>
        {
            throw new InvalidEnumArgumentException(nameof(someEnum), (int)someEnum, someEnum.GetType());
        };

        Action<string> Delegate01 = delegate (string name)
        {
            throw new ArgumentException("message", nameof(name));
            throw new ArgumentException("message", nameof(name), new Exception());
        };

        Action<string> Delegate02 = delegate (string name)
        {
            throw new ArgumentNullException(nameof(name), "message");
        };

        Action<string> Delegate03 = delegate (string name)
        {
            throw new ArgumentOutOfRangeException(nameof(name));
            throw new ArgumentOutOfRangeException(nameof(name), "message");
            throw new ArgumentOutOfRangeException(nameof(name), name, "message");
        };

        Action<SomeEnum> Delegate04 = delegate (SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException(nameof(someEnum), (int)someEnum, someEnum.GetType());
        };

        event EventHandler Event01
        {
            add
            {
                throw new ArgumentException("message", nameof(value));
                throw new ArgumentException("message", nameof(value), new Exception());
            }
            remove
            {
                throw new ArgumentException("message", nameof(value));
                throw new ArgumentException("message", nameof(value), new Exception());
            }
        }

        event EventHandler Event02
        {
            add
            {
                throw new ArgumentNullException(nameof(value), "message");
            }
            remove
            {
                throw new ArgumentNullException(nameof(value), "message");
            }
        }

        event EventHandler Event03
        {
            add
            {
                throw new ArgumentOutOfRangeException(nameof(value));
                throw new ArgumentOutOfRangeException(nameof(value), "message");
                throw new ArgumentOutOfRangeException(nameof(value), value, "message");
            }
            remove
            {
                throw new ArgumentOutOfRangeException(nameof(value));
                throw new ArgumentOutOfRangeException(nameof(value), "message");
                throw new ArgumentOutOfRangeException(nameof(value), value, "message");
            }
        }

        event EventHandler Event04
        {
            add
            {
                throw new InvalidEnumArgumentException(nameof(value), 0, value.GetType());
            }
            remove
            {
                throw new InvalidEnumArgumentException(nameof(value), 0, value.GetType());
            }
        }
    }

    public class ArgumentExceptionsThatHaveParameterNamesAsNonParamNameArgument
    {
        void Invocation01(string name)
        {
            throw new ArgumentException("name", "message");
            throw new ArgumentException("name", "message", new Exception());
        }

        void Invocation02(string name)
        {
            throw new ArgumentNullException("message", "name");
        }

        void Invocation03(string name)
        {
            throw new ArgumentOutOfRangeException("message", "name");
            throw new ArgumentOutOfRangeException("message", name, "name");
        }

        void Invocation04(SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException("someEnum");
            throw new InvalidEnumArgumentException("someEnum", new Exception());
        }

        ArgumentExceptionsThatHaveParameterNamesAsNonParamNameArgument(string name)
        {
            throw new ArgumentException("name", "message");
            throw new ArgumentException("name", "message", new Exception());
        }


        ArgumentExceptionsThatHaveParameterNamesAsNonParamNameArgument(string name, int a)
        {
            throw new ArgumentNullException("message", "name");
        }

        ArgumentExceptionsThatHaveParameterNamesAsNonParamNameArgument(string name, object o)
        {
            throw new ArgumentOutOfRangeException("message");
            throw new ArgumentOutOfRangeException("message", "name");
            throw new ArgumentOutOfRangeException("message", name, "name");
        }

        ArgumentExceptionsThatHaveParameterNamesAsNonParamNameArgument(SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException("someEnum");
            throw new InvalidEnumArgumentException("someEnum", new Exception());
        }

        string Property01
        {
            set
            {
                throw new ArgumentException("value", "message");
                throw new ArgumentException("value", "message", new Exception());
            }
        }


        string Property02
        {
            set
            {
                throw new ArgumentNullException("message", "value");
            }
        }

        string Property03
        {
            set
            {
                throw new ArgumentOutOfRangeException("message", "value");
                throw new ArgumentOutOfRangeException("message", value, "value");
            }
        }

        SomeEnum Property04
        {
            set
            {
                throw new InvalidEnumArgumentException("value");
                throw new InvalidEnumArgumentException("value", new Exception());
            }
        }

        int this[string name]
        {
            set
            {
                throw new ArgumentException("name", "message");
                throw new ArgumentException("name", "message", new Exception());
                throw new ArgumentException("value", "message");
                throw new ArgumentException("value", "message", new Exception());
            }
        }

        int this[string name, int a]
        {
            set
            {
                throw new ArgumentNullException("message", "name");
                throw new ArgumentNullException("message", "value");
            }
        }

        int this[string name, object o]
        {
            set
            {
                throw new ArgumentOutOfRangeException("message", "name");
                throw new ArgumentOutOfRangeException("message", name, "name");
            }
        }

        int this[SomeEnum someEnum]
        {
            set
            {
                throw new InvalidEnumArgumentException("someEnum");
                throw new InvalidEnumArgumentException("someEnum", new Exception());
                throw new InvalidEnumArgumentException("value");
                throw new InvalidEnumArgumentException("value", new Exception());
            }
        }

        Action<string> Lambda01 = name =>
        {
            throw new ArgumentException("name", "message");
            throw new ArgumentException("name", "message", new Exception());
        };

        Action<string> Lambda02 = name =>
        {
            throw new ArgumentNullException("message", "name");
        };

        Action<string> Lambda03 = name =>
        {
            throw new ArgumentOutOfRangeException("message", "name");
            throw new ArgumentOutOfRangeException("message", name, "name");
        };

        Action<SomeEnum> Lambda04 = someEnum =>
        {
            throw new InvalidEnumArgumentException("someEnum");
            throw new InvalidEnumArgumentException("someEnum", new Exception());
        };

        Action<string> Delegate01 = delegate (string name)
        {
            throw new ArgumentException("name", "message");
            throw new ArgumentException("name", "message", new Exception());
        };

        Action<string> Delegate02 = delegate (string name)
        {
            throw new ArgumentNullException("message", "name");
        };

        Action<string> Delegate03 = delegate (string name)
        {
            throw new ArgumentOutOfRangeException("message", "name");
            throw new ArgumentOutOfRangeException("message", name, "name");
        };

        Action<SomeEnum> Delegate04 = delegate (SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException("someEnum");
            throw new InvalidEnumArgumentException("someEnum", new Exception());
        };

        event EventHandler Event01
        {
            add
            {
                throw new ArgumentException("value", "message");
                throw new ArgumentException("value", "message", new Exception());
            }
            remove
            {
                throw new ArgumentException("value", "message");
                throw new ArgumentException("value", "message", new Exception());
            }
        }

        event EventHandler Event02
        {
            add
            {
                throw new ArgumentNullException("message", "value");
            }
            remove
            {
                throw new ArgumentNullException("message", "value");
            }
        }

        event EventHandler Event03
        {
            add
            {
                throw new ArgumentOutOfRangeException("message", "value");
                throw new ArgumentOutOfRangeException("message", value, "value");
            }
            remove
            {
                throw new ArgumentOutOfRangeException("message", "value");
                throw new ArgumentOutOfRangeException("message", value, "value");
            }
        }

        event EventHandler Event04
        {
            add
            {
                throw new InvalidEnumArgumentException("value");
                throw new InvalidEnumArgumentException("value", new Exception());
            }
            remove
            {
                throw new InvalidEnumArgumentException("value");
                throw new InvalidEnumArgumentException("value", new Exception());
            }
        }
    }

    public class ThrowingNonArgumentExceptions
    {
        void Invocation01(string name)
        {
            throw new Exception("name");
            throw new Exception("name", new Exception());
        }
    }

    public class ThrowingExceptionsWithoutObjectCreation
    {
        void Invocation01(string name)
        {
            throw CreateException("name");
        }

        ArgumentException CreateException(string paramName)
        {
            return new ArgumentException();
        }
    }

    public class ThrowingNonArgumentExceptionsWithTheSameNameAsArgumentExceptions
    {
        public class ArgumentException : Exception
        {
            public ArgumentException(string paramName) { }
        }

        public class ArgumentNullException : Exception
        {
            public ArgumentNullException(string paramName) { }
        }

        public class ArgumentOutOfRangeException : Exception
        {
            public ArgumentOutOfRangeException(string paramName) { }
        }

        public class InvalidEnumArgumentException : Exception
        {
            public InvalidEnumArgumentException(string paramName) { }
        }

        void Invocation01(string name)
        {
            throw new ArgumentException("name");
            throw new ArgumentNullException("name");
            throw new ArgumentOutOfRangeException("name");
            throw new InvalidEnumArgumentException("name");
        }
    }
}