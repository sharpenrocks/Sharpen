# Binding Redirects and Conditional Runtime Compilation

## Description

This experiment is a small "subexperiment" of the [Roslyn Dependencies at Build and Runtime](../RoslynDependenciesAtBuildAndRuntime).

Basically, we want to be able to tell to C# compiler and .NET runtime: "Listen, I will develop and compile this library using the newest version of some dependency, but at runtime, trust me, I am perfectly fine if you bind me to absolutely any version of that dependency."

To achieve this we combine:

- standard .NET runtime behavior in assembly resolution and loading
- binding redirects
- the fact that the runtime will compile a method only if it is actually called in the code

## Running the Experiment

Build `BindingRedirectsAndConditionalRuntimeCompilation.sln`. The build will not copy `Library.dll` to the `Client` output directory.

Copy the first version of the `Library.dll` and run `Client.exe`. Override it with the second version and run `Client.exe` again.

## Results

As expected, we got the desired behaviour. At build time, we use the newest version of the `Library` and at runtime we are fine with having any of the versions.