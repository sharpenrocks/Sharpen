# Sharpen
*Sharpen* is a Visual Studio extension that intelligently introduces new C# language features into your existing codebase. It makes your code shorter, simpler, more expressive, more performant, and more readable, in one word - sharper.

[![Twitter](https://img.shields.io/badge/twitter-sharpenrocks-brightgreen.svg?logo=twitter)](https://twitter.com/sharpenrocks)
[![Visual Studio Marketplace Version](https://img.shields.io/visual-studio-marketplace/v/ironcev.sharpen?color=green&label=visual%20studio%20marketplace)](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen)
[![AppVeyor](https://img.shields.io/appveyor/ci/ironcev/sharpen.svg)](https://ci.appveyor.com/project/ironcev/sharpen)
[![GitHub release](https://img.shields.io/github/release/ironcev/sharpen/all.svg)](https://github.com/ironcev/sharpen/releases)
[![License](https://img.shields.io/github/license/ironcev/sharpen.svg)](https://github.com/ironcev/sharpen/blob/master/LICENSE)

## TL; DR
*Sharpen* **identifies places in your code that will benefit from introducing new C# language features**. It helps you to **learn new C# features quicker** and **critically refactor your existing code** to modern C#.

![Sharpen in action](https://raw.githubusercontent.com/ironcev/sharpen/master/images/demo.gif)

## Benefits at a Glance

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

### Critical Approach to New C# Features
Learn to ❤ C# but not blindly. Take love with a pinch of salt ;-)

*Sharpen* brings a critical view of C# features. It recommends applying them only if their usage will result in a "sharper" code. *Sharpen* is not shy of saying No! to a language feature.

### Consistent Usage of C# Features
Consistency matters. And your preferences, as well.

Once configured on your project, *Sharpen* ensures that usage of C# language features remains consistent over the whole codebase.

### Improving Code on a Larger Scope
Are you still having BackgroundWorkers in your code?

It's time to replace them with async-await! *Sharpen* is equipped with an intelligent heuristics that recognizes potential improvements of your code on a broader scope.

### Extensive Documentation on C# Language
Are you tired of searching for new C# features in random blog posts?

*Sharpen* comes with extensive built-in documentation on C# language features. It's a one-stop-shop for everything you ever wanted to know about the design and evolution of C#.

## Current Limitations
Note that in the current version of *Sharpen* the following features mentioned in the above chapters are still not available:

- Extensive documentation.
- Recommendations.
- Refactoring.
- Configuration.

## Installation

You can [install *Sharpen* directly from Visual Studio](https://github.com/sharpenrocks/Sharpen/wiki/Installing-Sharpen) by using Extensions dialog or you can [download it](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) from the Visual Studio Marketplace.

## Contributing
*Sharpen* is a volunteer effort. Covering the whole C# evolution is a humongous task that cannot be carried out by a single person. So pitch in and join the development! :-) Before contributing, please make sure to read the [contribution guidelines](CONTRIBUTING.md).

## Release Notes
All notable changes to the *Sharpen* extension are documented in the [changelog](https://github.com/ironcev/sharpen/blob/master/CHANGELOG.md). 

## License
*Sharpen* is licensed under the [MIT license](https://github.com/ironcev/sharpen/blob/master/LICENSE).
