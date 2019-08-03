using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Sharpen.Engine.CSharpVersionDependent;
using System;
using System.Collections.Generic;
using System.IO;
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
                return GetCSharpVersionDependentFromAssembly(CompileVersionDependentImplementation(GetVersionDependentSourceCode(version_3_0_0_0)));
            else if (version >= version_2_10_0_0)
                return GetCSharpVersionDependentFromAssembly(CompileVersionDependentImplementation(GetVersionDependentSourceCode(version_2_10_0_0)));
            else return new DefaultCSharpVersionDependent();
        }

        private static string GetVersionDependentSourceCode(Version version)
        {
            var versionSuffix = $"_{version.Major}_{version.Minor}_{version.Build}_{version.Revision}";
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith($"CSharpVersionDependent{versionSuffix}.cs"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static Assembly CompileVersionDependentImplementation(string sourceCode)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            CSharpCompilation compilation = CSharpCompilation.Create(
                Path.GetRandomFileName(),
                syntaxTrees: new[] { syntaxTree },
                references: GetMetadataReferences(),
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var memoryStream = new MemoryStream())
            {
                EmitResult emitResult = compilation.Emit(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return Assembly.Load(memoryStream.ToArray());
            }
        }

        private static ICSharpVersionDependent GetCSharpVersionDependentFromAssembly(Assembly assembly)
        {
            var implementationType = assembly.ExportedTypes.Single(type => type.GetInterface(nameof(ICSharpVersionDependent)) != null);
            return (ICSharpVersionDependent)Activator.CreateInstance(implementationType);
        }

        private static List<MetadataReference> GetMetadataReferences()
        {
            var result = new List<MetadataReference>();
            result.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
            result.Add(MetadataReference.CreateFromFile(typeof(SyntaxTree).Assembly.Location));
            result.Add(MetadataReference.CreateFromFile(typeof(CSharpSyntaxTree).Assembly.Location));
            result.Add(MetadataReference.CreateFromFile(typeof(ICSharpVersionDependent).Assembly.Location));
            result.Add(MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location));
            foreach (var assembly in GetAdditionalAssemblies())
            {
                result.Add(MetadataReference.CreateFromFile(assembly.Location));
            }
            return result;

            IEnumerable<Assembly> GetAdditionalAssemblies()
            {
                string[] neededReferencedAssemblyNames = { "netstandard" };

                var additionalAssemblies = new Dictionary<AssemblyName, Assembly>();

                FindAdditionalAssembliesRecursively(typeof(SyntaxTree).Assembly);

                return additionalAssemblies.Values;

                void FindAdditionalAssembliesRecursively(Assembly parentAssembly)
                {
                    var referencedAssemblyNamesAndAssemblies = parentAssembly
                        .GetReferencedAssemblies()
                        .Where(assemblyName => neededReferencedAssemblyNames.Contains(assemblyName.Name) && !additionalAssemblies.ContainsKey(assemblyName))
                        .Select(assemblyName => (assemblyName, assembly: Assembly.Load(assemblyName)));

                    foreach (var (assemblyName, assembly) in referencedAssemblyNamesAndAssemblies)
                    {
                        additionalAssemblies.Add(assemblyName, assembly);

                        if (neededReferencedAssemblyNames.Length <= additionalAssemblies.Count) break;

                        FindAdditionalAssembliesRecursively(assembly);
                    }
                }
            }
        }
    }
}
