namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareFieldAsNullable
{
    class ClassWithNullableFieldsAndPropertiesUsedSomewhereElseClient
    {
        public void UseCommonClassWithNullableFieldsAndProperties()
        {
            var cc = new ClassWithNullableFieldsAndPropertiesUsedSomewhereElse();
            cc.nullableField = null;
            cc.NullableProperty = null;
        }
    }
}
