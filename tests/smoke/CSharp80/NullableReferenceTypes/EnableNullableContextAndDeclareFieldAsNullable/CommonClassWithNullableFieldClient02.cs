namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareFieldAsNullable
{
    class CommonClassWithNullableFieldClient02
    {
        public void UseCommonClassWithNullableField()
        {
            var cc = new CommonClassWithNullableField();
            cc.nullableFieldThatShouldAppearOnlyOnce = null;
        }
    }
}
