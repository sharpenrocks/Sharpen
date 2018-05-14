// ReSharper disable All

// Expected number of suggestions: 38

using System;
using System.ComponentModel;

namespace CSharp71.NameofExpressions.UseNameofExpressionForThrowingArgumentExceptions
{
    public class ArgumentExceptionsInPropertiesThatAreCandidatesToUseNameofExpression
    {
        string Property01
        {
            set
            {
                throw new ArgumentException("message", "value");
                throw new ArgumentException("message", "value", new Exception());
                throw new System.ArgumentException("message", "value");
                throw new System.ArgumentException("message", "value", new Exception());
            }
        }

        string Property01A
        {
            set
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

        string Property01B
        {
            set
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

        string Property01C
        {
            set
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

        string Property01D
        {
            set
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

        string Property02
        {
            set
            {
                throw new ArgumentNullException("value", "message");
                throw new System.ArgumentNullException("value", "message");
            }
        }

        string Property03
        {
            set
            {
                throw new ArgumentOutOfRangeException("value");
                throw new ArgumentOutOfRangeException("value", "message");
                throw new ArgumentOutOfRangeException("value", value, "message");
                throw new System.ArgumentOutOfRangeException("value");
                throw new System.ArgumentOutOfRangeException("value", "message");
                throw new System.ArgumentOutOfRangeException("value", value, "message");
            }
        }

        SomeEnum Property04
        {
            set
            {
                throw new InvalidEnumArgumentException("value", (int) value, value.GetType());
                throw new System.ComponentModel.InvalidEnumArgumentException("value", (int)value, value.GetType());
            }
        }
    }
}