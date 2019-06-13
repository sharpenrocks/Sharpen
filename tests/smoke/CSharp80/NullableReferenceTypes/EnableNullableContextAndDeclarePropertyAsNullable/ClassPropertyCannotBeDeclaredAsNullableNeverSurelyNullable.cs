// ReSharper disable All

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclarePropertyAsNullable
{
    public class ClassPropertyCannotBeDeclaredAsNullableNeverSurelyNullable
    {
        private string DetectedNever { get; set; } = string.Empty;

        private string IntializedToNonNull { get; set; } = string.Empty;
        private string InitializedToResultOfCast { get; set; } = (string)string.Empty;

        private string AssignedNonNull { get; set; }
        private string ComparedEqualToNonNullOnLeft { get; set; }
        private string ComparedEqualToNonNullOnRight { get; set; }
        private string ComparedNotEqualToNonNullOnLeft { get; set; }
        private string ComparedNotEqualToNonNullOnRight { get; set; }
        private string AssignedResultOfCast { get; set; }

        private string AssignedNonNullUsingThis { get; set; }
        private string ComparedEqualToNonNullOnLeftUsingThis { get; set; }
        private string ComparedEqualToNonNullOnRightUsingThis { get; set; }
        private string ComparedNotEqualToNonNullOnLeftUsingThis { get; set; }
        private string ComparedNotEqualToNonNullOnRightUsingThis { get; set; }
        private string AssignedResultOfCastUsingThis { get; set; }

        private static string StaticAssignedNonNull { get; set; }
        private static string StaticComparedEqualToNonNullOnLeft { get; set; }
        private static string StaticComparedEqualToNonNullOnRight { get; set; }
        private static string StaticComparedNotEqualToNonNullOnLeft { get; set; }
        private static string StaticComparedNotEqualToNonNullOnRight { get; set; }
        private static string StaticAssignedResultOfCast { get; set; }

        private static string StaticAssignedNonNullUsingClassName { get; set; }
        private static string StaticComparedEqualToNonNullOnLeftUsingClassName { get; set; }
        private static string StaticComparedEqualToNonNullOnRightUsingClassName { get; set; }
        private static string StaticComparedNotEqualToNonNullOnLeftUsingClassName { get; set; }
        private static string StaticComparedNotEqualToNonNullOnRightUsingClassName { get; set; }
        private static string StaticAssignedResultOfCastUsingClassName { get; set; }

        public void AllFieldsAreNullableForDifferentReasons()
        {
            string dummy;

            AssignedNonNull = string.Empty;
            DetectedNever = string.Empty;

            if (ComparedEqualToNonNullOnLeft == string.Empty) return;
            if (string.Empty == ComparedEqualToNonNullOnRight) return;            
            if (ComparedNotEqualToNonNullOnLeft != string.Empty) return;
            if (string.Empty != ComparedNotEqualToNonNullOnRight) return;
            if (DetectedNever == string.Empty) return;
            if (string.Empty == DetectedNever) return;

            AssignedResultOfCast = (string)AssignedNonNull;

            this.AssignedNonNullUsingThis = string.Empty;

            if (this.ComparedEqualToNonNullOnLeftUsingThis == string.Empty) return;
            if (string.Empty == this.ComparedEqualToNonNullOnRightUsingThis) return;
            if (this.ComparedNotEqualToNonNullOnLeftUsingThis != string.Empty) return;
            if (string.Empty != this.ComparedNotEqualToNonNullOnRightUsingThis) return;

            this.AssignedResultOfCastUsingThis = (string)AssignedNonNull;

            StaticAssignedNonNull = string.Empty;

            if (StaticComparedEqualToNonNullOnLeft == string.Empty) return;
            if (string.Empty == StaticComparedEqualToNonNullOnRight) return;
            if (StaticComparedNotEqualToNonNullOnLeft != string.Empty) return;
            if (string.Empty != StaticComparedNotEqualToNonNullOnRight) return;

            StaticAssignedResultOfCast = (string)AssignedNonNull;

            if (ClassPropertyCannotBeDeclaredAsNullableNeverSurelyNullable.StaticComparedEqualToNonNullOnLeftUsingClassName == string.Empty) return;
            if (string.Empty == ClassPropertyCannotBeDeclaredAsNullableNeverSurelyNullable.StaticComparedEqualToNonNullOnRightUsingClassName) return;
            if (ClassPropertyCannotBeDeclaredAsNullableNeverSurelyNullable.StaticComparedNotEqualToNonNullOnLeftUsingClassName != string.Empty) return;
            if (string.Empty != ClassPropertyCannotBeDeclaredAsNullableNeverSurelyNullable.StaticComparedNotEqualToNonNullOnRightUsingClassName) return;

            ClassPropertyCannotBeDeclaredAsNullableNeverSurelyNullable.StaticAssignedResultOfCastUsingClassName = (string)AssignedNonNull;

            var classWithFields = new ClassWithNonNullProperties();

            classWithFields.AssignedNonNull = string.Empty;

            if (classWithFields.ComparedEqualToNonNullOnLeft == string.Empty) return;
            if (string.Empty == classWithFields.ComparedEqualToNonNullOnRight) return;
            if (classWithFields.ComparedNotEqualToNonNullOnLeft != string.Empty) return;
            if (string.Empty != classWithFields.ComparedNotEqualToNonNullOnRight) return;

            classWithFields.AssignedResultOfCast = (string)AssignedNonNull;

            ClassWithNonNullProperties.StaticAssignedNonNull = string.Empty;

            if (ClassWithNonNullProperties.StaticComparedEqualToNonNullOnLeft == string.Empty) return;
            if (string.Empty == ClassWithNonNullProperties.StaticComparedEqualToNonNullOnRight) return;
            if (ClassWithNonNullProperties.StaticComparedNotEqualToNonNullOnLeft != string.Empty) return;
            if (string.Empty != ClassWithNonNullProperties.StaticComparedNotEqualToNonNullOnRight) return;

            ClassWithNonNullProperties.StaticAssignedResultOfCast = (string)AssignedNonNull;
        }
    }

    public class ClassWithNonNullProperties
    {
        public string IntializedToNonNull { get; set; } = string.Empty;

        public string AssignedNonNull { get; set; }
        public string ComparedEqualToNonNullOnLeft { get; set; }
        public string ComparedEqualToNonNullOnRight { get; set; }
        public string ComparedNotEqualToNonNullOnLeft { get; set; }
        public string ComparedNotEqualToNonNullOnRight { get; set; }
        public string AssignedResultOfCast { get; set; }

        public static string StaticAssignedNonNull { get; set; }
        public static string StaticComparedEqualToNonNullOnLeft { get; set; }
        public static string StaticComparedEqualToNonNullOnRight { get; set; }
        public static string StaticComparedNotEqualToNonNullOnLeft { get; set; }
        public static string StaticComparedNotEqualToNonNullOnRight { get; set; }
        public static string StaticAssignedResultOfCast { get; set; }
    }
}