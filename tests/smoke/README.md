# Smoke Tests
This folder contains a sample solution that is used for smoke tests.

## Projects in The Solution
### CSharp[Version]
Projects named `CSharp[Version]` contain sample code that demonstrates potential usages of suggestions that are related to that language version. Each language usage suggestion that appears in that C# version has one or more sample source files that are located in a folder that has the same name as the related language suggestion class in the [SharpenEngine project](https://github.com/ironcev/Sharpen/tree/master/src/Sharpen.Engine).

These projects are used not only for smoke testing but also for the development of suggestions. The source code snippets are used to get the insight into the syntax tree behind the language constructs analyzed in corresponding suggestions.

### GeneratedDocuments
The `GeneratedDocuments` project contains some faked "generated" documents. These documents should be excluded from the analysis when the standard settings are used.

### LinkedDocuments
The `LinkedDocuments` project contains only the files which exist in other projects and are added to the `LinkedDocuments` project by using the *Add As Link* option. The goal is to smoke-test if those files will properly appear in the Sharpen Result window. They have to appear under the `LinkedDocuments` project and at the same time under their "real" projects, but in both cases with the proper logical path which must not necessary be the same as the corresponding file path on the disk.

### EmptyCSharpProject[Number]
Projects named `EmptyCSharpProject[Number]` are empty C# projects used to smoke test the corner cases. For example, the `EmptyCSharpProjects.sln` solution that contains only those projects cannot be analyzed because the analysis requires C# projects with C# files that can be analyzed.

### VisualBasicProject[Number]
Projects named `VisualBasicProject[Number]` are VB.NET  projects used to smoke test the corner cases. For example, the `VisualBasicsProjects.sln` solution that contains only those projects cannot be analyzed because the analysis requires C# projects.

### VNextCSharp[Version]
Projects named `VNextCSharp[Version]` contain sample code that consists of copies of files taken from `CSharp[Version]` projects that should generate appropriate suggestions when analyzed. These files are then intermixed with new language features supported in newer versions of Visual Studio and the compiler. Such projects can be opened only in the newer versions of Visual Studio, often in preview versions, while Sharpen is still being developed in the previous version. The goal is to smoke tests if the analysis developed in the previous version still work when intermixed with newer language features.