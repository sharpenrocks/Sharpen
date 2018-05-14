// ReSharper disable All

// Expected number of suggestions: 38

using System;
using System.ComponentModel;

namespace CSharp71.NameofExpressions.UseNameofExpressionForThrowingArgumentExceptions
{
    public class ArgumentExceptionsInConstructorsThatAreCandidatesToUseNameofExpression
    {
        ArgumentExceptionsInConstructorsThatAreCandidatesToUseNameofExpression(string name)
        {
            throw new ArgumentException("message", "name");
            throw new ArgumentException("message", "name", new Exception());
            throw new System.ArgumentException("message", "name");
            throw new System.ArgumentException("message", "name", new Exception());
        }

        ArgumentExceptionsInConstructorsThatAreCandidatesToUseNameofExpression(string name, string sA)
        {
            void LocalFunction()
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            }
        }

        ArgumentExceptionsInConstructorsThatAreCandidatesToUseNameofExpression(string name, double dB)
        {
            void LocalFunction(string localName)
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
                throw new ArgumentException("message", "localName");
                throw new ArgumentException("message", "localName", new Exception());
                throw new System.ArgumentException("message", "localName");
                throw new System.ArgumentException("message", "localName", new Exception());
            }
        }

        ArgumentExceptionsInConstructorsThatAreCandidatesToUseNameofExpression(string name, long lC)
        {
            void LocalFunction()
            {
                void NestedLocalFunction(string localName)
                {
                    throw new ArgumentException("message", "name");
                    throw new ArgumentException("message", "name", new Exception());
                    throw new System.ArgumentException("message", "name");
                    throw new System.ArgumentException("message", "name", new Exception());
                    throw new ArgumentException("message", "localName");
                    throw new ArgumentException("message", "localName", new Exception());
                    throw new System.ArgumentException("message", "localName");
                    throw new System.ArgumentException("message", "localName", new Exception());
                }
            }
        }

        ArgumentExceptionsInConstructorsThatAreCandidatesToUseNameofExpression(string name, decimal dD)
        {
            Action a = () =>
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            };
        }

        ArgumentExceptionsInConstructorsThatAreCandidatesToUseNameofExpression(string name, int a)
        {
            throw new ArgumentNullException("name", "message");
            throw new System.ArgumentNullException("name", "message");
        }

        ArgumentExceptionsInConstructorsThatAreCandidatesToUseNameofExpression(string name, object o)
        {
            throw new ArgumentOutOfRangeException("name");
            throw new ArgumentOutOfRangeException("name", "message");
            throw new ArgumentOutOfRangeException("name", name, "message");
            throw new System.ArgumentOutOfRangeException("name");
            throw new System.ArgumentOutOfRangeException("name", "message");
            throw new System.ArgumentOutOfRangeException("name", name, "message");
        }

        ArgumentExceptionsInConstructorsThatAreCandidatesToUseNameofExpression(SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
            throw new System.ComponentModel.InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
        }
    }
}