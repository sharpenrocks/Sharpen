# Roslyn Dependencies at Build and Runtime

## Description

During the development we reference a certain version of the `Microsoft.CodeAnalysis.*` NuGet packages. These are used to build the code and also to run unit tests. But the the `Microsoft.CodeAnalysis.*` DLLs we built against are not included in the final VSIX package. The build target that actually creates the VSIX package removes these DLLs.

This removal of DLLs is perfectly fine. At runtime, we want to use the Roslyn version that ships with the Visual Studio.

That's why we have Roslyn as prerequisite in the `vsixmanifest` file:

    <Prerequisite Id="Microsoft.VisualStudio.Component.Roslyn.LanguageServices"
                  Version="[15.0.26208.0,17.0)"
                  DisplayName="C# and Visual Basic" />
    <Prerequisite Id="Microsoft.VisualStudio.Component.Roslyn.Compiler"
                  Version="[15.0.26208.0,17.0)"
                  DisplayName="C# and Visual Basic Roslyn compilers" />

But practically this means that at the runtime we are bound to a Roslyn version which will very likely not be the one we used for building the Sharpen. Needless to say, this can cause all bunch of issues. For example, the current version v0.8.0 of Sharpen works fine in both VS2017 and VS2019 just because we use the subset of the API that was not changed between the two corresponding Roslyn versions.

Also, for some Sharpen suggestions, we actually want to have different implementation in the older and in the newer Roslyn version. For example, the method `IsNullableContextEnabled(...)` can simply return `true` in VS2017 but should do some actuall work in VS2019.

It is worth mentioning here that we do not care about the Visual Studio version in which Sharpen is installed, but rather which Roslyn version it is bound to.

In this experiment we want to confirm this hypothesis that at runtime we are bound to the Roslyn DLLs that ship with the compiler and also to find a solution that will enable us:

- to deterministically support both VS2017 and VS2019 (and ideally future version of VS as well) within a single Sharpen VSIX package.
- to be able to have Roslyn version dependent implementations of some of the Sharpen Engine's methods.

## Running the Experiment

Open `problem\Sharpen.Lab.RoslynDependenciesAtBuildAndRuntime.sln` in VS2017, build it and run unit tests. Then run the extension in the experimental instance of VS2017.

Do the same with VS2019.

## Results

As assumed, running the unit tests in both VS2017 and VS2019 gives the same output because the referenced Roslyn version is used:

![Unit tests output](images/unit-test-output.png)

As assumed, running the extension in VS2017 gives the following output:

![VS2017 output](images/vs2017-output.png)

As assumed, running the extension in VS2019 gives the following output:

![VS2019 output](images/vs2019-output.png)

## Potential Solution

> I have not failed. I've just found 10,000 ways that won't work. - Thomas A. Edison