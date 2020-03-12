# Sharpen
*Sharpen* is a Visual Studio extension that intelligently introduces new C# language features into your existing codebase. It makes your code shorter, simpler, more expressive, more performant, and more readable, in one word - sharper.

[![Twitter](https://img.shields.io/badge/twitter-sharpenrocks-brightgreen.svg?logo=twitter)](https://twitter.com/sharpenrocks)
[![Visual Studio Marketplace Version](https://img.shields.io/visual-studio-marketplace/v/ironcev.sharpen?color=green&label=visual%20studio%20marketplace)](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen)
[![AppVeyor](https://img.shields.io/appveyor/ci/ironcev/sharpen.svg)](https://ci.appveyor.com/project/ironcev/sharpen)
[![GitHub release](https://img.shields.io/github/release/ironcev/sharpen/all.svg)](https://github.com/ironcev/sharpen/releases)
[![License](https://img.shields.io/github/license/ironcev/sharpen.svg)](https://github.com/ironcev/sharpen/blob/master/LICENSE)

## TL; DR
*Sharpen* **identifies places in your code that will benefit of introducing new C# language features**. It helps you to **quicker learn new C# features** and to **critically refactor your existing code** to modern C#.

![Sharpen in action](https://raw.githubusercontent.com/ironcev/sharpen/master/images/demo.gif)

## Installation

You can [install *Sharpen*](https://github.com/sharpenrocks/Sharpen/wiki/Installing-Sharpen) directly from Visual Studio or [download it](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) from the Visual Studio Marketplace.

## Benefits at a Glance

### Faster Learning of New C# Features
Learn new C# features faster by applying them to your existing codebase.

Forget the simplified, artificial code samples often used to introduce new C# features. *Sharpen* points to places in real-life production code - your code! - where new C# features should be used.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/faster-learning-of-new-csharp-features.png" alt="Faster Learning of New C# Features" style="max-width:100%;">
</p>

### Critical Approach to New C# Features
Learn to ❤ C# but not blindly. Take love with a pinch of salt ;-)

*Sharpen* brings a critical view on C# features. It recommends applying them only if their usage will actually result in "sharper" code. *Sharpen* is not shy of saying No to a language feature.

### Consistent Usage of C# Features
Consistency matters. Your preferences as well.

Once configured on your project, *Sharpen* ensures that C# language features are consistently used over the whole codebase.

### Code Refactoring on Arbitrary Scale
Safely refactor your code by a single mouse click.

*Sharpen* can refactor your code on an arbitrary scale: single place in code, single file, or a whole project, or solution. At the same time, it gives you full control over the scope and nature of the refactorings.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/code-refactoring-on-arbitrary-scale.png" alt="Code Refactoring on Arbitrary Scale" style="max-width:100%;">
</p>

### Improving Code on a Larger Scope
Still having BackgroundWorkers in your code?

It's time to replace them with async-await! *Sharpen* is equipped with an intelligent heuristics that recognizes potential improvements of your code on a broader scope.

### Extensive Documentation on C# Language
Tired of searching for new C# features in random blog posts?

*Sharpen* comes with extensive built-in documentation on C# language features. It's a one-stop-shop for everything you ever wanted to know about the design and evolution of C#.

## Current Limitations
Note that in the current version of *Sharpen* the following features mentioned in the above chapters are still not available:

- Extensive documentation.
- Recommendations.
- Refactoring.
- Configuration.

## Contributing
*Sharpen* is a volunteer effort. Covering the whole C# evolution is a humongous task that cannot be carried out by a single person. So pitch in and join the development! :-) Before contributing, please make sure to read the [contribution guidelines](CONTRIBUTING.md).

## Release Notes
All notable changes to the *Sharpen* extension are documented in the [changelog](https://github.com/ironcev/sharpen/blob/master/CHANGELOG.md). Below is the excerpt from the changelog that lists only the summary of major changes.

### 0.10.1
- Bug fixes in the Sharpen Results view.

### 0.10.0
- Null-coalescing assignments suggestions (C# 8.0).
- "Learn more..." and "What is/was new in C# X.Y?" links to MSDN documentation in the Sharpen Results view.

### 0.9.0
- Async streams, nullable reference types, switch expressions, and using declarations suggestions (C# 8.0).
- Var keyword suggestions (C# 3.0).

### 0.8.0
- Support for Visual Studio 2019.

### 0.7.0
- Analysis of selected files, folders, and projects via "Analyze with Sharpen" option on context menus.

### 0.6.1
- Better display of Async and Await findings in the Sharpen Results view.
- Suggestion for awaiting task instead of calling Task.Result.

### 0.6.0
- Async/Await suggestions (C# 5.0).

### 0.5.0
- Suggestions for using nameof expressions in argument exceptions and dependency properties (C# 6.0).

### 0.4.0
- Suggestions for discarding of out variables (C# 7.0).
- Suggestions for usages of out variables in object creations (C# 7.0).

### 0.3.0
- Suggestions for usages of out variables (C# 7.0).
- Grouping of the analysis results by C# language feature.

### 0.2.0
- Suggestions for usages of default expressions (C# 7.1).

### 0.1.1
- Icon, preview image and release notes.

### 0.1.0
- Display of the analysis results in a tree view.
- Analysis of the whole solution.
- Suggestions for usages of expression-bodied members (C# 6.0 & C# 7.0).

## License
*Sharpen* is licensed under the [MIT license](https://github.com/ironcev/sharpen/blob/master/LICENSE).
