using Microsoft.CodeAnalysis;
using Sharpen.Engine;
using System;
using System.Linq;
using System.Reflection;

namespace Sharpen.VisualStudioExtension
{
    public static class SharpenEngineCreator
    {
        static SharpenEngineCreator()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        }

        private static ISharpenEngine instance;
        public static ISharpenEngine CreateSharpenEngine()
        {
            return instance = instance ?? CreateSharpenEngineImplementation();
        }

        private static readonly Assembly SharpenEngineAssembly = typeof(ISharpenEngine).Assembly;
        private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name == SharpenEngineAssembly.FullName)
                return SharpenEngineAssembly;
            return null;
        }

        private static readonly Version version_2_4_0_0 = new Version(2, 4, 0, 0);
        private static readonly Version version_3_0_0_0 = new Version(3, 0, 0, 0);
        private static readonly Version version_3_8_0_0 = new Version(3, 8, 0, 0);
        private static ISharpenEngine CreateSharpenEngineImplementation()
        {
            var version = typeof(SyntaxTree).Assembly.GetName().Version;

            if (version >= version_3_8_0_0)
                return GetSharpenEngineFromAssembly(GetVersionDependentAssembly(version_3_8_0_0));
            else if (version >= version_3_0_0_0)
                return GetSharpenEngineFromAssembly(GetVersionDependentAssembly(version_3_0_0_0));
            else 
                return GetSharpenEngineFromAssembly(GetVersionDependentAssembly(version_2_4_0_0));
        }

        private static Assembly GetVersionDependentAssembly(Version version)
        {
            var versionSuffix = $"{version.Major}_{version.Minor}_{version.Build}_{version.Revision}";
            var versionDependentAssemblyFileName = Assembly.GetExecutingAssembly().Location.Replace("Sharpen.dll", $"Sharpen.Engine.{versionSuffix}.dll");

            return Assembly.LoadFile(versionDependentAssemblyFileName);
        }

        private static ISharpenEngine GetSharpenEngineFromAssembly(Assembly assembly)
        {
            var implementationType = assembly.ExportedTypes.Single(type => type.GetInterface(nameof(ISharpenEngine)) != null);
            return (ISharpenEngine)Activator.CreateInstance(implementationType);
        }
    }
}
