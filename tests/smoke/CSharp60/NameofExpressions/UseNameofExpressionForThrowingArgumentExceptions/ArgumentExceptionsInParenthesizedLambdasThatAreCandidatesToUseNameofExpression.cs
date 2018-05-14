// ReSharper disable All

// Expected number of suggestions: 38

using System;
using System.ComponentModel;

namespace CSharp71.NameofExpressions.UseNameofExpressionForThrowingArgumentExceptions
{
    public class ArgumentExceptionsInParenthesizedLambdasThatAreCandidatesToUseNameofExpression
    {
        Action<string, string> Lambda01 = (name, s) =>
        {
            throw new ArgumentException("message", "name");
            throw new ArgumentException("message", "name", new Exception());
            throw new System.ArgumentException("message", "name");
            throw new System.ArgumentException("message", "name", new Exception());
        };

        Action<string, string> Lambda01A = (name, s) =>
        {
            void LocalFunction()
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            }
        };

        Action<string, string> Lambda01B = (name, s) =>
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

        Action<string, string> Lambda01C = (name, s) =>
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

        private Action<string, string> Lambda01D = (name, s) =>
        {
            Action a = () =>
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            };
        };

        Action<string, string> Lambda02 = (name, s) =>
        {
            throw new ArgumentNullException("name", "message");
            throw new System.ArgumentNullException("name", "message");
        };

        Action<string, string> Lambda03 = (name, s) =>
        {
            throw new ArgumentOutOfRangeException("name");
            throw new ArgumentOutOfRangeException("name", "message");
            throw new ArgumentOutOfRangeException("name", name, "message");
            throw new System.ArgumentOutOfRangeException("name");
            throw new System.ArgumentOutOfRangeException("name", "message");
            throw new System.ArgumentOutOfRangeException("name", name, "message");
        };

        Action<SomeEnum, string> Lambda04 = (someEnum, s) =>
        {
            throw new InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
            throw new System.ComponentModel.InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
        };
    }
}