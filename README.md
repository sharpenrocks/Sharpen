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

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/faster-learning-of-new-csharp-features.png" alt="Faster Learning of New C# Features" style="max-width:100%;">
</p>

### Critical Approach to New C# Features
Learn to ❤ C# but not blindly. Take love with a pinch of salt ;-)

*Sharpen* brings a critical view of C# features. It recommends applying them only if their usage will result in a "sharper" code. *Sharpen* is not shy of saying No! to a language feature.

### Consistent Usage of C# Features
Consistency matters. And your preferences, as well.

Once configured on your project, *Sharpen* ensures that usage of C# language features remains consistent over the whole codebase.

### Code Refactoring on Arbitrary Scale
Safely refactor your code by a single mouse click.

*Sharpen* can refactor your code on an arbitrary scale: single place in code, single file, or a whole project, or solution. At the same time, it gives you full control over the scope and nature of the refactorings.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/code-refactoring-on-arbitrary-scale.png" alt="Code Refactoring on Arbitrary Scale" style="max-width:100%;">
</p>

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
