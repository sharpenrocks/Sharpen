// ReSharper disable All

// Expected number of suggestions: 38

using System;
using System.ComponentModel;

namespace CSharp71.NameofExpressions.UseNameofExpressionForThrowingArgumentExceptions
{
    public class ArgumentExceptionsInAnonymousDelegatesThatAreCandidatesToUseNameofExpression
    {
        Action<string> Delegate01 = delegate (string name)
        {
            throw new ArgumentException("message", "name");
            throw new ArgumentException("message", "name", new Exception());
            throw new System.ArgumentException("message", "name");
            throw new System.ArgumentException("message", "name", new Exception());
        };

        Action<string> Delegate01A = delegate (string name)
        {
            void LocalFunction()
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            }
        };

        Action<string> Delegate01B = delegate (string name)
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
        };

        Action<string> Delegate01C = delegate (string name)
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
        };

        private Action<string> Delegate01D = delegate (string name)
        {
            Action a = () =>
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            };
        };

        Action<string> Delegate02 = delegate (string name)
        {
            throw new ArgumentNullException("name", "message");
            throw new System.ArgumentNullException("name", "message");
        };

        Action<string> Delegate03 = delegate (string name)
        {
            throw new ArgumentOutOfRangeException("name");
            throw new ArgumentOutOfRangeException("name", "message");
            throw new ArgumentOutOfRangeException("name", name, "message");
            throw new System.ArgumentOutOfRangeException("name");
            throw new System.ArgumentOutOfRangeException("name", "message");
            throw new System.ArgumentOutOfRangeException("name", name, "message");
        };

        Action<SomeEnum> Delegate04 = delegate (SomeEnum someEnum)
        {
            throw new InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
            throw new System.ComponentModel.InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
        };
    }
}