namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareReferenceFieldAsNullable
{
    class CommonClassWithNullableFieldClient03
    {
        public void UseCommonClassWithNullableField()
        {
            var cc = new CommonClassWithNullableField();
            cc.nullableFieldThatShouldAppearOnlyOnce = null;
        }
    }
}
