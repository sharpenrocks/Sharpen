<Query Kind="Program" />

void Main()
{
	var directoriesToScan = new[]
	{
        // Add your own directories here.
        // These are two on my machine with a bunch of .NET DLLs.
//		@"c:\p",
//		@"c:\s",

		$@"C:\Users\{Environment.UserName}\.nuget\packages",
		@"c:\Program Files (x86)\Microsoft SDKs\NuGetPackages",
		@"c:\Windows\Microsoft.NET\assembly"
	};

	var allPotentialMethods = directoriesToScan
		.Select(directory => new DirectoryInfo(directory))
		.SelectMany(directory => directory.EnumerateFiles("*.dll", SearchOption.AllDirectories))
		.Distinct(CompareFilesByName.Default)
		.AsParallel()
		.Select(file => TryLoadAssembly(file.FullName))
		.Where(assembly => assembly != null)
		.Select(assembly => new
		{
			MethodsThatHaveAsynchronousEquivalents = GetMethodsThatHaveAsynchronousEquivalents(assembly),
			MethodsThatCouldHaveAsyncStreamEquivalents = GetMethodsThatCouldHaveAsyncStreamEquivalents(assembly)
		})
		.ToArray();

	var methodsThatHaveAsynchronousEquivalents = new HashSet<string>(allPotentialMethods
		.SelectMany(m => m.MethodsThatHaveAsynchronousEquivalents)
		.Distinct()
		.OrderBy(_ => _));

	var methodsThatCouldHaveAsyncStreamEquivalents = allPotentialMethods
		.SelectMany(m => m.MethodsThatCouldHaveAsyncStreamEquivalents)
		.Where(method => !methodsThatHaveAsynchronousEquivalents.Contains(method))
		.Distinct()
		.OrderBy(_ => _)
		.ToArray();

	$"Methods that have asynchronous equivalents: {methodsThatHaveAsynchronousEquivalents.Count}".Dump();
	$"Methods that could have async stream equivalents: {methodsThatCouldHaveAsyncStreamEquivalents.Length}".Dump();

	var methodsThatHaveAsynchronousEquivalentsHashSetContent = string.Join($",{Environment.NewLine}    ", methodsThatHaveAsynchronousEquivalents.Select(method => $@"""{method}"""));
	var methodsThatCouldHaveAsyncStreamEquivalentsHashSetContent = string.Join($",{Environment.NewLine}    ", methodsThatCouldHaveAsyncStreamEquivalents.Select(method => $@"""{method}"""));

	$@"
new HashSet<string>
{{
    // ReSharper disable StringLiteralTypo
    {methodsThatHaveAsynchronousEquivalentsHashSetContent},
    
    /* --------------------------------- */
    
    {methodsThatCouldHaveAsyncStreamEquivalentsHashSetContent}
    // ReSharper disable StringLiteralTypo
}}"
	.Dump();
}

public string[] GetMethodsThatHaveAsynchronousEquivalents(Assembly assembly)
{
	try
	{
		return assembly
			.GetTypes()
			.Select(type => new
			{
				AllMethodsNames = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
									.Select(method => method.Name)
									.ToArray(),
				AsyncMethods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
									.Where(method =>
											MethodNameIsGoodLooking(method.Name) &&
											method.Name.EndsWith("Async") &&
											(
												method.ReturnType?.Name.Contains("Task") == true ||
												method.ReturnType?.Name.Contains("IAsyncEnumerable") == true
											)
									)
									.ToArray(),
				AsyncMethodsNamesWithoutAsync = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
									.Where(method =>
											MethodNameIsGoodLooking(method.Name) &&
											method.Name.EndsWith("Async") &&
											(
												method.ReturnType?.Name.Contains("Task") == true ||
												method.ReturnType?.Name.Contains("IAsyncEnumerable") == true
											)
											&&
											(method.IsPublic || method.IsFamily || method.IsFamilyAndAssembly || method.IsFamilyOrAssembly))
									.Select(method => method.Name.Substring(0, method.Name.Length - "Async".Length))
									.ToArray()
			})
			.Where(typeAndAsyncMethods => typeAndAsyncMethods.AsyncMethods.Any())
			.Where(typeAndAsyncMethods => typeAndAsyncMethods.AllMethodsNames.Any(name => typeAndAsyncMethods.AsyncMethodsNamesWithoutAsync.Contains(name)))
			.SelectMany(typeAndAsyncMethods => typeAndAsyncMethods.AsyncMethods)
			.Select(method => method.Name.Substring(0, method.Name.Length - "Async".Length))
			.Select(GetNormalizedMethodName)
			.ToArray();
	}
	catch
	{
		return Array.Empty<string>();
	}
}


