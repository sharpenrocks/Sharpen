namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclarePropertyAsNullable
{
    class CommonClassWithNullablePropertyClient01
    {
        public void UseCommonClassWithNullableProperty()
        {
            var cc = new CommonClassWithNullableProperty();
            cc.NullablePropertyThatShouldAppearOnlyOnce = null;
        }
    }
}
