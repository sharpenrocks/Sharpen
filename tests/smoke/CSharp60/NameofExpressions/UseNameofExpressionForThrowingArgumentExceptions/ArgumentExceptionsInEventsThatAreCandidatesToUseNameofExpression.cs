// ReSharper disable All

// Expected number of suggestions: 76

using System;
using System.ComponentModel;

namespace CSharp71.NameofExpressions.UseNameofExpressionForThrowingArgumentExceptions
{
    public class ArgumentExceptionsInEventsThatAreCandidatesToUseNameofExpression
    {
        event EventHandler Event01
        {
            add
            {
                throw new ArgumentException("message", "value");
                throw new ArgumentException("message", "value", new Exception());
                throw new System.ArgumentException("message", "value");
                throw new System.ArgumentException("message", "value", new Exception());
            }
            remove
            {
                throw new ArgumentException("message", "value");
                throw new ArgumentException("message", "value", new Exception());
                throw new System.ArgumentException("message", "value");
                throw new System.ArgumentException("message", "value", new Exception());
            }
        }

        event EventHandler Event01A
        {
            add
            {
                void LocalFunction()
                {
                    throw new ArgumentException("message", "value");
                    throw new ArgumentException("message", "value", new Exception());
                    throw new System.ArgumentException("message", "value");
                    throw new System.ArgumentException("message", "value", new Exception());
                }
            }
            remove
            {
                void LocalFunction()
                {
                    throw new ArgumentException("message", "value");
                    throw new ArgumentException("message", "value", new Exception());
                    throw new System.ArgumentException("message", "value");
                    throw new System.ArgumentException("message", "value", new Exception());
                }
            }
        }


        event EventHandler Event01B
        {
            add
            {
                void LocalFunction(string localValue)
                {
                    throw new ArgumentException("message", "value");
                    throw new ArgumentException("message", "value", new Exception());
                    throw new System.ArgumentException("message", "value");
                    throw new System.ArgumentException("message", "value", new Exception());
                    throw new ArgumentException("message", "localValue");
                    throw new ArgumentException("message", "localValue", new Exception());
                    throw new System.ArgumentException("message", "localValue");
                    throw new System.ArgumentException("message", "localValue", new Exception());
                }
            }
            remove
            {
                void LocalFunction(string localValue)
                {
                    throw new ArgumentException("message", "value");
                    throw new ArgumentException("message", "value", new Exception());
                    throw new System.ArgumentException("message", "value");
                    throw new System.ArgumentException("message", "value", new Exception());
                    throw new ArgumentException("message", "localValue");
                    throw new ArgumentException("message", "localValue", new Exception());
                    throw new System.ArgumentException("message", "localValue");
                    throw new System.ArgumentException("message", "localValue", new Exception());
                }
            }
        }

        event EventHandler Event01C
        {
            add
            {
                void LocalFunction()
                {
                    void NestedLocalFunction(string localValue)
                    {
                        throw new ArgumentException("message", "value");
                        throw new ArgumentException("message", "value", new Exception());
                        throw new System.ArgumentException("message", "value");
                        throw new System.ArgumentException("message", "value", new Exception());
                        throw new ArgumentException("message", "localValue");
                        throw new ArgumentException("message", "localValue", new Exception());
                        throw new System.ArgumentException("message", "localValue");
                        throw new System.ArgumentException("message", "localValue", new Exception());
                    }
                }
            }
            remove
            {
                void LocalFunction()
                {
                    void NestedLocalFunction(string localValue)
                    {
                        throw new ArgumentException("message", "value");
                        throw new ArgumentException("message", "value", new Exception());
                        throw new System.ArgumentException("message", "value");
                        throw new System.ArgumentException("message", "value", new Exception());
                        throw new ArgumentException("message", "localValue");
                        throw new ArgumentException("message", "localValue", new Exception());
                        throw new System.ArgumentException("message", "localValue");
                        throw new System.ArgumentException("message", "localValue", new Exception());
                    }
                }
            }
        }

        private event EventHandler Event01D
        {
            add
            {
                Action a = () =>
                {
                    throw new ArgumentException("message", "value");
                    throw new ArgumentException("message", "value", new Exception());
                    throw new System.ArgumentException("message", "value");
                    throw new System.ArgumentException("message", "value", new Exception());
                };
            }
            remove
            {
                Action a = () =>
                {
                    throw new ArgumentException("message", "value");
                    throw new ArgumentException("message", "value", new Exception());
                    throw new System.ArgumentException("message", "value");
                    throw new System.ArgumentException("message", "value", new Exception());
                };
            }
        }

        event EventHandler Event02
        {
            add
            {
                throw new ArgumentNullException("value", "message");
                throw new System.ArgumentNullException("value", "message");
            }
            remove
            {
                throw new ArgumentNullException("value", "message");
                throw new System.ArgumentNullException("value", "message");
            }
        }

        event EventHandler Event03
        {
            add
            {
                throw new ArgumentOutOfRangeException("value");
                throw new ArgumentOutOfRangeException("value", "message");
                throw new ArgumentOutOfRangeException("value", value, "message");
                throw new System.ArgumentOutOfRangeException("value");
                throw new System.ArgumentOutOfRangeException("value", "message");
                throw new System.ArgumentOutOfRangeException("value", value, "message");
            }
            remove
            {
                throw new ArgumentOutOfRangeException("value");
                throw new ArgumentOutOfRangeException("value", "message");
                throw new ArgumentOutOfRangeException("value", value, "message");
                throw new System.ArgumentOutOfRangeException("value");
                throw new System.ArgumentOutOfRangeException("value", "message");
                throw new System.ArgumentOutOfRangeException("value", value, "message");
            }
        }

        event EventHandler Event04
        {
            add 
            {
                throw new InvalidEnumArgumentException("value", 0, value.GetType());
                throw new System.ComponentModel.InvalidEnumArgumentException("value", 0, value.GetType());
            }
            remove
            {
                throw new InvalidEnumArgumentException("value", 0, value.GetType());
                throw new System.ComponentModel.InvalidEnumArgumentException("value", 0, value.GetType());
            }
        }
    }
}