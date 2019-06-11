// ReSharper disable All

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareReferenceFieldAsNullable
{
    public class ReferenceFieldCannotBeDeclaredAsNullableNeverSurelyNullable
    {
        private string detectedNever = string.Empty;

        private string intializedToNonNull = string.Empty;
        private string initializedToResultOfCast = (string)string.Empty;

        private string a, bAssignedNonNull, c;
        private string d, e, fInitializedToEmptyString = string.Empty;
        private string gInitializedToResultOfCast = (string)string.Empty, h, i;

        private string assignedNonNull;
        private string comparedEqualToNonNullOnLeft;
        private string comparedEqualToNonNullOnRight;
        private string comparedNotEqualToNonNullOnLeft;
        private string comparedNotEqualToNonNullOnRight;
        private string assignedResultOfCast;

        private string assignedNonNullUsingThis;
        private string comparedEqualToNonNullOnLeftUsingThis;
        private string comparedEqualToNonNullOnRightUsingThis;
        private string comparedNotEqualToNonNullOnLeftUsingThis;
        private string comparedNotEqualToNonNullOnRightUsingThis;
        private string assignedResultOfCastUsingThis;

        private static string StaticAssignedNonNull;
        private static string StaticComparedEqualToNonNullOnLeft;
        private static string StaticComparedEqualToNonNullOnRight;
        private static string StaticComparedNotEqualToNonNullOnLeft;
        private static string StaticComparedNotEqualToNonNullOnRight;
        private static string StaticAssignedResultOfCast;

        private static string StaticAssignedNonNullUsingClassName;
        private static string StaticComparedEqualToNonNullOnLeftUsingClassName;
        private static string StaticComparedEqualToNonNullOnRightUsingClassName;
        private static string StaticComparedNotEqualToNonNullOnLeftUsingClassName;
        private static string StaticComparedNotEqualToNonNullOnRightUsingClassName;
        private static string StaticAssignedResultOfCastUsingClassName;

        public void AllFieldsAreNullableForDifferentReasons()
        {
            string dummy;

            assignedNonNull = string.Empty;
            bAssignedNonNull = string.Empty;
            detectedNever = string.Empty;

            if (comparedEqualToNonNullOnLeft == string.Empty) return;
            if (string.Empty == comparedEqualToNonNullOnRight) return;            
            if (comparedNotEqualToNonNullOnLeft != string.Empty) return;
            if (string.Empty != comparedNotEqualToNonNullOnRight) return;
            if (detectedNever == string.Empty) return;
            if (string.Empty == detectedNever) return;

            assignedResultOfCast = (string)assignedNonNull;

            this.assignedNonNullUsingThis = string.Empty;

            if (this.comparedEqualToNonNullOnLeftUsingThis == string.Empty) return;
            if (string.Empty == this.comparedEqualToNonNullOnRightUsingThis) return;
            if (this.comparedNotEqualToNonNullOnLeftUsingThis != string.Empty) return;
            if (string.Empty != this.comparedNotEqualToNonNullOnRightUsingThis) return;

            this.assignedResultOfCastUsingThis = (string)assignedNonNull;

            StaticAssignedNonNull = string.Empty;

            if (StaticComparedEqualToNonNullOnLeft == string.Empty) return;
            if (string.Empty == StaticComparedEqualToNonNullOnRight) return;
            if (StaticComparedNotEqualToNonNullOnLeft != string.Empty) return;
            if (string.Empty != StaticComparedNotEqualToNonNullOnRight) return;

            StaticAssignedResultOfCast = (string)assignedNonNull;

            if (ReferenceFieldCannotBeDeclaredAsNullableNeverSurelyNullable.StaticComparedEqualToNonNullOnLeftUsingClassName == string.Empty) return;
            if (string.Empty == ReferenceFieldCannotBeDeclaredAsNullableNeverSurelyNullable.StaticComparedEqualToNonNullOnRightUsingClassName) return;
            if (ReferenceFieldCannotBeDeclaredAsNullableNeverSurelyNullable.StaticComparedNotEqualToNonNullOnLeftUsingClassName != string.Empty) return;
            if (string.Empty != ReferenceFieldCannotBeDeclaredAsNullableNeverSurelyNullable.StaticComparedNotEqualToNonNullOnRightUsingClassName) return;

            ReferenceFieldCannotBeDeclaredAsNullableNeverSurelyNullable.StaticAssignedResultOfCastUsingClassName = (string)assignedNonNull;

            var classWithFields = new ClassWithNonNullFields();

            classWithFields.assignedNonNull = string.Empty;

            if (classWithFields.comparedEqualToNonNullOnLeft == string.Empty) return;
            if (string.Empty == classWithFields.comparedEqualToNonNullOnRight) return;
            if (classWithFields.comparedNotEqualToNonNullOnLeft != string.Empty) return;
            if (string.Empty != classWithFields.comparedNotEqualToNonNullOnRight) return;

            classWithFields.assignedResultOfCast = (string)assignedNonNull;

            ClassWithNonNullFields.StaticAssignedNonNull = string.Empty;

            if (ClassWithNonNullFields.StaticComparedEqualToNonNullOnLeft == string.Empty) return;
            if (string.Empty == ClassWithNonNullFields.StaticComparedEqualToNonNullOnRight) return;
            if (ClassWithNonNullFields.StaticComparedNotEqualToNonNullOnLeft != string.Empty) return;
            if (string.Empty != ClassWithNonNullFields.StaticComparedNotEqualToNonNullOnRight) return;

            ClassWithNonNullFields.StaticAssignedResultOfCast = (string)assignedNonNull;
        }
    }

    public class ClassWithNonNullFields
    {
        public string intializedToNonNull = string.Empty;

        public string assignedNonNull;
        public string comparedEqualToNonNullOnLeft;
        public string comparedEqualToNonNullOnRight;
        public string comparedNotEqualToNonNullOnLeft;
        public string comparedNotEqualToNonNullOnRight;
        public string assignedResultOfCast;

        public static string StaticAssignedNonNull;
        public static string StaticComparedEqualToNonNullOnLeft;
        public static string StaticComparedEqualToNonNullOnRight;
        public static string StaticComparedNotEqualToNonNullOnLeft;
        public static string StaticComparedNotEqualToNonNullOnRight;
        public static string StaticAssignedResultOfCast;
    }
}