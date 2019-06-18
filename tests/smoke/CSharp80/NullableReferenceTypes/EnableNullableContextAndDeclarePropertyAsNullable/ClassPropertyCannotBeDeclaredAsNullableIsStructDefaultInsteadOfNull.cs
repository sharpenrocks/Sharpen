// ReSharper disable All

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclarePropertyAsNullable
{
    public class ClassPropertyCannotBeDeclaredAsNullableIsStructDefaultInsteadOfNull
    {
        private int DetectedOnlyOnce { get; set; } = default;

        private int IntializedToDefault { get; set; } = default(int);

        private int AssignedDefault { get; set; }
        private int ComparedEqualToDefaultOnLeft { get; set; }
        private int ComparedEqualToDefaultOnRight { get; set; }
        private int ComparedNotEqualToDefaultOnLeft { get; set; }
        private int ComparedNotEqualToDefaultOnRight { get; set; }

        private int AssignedDefaultUsingThis { get; set; }
        private int ComparedEqualToDefaultOnLeftUsingThis { get; set; }
        private int ComparedEqualToDefaultOnRightUsingThis { get; set; }
        private int ComparedNotEqualToDefaultOnLeftUsingThis { get; set; }
        private int ComparedNotEqualToDefaultOnRightUsingThis { get; set; }

        private static int StaticAssignedDefault { get; set; }
        private static int StaticComparedEqualToDefaultOnLeft { get; set; }
        private static int StaticComparedEqualToDefaultOnRight { get; set; }
        private static int StaticComparedNotEqualToDefaultOnLeft { get; set; }
        private static int StaticComparedNotEqualToDefaultOnRight { get; set; }

        private static int StaticAssignedDefaultUsingClassName { get; set; }
        private static int StaticComparedEqualToDefaultOnLeftUsingClassName { get; set; }
        private static int StaticComparedEqualToDefaultOnRightUsingClassName { get; set; }
        private static int StaticComparedNotEqualToDefaultOnLeftUsingClassName { get; set; }
        private static int StaticComparedNotEqualToDefaultOnRightUsingClassName { get; set; }

        public void AllPropertiesAreUsedWithDefaultForDifferentReasons()
        {
            AssignedDefault = default;
            DetectedOnlyOnce = default(int);

            if (ComparedEqualToDefaultOnLeft == default) return;
            if (default(int) == ComparedEqualToDefaultOnRight) return;            
            if (ComparedNotEqualToDefaultOnLeft != default) return;
            if (default(int) != ComparedNotEqualToDefaultOnRight) return;
            if (DetectedOnlyOnce == default) return;
            if (default(int) == DetectedOnlyOnce) return;

            this.AssignedDefaultUsingThis = default;

            if (this.ComparedEqualToDefaultOnLeftUsingThis == default(int)) return;
            if (default == this.ComparedEqualToDefaultOnRightUsingThis) return;
            if (this.ComparedNotEqualToDefaultOnLeftUsingThis != default(int)) return;
            if (default != this.ComparedNotEqualToDefaultOnRightUsingThis) return;

            StaticAssignedDefault = default(int);

            if (StaticComparedEqualToDefaultOnLeft == default) return;
            if (default(int) == StaticComparedEqualToDefaultOnRight) return;
            if (StaticComparedNotEqualToDefaultOnLeft != default) return;
            if (default(int) != StaticComparedNotEqualToDefaultOnRight) return;

            ClassPropertyCannotBeDeclaredAsNullableIsStructDefaultInsteadOfNull.StaticAssignedDefaultUsingClassName = default;

            if (ClassPropertyCannotBeDeclaredAsNullableIsStructDefaultInsteadOfNull.StaticComparedEqualToDefaultOnLeftUsingClassName == default(int)) return;
            if (default == ClassPropertyCannotBeDeclaredAsNullableIsStructDefaultInsteadOfNull.StaticComparedEqualToDefaultOnRightUsingClassName) return;
            if (ClassPropertyCannotBeDeclaredAsNullableIsStructDefaultInsteadOfNull.StaticComparedNotEqualToDefaultOnLeftUsingClassName != default(int)) return;
            if (default != ClassPropertyCannotBeDeclaredAsNullableIsStructDefaultInsteadOfNull.StaticComparedNotEqualToDefaultOnRightUsingClassName) return;

            var classWithProperties = new ClassWithStructProperties();

            classWithProperties.AssignedDefault = default(int);

            if (classWithProperties.ComparedEqualToNullOnLeft == default) return;
            if (default(int) == classWithProperties.ComparedEqualToNullOnRight) return;
            if (classWithProperties.ComparedNotEqualToNullOnLeft != default) return;
            if (default(int) != classWithProperties.ComparedNotEqualToNullOnRight) return;

            ClassWithStructProperties.StaticAssignedNull = default;

            if (ClassWithStructProperties.StaticComparedEqualToNullOnLeft == default(int)) return;
            if (default == ClassWithStructProperties.StaticComparedEqualToNullOnRight) return;
            if (ClassWithStructProperties.StaticComparedNotEqualToNullOnLeft != default(int)) return;
            if (default != ClassWithStructProperties.StaticComparedNotEqualToNullOnRight) return;
        }
    }

    public class ClassWithStructProperties
    {
        public int IntializedToDefault { get; set; } = default(int);

        public int AssignedDefault { get; set; }
        public int ComparedEqualToNullOnLeft { get; set; }
        public int ComparedEqualToNullOnRight { get; set; }
        public int ComparedNotEqualToNullOnLeft { get; set; }
        public int ComparedNotEqualToNullOnRight { get; set; }

        public static int StaticAssignedNull { get; set; }
        public static int StaticComparedEqualToNullOnLeft { get; set; }
        public static int StaticComparedEqualToNullOnRight { get; set; }
        public static int StaticComparedNotEqualToNullOnLeft { get; set; }
        public static int StaticComparedNotEqualToNullOnRight { get; set; }
    }
}