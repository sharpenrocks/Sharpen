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