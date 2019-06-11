namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareReferenceFieldAsNullable
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
