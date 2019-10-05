namespace Sharpen.Engine
{
    // TODO: Introduce proper abstraction. See: https://github.com/sharpenrocks/Sharpen/issues/12
    public static class CSharpLanguageVersions
    {
        public const string CSharp30 = "3.0";
        public const string CSharp50 = "5.0";
        public const string CSharp60 = "6.0";
        public const string CSharp70 = "7.0";
        public const string CSharp71 = "7.1";
        public const string CSharp80 = "8.0";

        public const string Latest = CSharp80;

        public static string GetWhatIsNewUrlFor(string cSharpLanguageVersion)
        {
            switch (cSharpLanguageVersion)
            {
                case CSharp30: return "https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-30";
                case CSharp50: return "https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-50";
                case CSharp60: return "https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-60";
                case CSharp70: return "https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7";
                case CSharp71: return "https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1";
                case CSharp80: return "https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8";
                default: return null;
            }
        }
    }
}