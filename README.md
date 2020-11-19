# Sharpen
*Sharpen* is a Visual Studio extension that intelligently modernizes your existing C# codebase. It makes your code more expressive, more readable, more robust, and more performant, in one word - sharper.

[![Twitter](https://img.shields.io/badge/twitter-sharpenrocks-brightgreen.svg?logo=twitter)](https://twitter.com/sharpenrocks)
[![Visual Studio Marketplace Version](https://img.shields.io/visual-studio-marketplace/v/ironcev.sharpen?color=green&label=visual%20studio%20marketplace)](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen)
[![AppVeyor](https://img.shields.io/appveyor/ci/ironcev/sharpen.svg)](https://ci.appveyor.com/project/ironcev/sharpen)
[![GitHub release](https://img.shields.io/github/release/ironcev/sharpen/all.svg)](https://github.com/ironcev/sharpen/releases)
[![License](https://img.shields.io/github/license/ironcev/sharpen.svg)](https://github.com/ironcev/sharpen/blob/master/LICENSE)

## TL; DR
*Sharpen* **identifies places in your code that will benefit from introducing new C# language features**. It helps you to **learn new C# features quicker** and **critically refactor your existing code** to modern C#.

![Sharpen in action](https://raw.githubusercontent.com/ironcev/sharpen/master/images/demo.gif)

## Benefits at a Glance
Sharpen helps you to:

- [learn new C# features faster](#faster-learning-of-new-c-features)
- [modernize and refactor your code](#modernizing-and-refactoring-code)
- [always have high-quality documentation on C# language at your fingerprints](#high-quality-documentation-on-c-language-at-your-fingerprints)
- [learn to approach new C# features critically](#critical-approach-to-new-c-features)
- [improve the design and architecture of your codebase](#improving-design-and-architecture-of-a-broader-codebase)
- [use C# features consistently over your codebase](#consistent-usage-of-c-features)

### Faster Learning of New C# Features
Learn new C# features faster by applying them to your existing codebase.

*Sharpen* points you to places in real-life production code - your production code! - where you can learn and apply modern C#. This is a far cry from simplified and artificial code samples often used to explain new C# features. *Sharpen* allows you to learn and understand modern C# in the context of your own code.

*Sharpen* provides you with meaningful recommendations and considerations for modernizing your code. It relates those recommendations and considerations to particular C# versions and their language features. Recommendations and considerations supported at the moment are listed below, sorted by the language version. Each new version of *Sharpen* brings additional recommendations and considerations.

#### C# 8.0

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/faster-learning-of-new-csharp-features-csharp-8-0.png" alt="C# 8.0 recommendations and considerations" style="max-width:100%;">
</p>

#### C# 7.1

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/faster-learning-of-new-csharp-features-csharp-7-1.png" alt="C# 7.1 recommendations and considerations" style="max-width:100%;">
</p>

#### C# 7.0

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/faster-learning-of-new-csharp-features-csharp-7-0.png" alt="C# 7.0 recommendations and considerations" style="max-width:100%;">
</p>

#### C# 6.0

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/faster-learning-of-new-csharp-features-csharp-6-0.png" alt="C# 6.0 recommendations and considerations" style="max-width:100%;">
</p>

#### C# 5.0

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/faster-learning-of-new-csharp-features-csharp-5-0.png" alt="C# 5.0 recommendations and considerations" style="max-width:100%;">
</p>

#### C# 3.0

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/faster-learning-of-new-csharp-features-csharp-3-0.png" alt="C# 3.0 recommendations and considerations" style="max-width:100%;">
</p>

### Modernizing and Refactoring Code

Modernize your C# code by refactoring it via a single mouse click.

*Sharpen* will have a preview window that shows how the code looks now and how it will look after the proposed change is applied. That way, you will clearly understand the difference and, at the same time, visually grasp what the language feature is about. You will have the option to accept the proposed change and automatically refactor that piece of code.

Preview is not implemented at the moment. Here is a rough mockup of that upcoming functionality.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/modernizing-and-refactoring-code-preview-window-switch-expression.png" alt="Sharpen preview window" style="max-width:100%;">
</p>

Refactoring will not be limited to the preview window only. It will be possible on different scales. E.g. in a single place in code, or in a single file, or a whole project, or solution. *Sharpen* will give you full control over the scope and nature of the refactorings. Also, it will automatically refactor only direct recommendations. Those are considered as always safe to apply.

This mockup shows applying suggested changes for a specific language feature within all files of a solution.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/modernizing-and-refactoring-code-apply-recommendations.png" alt="Applying Sharpen's recommendations" style="max-width:100%;">
</p>

Until *Sharpen* built-in refactorings are implemented, you can use the code fixes that come with Visual Studio for some of the recommendations. They are not available for all *Sharpen* recommendations, but for some, they are, so make sure to take a look if they might exist.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/modernizing-and-refactoring-code-use-visual-studio-code-fixes.gif" alt="Refactoring code by using Visual Studio code fixes" style="max-width:100%;">
</p>

### High-Quality Documentation on C# Language at your Fingerprints
Learn C# without leaving Visual Studio by using built-in, high-quality documentation.

*Sharpen* will bring high-quality C# documentation right at your fingerprints. It will provide its own extensive built-in documentation that explains C# language features in-depth. It will also link to the official MSDN documentation and curated high-quality online blog posts and videos that bring additional insights into particular topics.

*Sharpen* aims to become a one-stop-shop for everything you ever wanted to know about the design and evolution of C#.

In its current version, *Sharpen* links C# releases and language features to their official MSDN documentation. Extensive built-in documentation will be available in upcoming versions of *Sharpen*. (To open the documentation in an external browser, press the CTRL key while clicking on the link.)

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/high-quality-documentation-on-csharp-language-at-your-fingerprints.gif" alt="High-Quality Documentation on C# Language at your Fingerprints" style="max-width:100%;">
</p>

### Critical Approach to New C# Features
Understand the potential drawbacks of new C# features before using them.

*Sharpen* imposes a critical view on C# features. It does that by distinguishing between *recommendations* and *considerations*. Recommendations are safe and recommended to apply. They will result in a more expressive, more readable, more robust, or more performant code. Recommendations always start with call-for-action verbs like "use," "apply," or "replace." Considerations, on the other hand, ask you to critically assess a particular language feature's usage in a given context. Considerations usually start with the verb "consider."

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/critical-approach-to-new-csharp-features-recommendations-and-considerations.png" alt="Sharpen's recommendations and considerations" style="max-width:100%;">
</p>

At the moment, *Sharpen*'s considerations do not provide any explanations. In the upcoming versions, every consideration will come with an explanation. This explanation, together with additional examples, will provide you with enough information to decide if the language feature should be used in that particular case.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/critical-approach-to-new-csharp-features-explanation-for-consideration.png" alt="An explanation for a Sharpen consideration" style="max-width:100%;">
</p>

### Improving Design and Architecture of a Broader Codebase
Recognize potential improvements and redesign and rearchitecture your code on a broader scope.

*Sharpen* is equipped with intelligent heuristics that recognizes potential code improvements on a broader scope. For example, the "Consider awaiting equivalent asynchronous method and yielding IAsyncEnumerable" recognizes places where asynchronous streams might be a better design choice than returning an `IEnumerable<T>`. Accepting such consideration impacts and improves the code on a broader scope. It means rearchitecting and redesigning a larger portion of the codebase rather than simply refactoring an isolated piece of code.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/improving-design-and-architecture-of-the-codebase.png" alt="Consider awaiting equivalent asynchronous method and yielding IAsyncEnumerable" style="max-width:100%;">
</p>

Other examples would be considering:

- to rearchitecture legacy asynchronous programming patterns like, e.g. `IAsyncResult` pattern, to the Task-based Asynchronous Pattern and async and await.
- to rearchitecture mutable Data Transfer Objects to C# 9.0 records.

### Consistent Usage of C# Features
Use new C# features consistently over your entire codebase.

Future versions of *Sharpen* will allow you to configure which recommendations are relevant for you and refine the recommendations using recommendation-specific settings. Storing of such configurations will be possible on different levels, e.g., on a project, or on a solution, or on a machine level, to name just a few possibilities. It will be possible to share *Sharpen*'s configuration among programmers working on the same project by checking it into the source code repository.

Note that defining and storing configurations is not implemented at the moment.

## Installing Sharpen
You can [install *Sharpen* directly from Visual Studio](https://github.com/sharpenrocks/Sharpen/wiki/Installing-Sharpen) by using Extensions dialog or you can [download it](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) from the Visual Studio Marketplace.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/installing-sharpen-from-visual-studio.png" alt="Installing Sharpen from Visual Studio" style="max-width:100%;">
</p>

## Running Code Analysis
To run *Sharpen* analysis on a whole solution, go to the "Tools -> Sharpen -> Analyze Solution".<br/>
To run an analysis on the currently edited file, use the "Analyze with Sharpen" context menu option on the file context menu.<br/>
To run an analysis on an arbitrary scope, use the "Analyze with Sharpen" context menu option after selecting nodes in the Solution Explorer.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/running-code-analysis.gif" alt="Running Sharpen code analysis" style="max-width:100%;">
</p>

## Contributing
*Sharpen* is a volunteer effort. Covering the whole C# evolution is a humongous task that cannot be carried out by a few people. So pitch in and join the development! :-) Before contributing, please make sure to read the [contribution guidelines](CONTRIBUTING.md).

## Release Notes
All notable changes to the *Sharpen* extension are documented in the [changelog](https://github.com/ironcev/sharpen/blob/master/CHANGELOG.md). 

## License
*Sharpen* is licensed under the [MIT license](https://github.com/ironcev/sharpen/blob/master/LICENSE).
