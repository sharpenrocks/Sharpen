// ReSharper disable All

// Expected number of suggestions: 38

using System;
using System.ComponentModel;

namespace CSharp71.NameofExpressions.UseNameofExpressionForThrowingArgumentExceptions
{
    public class ArgumentExceptionsInSimpleLambdasThatAreCandidatesToUseNameofExpression
    {
        Action<string> Lambda01 = name =>
        {
            throw new ArgumentException("message", "name");
            throw new ArgumentException("message", "name", new Exception());
            throw new System.ArgumentException("message", "name");
            throw new System.ArgumentException("message", "name", new Exception());
        };

        Action<string> Lambda01A = name =>
        {
            void LocalFunction()
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            }
        };

        Action<string> Lambda01B = name =>
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

        Action<string> Lambda01C = name =>
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

        private Action<string> Lambda01D = name =>
        {
            Action a = () =>
            {
                throw new ArgumentException("message", "name");
                throw new ArgumentException("message", "name", new Exception());
                throw new System.ArgumentException("message", "name");
                throw new System.ArgumentException("message", "name", new Exception());
            };
        };

        Action<string> Lambda02 = name =>
        {
            throw new ArgumentNullException("name", "message");
            throw new System.ArgumentNullException("name", "message");
        };

        Action<string> Lambda03 = name =>
        {
            throw new ArgumentOutOfRangeException("name");
            throw new ArgumentOutOfRangeException("name", "message");
            throw new ArgumentOutOfRangeException("name", name, "message");
            throw new System.ArgumentOutOfRangeException("name");
            throw new System.ArgumentOutOfRangeException("name", "message");
            throw new System.ArgumentOutOfRangeException("name", name, "message");
        };

        Action<SomeEnum> Lambda04 = someEnum =>
        {
            throw new InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
            throw new System.ComponentModel.InvalidEnumArgumentException("someEnum", (int)someEnum, someEnum.GetType());
        };
    }
}