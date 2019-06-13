namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareFieldAsNullable
{
    class CommonClassWithNullableFieldClient01
    {
        public void UseCommonClassWithNullableField()
        {
            var cc = new CommonClassWithNullableField();
            cc.nullableFieldThatShouldAppearOnlyOnce = null;
        }
    }
}
