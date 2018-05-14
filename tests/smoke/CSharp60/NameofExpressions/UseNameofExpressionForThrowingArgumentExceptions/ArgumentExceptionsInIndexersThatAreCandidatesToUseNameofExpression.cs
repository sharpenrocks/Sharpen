// ReSharper disable All

// Expected number of suggestions: 106

using System;
using System.ComponentModel;

namespace CSharp71.NameofExpressions.UseNameofExpressionForThrowingArgumentExceptions
{
    public class ArgumentExceptionsInIndexersThatAreCandidatesToUseNameofExpression
    {
        int this[string name]
        {
            get
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            }

            set
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new ArgumentException("message", "value");
                throw new ArgumentException("message", "value", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "value");
                throw new System.ArgumentException("message", "value", new Exception());
            }
        }

        int this[string name, string sA]
        {
            get
            {
                return 0;

                void LocalFunction()
                {
                    throw new ArgumentException("message", "name");
                    throw new ArgumentException("message", "name", new Exception());
                    throw new System.ArgumentException("message", "name");
                    throw new System.ArgumentException("message", "name", new Exception());
                }
            }

            set
            {
                void LocalFunction()
                {
                    throw new ArgumentException("message", "name");
                    throw new ArgumentException("message", "name", new Exception());
                    throw new ArgumentException("message", "value");
                    throw new ArgumentException("message", "value", new Exception());
                    throw new System.ArgumentException("message", "name");
                    throw new System.ArgumentException("message", "name", new Exception());
                    throw new System.ArgumentException("message", "value");
                    throw new System.ArgumentException("message", "value", new Exception());
                }
            }
        }

        int this[string name, double dB]
        {
            get
            {
                return 0;

                void LocalFunction(string localName)
                {
                    throw new ArgumentException("message", "name");
                    throw new ArgumentException("message", "name", new Exception());
                    throw new ArgumentException("message", "localName");
                    throw new ArgumentException("message", "localName", new Exception());
                    throw new System.ArgumentException("message", "name");
                    throw new System.ArgumentException("message", "name", new Exception());
                    throw new System.ArgumentException("message", "localName");
                    throw new System.ArgumentException("message", "localName", new Exception());
                }
            }

            set
            {
                void LocalFunction(string localName)
                {
                    throw new ArgumentException("message", "name");
                    throw new ArgumentException("message", "name", new Exception());
                    throw new ArgumentException("message", "value");
                    throw new ArgumentException("message", "value", new Exception());
                    throw new ArgumentException("message", "localName");
                    throw new ArgumentException("message", "localName", new Exception());
                    throw new System.ArgumentException("message", "name");
                    throw new System.ArgumentException("message", "name", new Exception());
                    throw new System.ArgumentException("message", "value");
                    throw new System.ArgumentException("message", "value", new Exception());
                    throw new System.ArgumentException("message", "localName");
                    throw new System.ArgumentException("message", "localName", new Exception());
                }
            }
        }

        int this[string name, long lC]
        {
            get
            {
                return 0;

                void LocalFunction()
                {
                    void NestedLocalFunction(string localName)
                    {
                        throw new ArgumentException("message", "name");
                        throw new ArgumentException("message", "name", new Exception());
                        throw new ArgumentException("message", "localName");
                        throw new ArgumentException("message", "localName", new Exception());
                        throw new System.ArgumentException("message", "name");
                        throw new System.ArgumentException("message", "name", new Exception());
                        throw new System.ArgumentException("message", "localName");
                        throw new System.ArgumentException("message", "localName", new Exception());
                    }
                }
            }

            set
            {
                void LocalFunction()
                {
                    void NestedLocalFunction(string localName)
                    {
                        throw new ArgumentException("message", "name");
                        throw new ArgumentException("message", "name", new Exception());
                        throw new ArgumentException("message", "value");
                        throw new ArgumentException("message", "value", new Exception());
                        throw new ArgumentException("message", "localName");
                        throw new ArgumentException("message", "localName", new Exception());
                        throw new System.ArgumentException("message", "name");
                        throw new System.ArgumentException("message", "name", new Exception());
                        throw new System.ArgumentException("message", "value");
                        throw new System.ArgumentException("message", "value", new Exception());
                        throw new System.ArgumentException("message", "localName");
                        throw new System.ArgumentException("message", "localName", new Exception());
                    }
                }
            }
        }

        int this[string name, decimal dD]
        {
            get
            {
                Action a = () =>
                {
                    throw new ArgumentException("message", "name");
                    throw new ArgumentException("message", "name", new Exception());
                    throw new System.ArgumentException("message", "name");
                    throw new System.ArgumentException("message", "name", new Exception());
                };

                return 0;
            }

            set
            {
                Action a = () =>
                {
                    throw new ArgumentException("message", "name");
                    throw new ArgumentException("message", "name", new Exception());
                    throw new ArgumentException("message", "value");
                    throw new ArgumentException("message", "value", new Exception());
                    throw new System.ArgumentException("message", "name");
                    throw new System.ArgumentException("message", "name", new Exception());
                    throw new System.ArgumentException("message", "value");
                    throw new System.ArgumentException("message", "value", new Exception());
                };
            }
        }

        int this[string name, int a]
        {
            get
            {
                throw new ArgumentNullException("name", "message");
                throw new System.ArgumentNullException("name", "message");
            }

            set
            {
                throw new ArgumentNullException("name", "message");
                throw new ArgumentNullException("value", "message");
                throw new System.ArgumentNullException("name", "message");
                throw new System.ArgumentNullException("value", "message");
            }
        }

        int this[string name, object o]
        {
            get
            {
                throw new ArgumentOutOfRangeException("name");
                throw new ArgumentOutOfRangeException("name", "message");
                throw new ArgumentOutOfRangeException("name", name, "message");
                throw new System.ArgumentOutOfRangeException("name");
                throw new System.ArgumentOutOfRangeException("name", "message");
                throw new System.ArgumentOutOfRangeException("name", name, "message");
            }

            set
            {
                throw new ArgumentOutOfRangeException("name");
                throw new ArgumentOutOfRangeException("name", "message");
                throw new ArgumentOutOfRangeException("name", name, "message");
                throw new ArgumentOutOfRangeException("value");
                throw new ArgumentOutOfRangeException("value", "message");
                throw new ArgumentOutOfRangeException("value", name, "message");
                throw new System.ArgumentOutOfRangeException("name");
                throw new System.ArgumentOutOfRangeException("name", "message");
                throw new System.ArgumentOutOfRangeException("name", name, "message");
                throw new System.ArgumentOutOfRangeException("value");
                throw new System.ArgumentOutOfRangeException("value", "message");
                throw new System.ArgumentOutOfRangeException("value", name, "message");
            }
        }

        SomeEnum this[SomeEnum someEnum]
        {
            get
            {
                throw new InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
                throw new System.ComponentModel.InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
            }

            set
            {
                throw new InvalidEnumArgumentException("someEnum", (int) someEnum, someEnum.GetType());
                throw new InvalidEnumArgumentException("value", (int)value, value.GetType());
                throw new System.ComponentModel.InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
                throw new System.ComponentModel.InvalidEnumArgumentException("value", (int)value, value.GetType());
            }
        }
    }
}