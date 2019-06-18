// ReSharper disable All

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareFieldAsNullable
{
    public class ClassFieldCannotBeDeclaredAsNullableNotDeclaredInCode
    {
        public void FieldIsNullableForDifferentReasons()
        {
            string dummy;

            if (string.Empty == null) return;
            if (null == string.Empty) return;            
            if (string.Empty != null) return;
            if (null != string.Empty) return;
            if (string.Empty == null) return;
            if (null == string.Empty) return;

            string.Empty?.Length.ToString();

            dummy = string.Empty ?? string.Empty;
        }
    }
}