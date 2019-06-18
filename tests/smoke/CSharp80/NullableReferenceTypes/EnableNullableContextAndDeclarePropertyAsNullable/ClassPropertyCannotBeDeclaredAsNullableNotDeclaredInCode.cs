// ReSharper disable All

using System;
using System.Net.Http;

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclarePropertyAsNullable
{
    public class ClassPropertyCannotBeDeclaredAsNullableNotDeclaredInCode
    {
        public void PropertyIsNullableForDifferentReasons()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = null;

            if (httpClient.BaseAddress == null) return;
            if (null == httpClient.BaseAddress) return;            
            if (httpClient.BaseAddress != null) return;
            if (null != httpClient.BaseAddress) return;
            if (httpClient.BaseAddress == null) return;
            if (null == httpClient.BaseAddress) return;

            httpClient.BaseAddress?.ToString();

            var dummy = httpClient.BaseAddress ?? new Uri("");
        }
    }
}