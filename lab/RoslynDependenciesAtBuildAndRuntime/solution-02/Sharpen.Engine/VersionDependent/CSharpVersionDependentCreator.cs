using Microsoft.CodeAnalysis;
using Sharpen.Engine.CSharpVersionDependent;
using System;
using System.Linq;
using System.Reflection;

namespace Sharpen.Engine.VersionDependent
{
    public static class CSharpVersionDependentCreator
    {
        static CSharpVersionDependentCreator()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        }

        private static ICSharpVersionDependent instance;
        public static ICSharpVersionDependent GetCSharpVersionDependentImplementation()
        {
            return instance = instance ?? CreateCSharpVersionDependentImplementation();
        }

        private static readonly Assembly CSharpVersionDependentAssembly = typeof(ICSharpVersionDependent).Assembly;
        private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name == CSharpVersionDependentAssembly.FullName)
                return CSharpVersionDependentAssembly;
            return null;
        }

        private static readonly Version version_2_4_0_0 = new Version(2, 4, 0, 0);
        private static readonly Version version_2_10_0_0 = new Version(2, 10, 0, 0);
        private static readonly Version version_3_0_0_0 = new Version(3, 0, 0, 0);
        private static ICSharpVersionDependent CreateCSharpVersionDependentImplementation()
        {
            var version = typeof(SyntaxTree).Assembly.GetName().Version;

            if (version >= version_3_0_0_0)
                return GetCSharpVersionDependentFromAssembly(GetVersionDependentAssembly(version_3_0_0_0));
            else if (version >= version_2_10_0_0)
                return GetCSharpVersionDependentFromAssembly(GetVersionDependentAssembly(version_2_10_0_0));
            else return new DefaultCSharpVersionDependent();
        }

        private static Assembly GetVersionDependentAssembly(Version version)
        {
            var versionSuffix = $"{version.Major}_{version.Minor}_{version.Build}_{version.Revision}";
            var versionDependentAssemblyFileName = Assembly.GetExecutingAssembly().Location.Replace("Sharpen.Engine.dll", $"Sharpen.Engine.{versionSuffix}.dll");

            return Assembly.LoadFile(versionDependentAssemblyFileName);
        }

        private static ICSharpVersionDependent GetCSharpVersionDependentFromAssembly(Assembly assembly)
        {
            var implementationType = assembly.ExportedTypes.Single(type => type.GetInterface(nameof(ICSharpVersionDependent)) != null);
            return (ICSharpVersionDependent)Activator.CreateInstance(implementationType);
        }
    }
}