public string[] GetMethodsThatCouldHaveAsyncStreamEquivalents(Assembly assembly) // Highly simplified algorithm.
{
	try
	{
		return assembly
			.GetTypes()
			.SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
									.Where(method =>
											MethodNameIsGoodLooking(method.Name) &&
											// At first we said let's look for all methods
											// that return anything that implements IEnumerable:
											//  method.ReturnType.GetInterfaces()
											//    .Any(@interface =>
											//       @interface.IsGenericType &&
											//       @interface.GetGenericTypeDefinition() == typeof(IEnumerable<>))
											// This was way to broad and gave back +20k results.
											// So we went only for arrays and methods that explicitly
											// return IEnumerable.
											(
												method.ReturnType.IsArray ||
												(
													method.ReturnType.IsGenericType &&
													method.ReturnType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
												)
											)
									)
			)
			.Select(method => GetNormalizedMethodName(method.Name))
			// If a name is too long e.g. ActivityDelegateCannotBeReferencedWithoutTargetNoHandler
			// we assume it is very specific and will rarely be used.
			// The selected methods are anyway just a wild guess
			// and will actually most likley never be made async.
			// So let's remove those with long names.
			.Where(name => name.Length <= 30)
			.ToArray();
	}
	catch
	{
		return Array.Empty<string>();
	}
}

public string GetNormalizedMethodName(string name)
{
	// Remove the interface name from the method name
	// in case of explicite interface implementation.
	// E.g.:
	//   FluentValidation.IValidator.Validate()
	return name.LastIndexOf('.') < 0
				? name
				: name.Substring(name.LastIndexOf('.') + 1);
}

public bool MethodNameIsGoodLooking(string name)
{
	return
		// Eliminates bunch of unwanted stuff e.g.:
		//   get_SomePropertyName()
		//   set_SomePropertyName()
		//   _GetValue()
		//   getValue()
		// End some quite strange stuff e.g.:
		//   01()
		//   [,]`1.GetSlice()
		//   |LeftSequentialSeries|()
		char.IsUpper(name[0]) &&
		// Eliminates e.g.:
		//   DtdParserProxy_ReadData()
		//   ExamplesWith__DoubleUnderscores()
		!name.Contains("_") &&
		// Eliminates e.g.:
		//   ApplyVectorExpr@477()
		!name.Contains("@") &&
		// Eliminates e.g.:
		//  AddGenericEqualityBindings$cont@13632()
		!name.Contains("$") &&
		// Eliminates fully capitalized names.
		name.ToUpperInvariant() != name;
}

public Assembly TryLoadAssembly(string fileName)
{
	try
	{
		return Assembly.LoadFile(fileName);
	}
	catch
	{
		return null;
	}
}

class CompareFilesByName : IEqualityComparer<FileInfo>
{
	public static CompareFilesByName Default = new CompareFilesByName();

	public bool Equals(FileInfo first, FileInfo second)
	{
		return string.Equals(first.Name, second.Name);
	}

	public int GetHashCode(FileInfo fileInfo)
	{
		return fileInfo.Name.GetHashCode();
	}
}