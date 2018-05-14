// ReSharper disable All

// Expected number of suggestions: 42

using System;
using System.ComponentModel;

namespace CSharp71.NameofExpressions.UseNameofExpressionForThrowingArgumentExceptions
{
    public class ArgumentExceptionsInMethodsThatAreCandidatesToUseNameofExpression
    {
        void Invocation01(string name)
        {
            throw new ArgumentException("message", "name");
            throw new ArgumentException("message", "name", new Exception());
            throw new System.ArgumentException("message", "name");
            throw new System.ArgumentException("message", "name", new Exception());
        }

        void Invocation01A(string name)
        {
            void LocalFunction()
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            }
        }

        void Invocation01B(string name)
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

        void Invocation01C(string name)
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

        void Invocation01D(string name)
        {
            Action a = () =>
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            };
        }

        void Invocation01E(string name)
        {
            throw new ArgumentException("message", paramName : "name");
            throw new ArgumentException("message", paramName: "name", innerException : new Exception());
            throw new System.ArgumentException("message", paramName: "name");
            throw new System.ArgumentException("message", paramName: "name", innerException: new Exception());
        }

        void Invocation02(string name)
        {
            throw new ArgumentNullException("name", "message");
            throw new System.ArgumentNullException("name", "message");
        }

        void Invocation03(string name)
        {
            throw new ArgumentOutOfRangeException("name");
            throw new ArgumentOutOfRangeException("name", "message");
            throw new ArgumentOutOfRangeException("name", name, "message");
            throw new System.ArgumentOutOfRangeException("name");
            throw new System.ArgumentOutOfRangeException("name", "message");
            throw new System.ArgumentOutOfRangeException("name", name, "message");
        }

        void Invocation04(SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException("someEnum", (int) someEnum, someEnum.GetType());
            throw new System.ComponentModel.InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
        }
    }
}