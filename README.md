# Sharpen
*Sharpen* is a Visual Studio extension that intelligently introduces new C# language features into your existing code base. It makes your code smaller, simpler, faster, more expressive and more readable, in one word - sharper.

[![Twitter](https://img.shields.io/badge/twitter-sharpenrocks-brightgreen.svg?logo=twitter)](https://twitter.com/sharpenrocks)
[![Visual Studio Marketplace](https://img.shields.io/badge/visual%20studio%20marketplace-v0.5.0-blue.svg)](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen)
[![AppVeyor](https://img.shields.io/appveyor/ci/ironcev/sharpen.svg)](https://ci.appveyor.com/project/ironcev/sharpen)
[![GitHub release](https://img.shields.io/github/release/ironcev/sharpen/all.svg)](https://github.com/ironcev/sharpen/releases)
[![License](https://img.shields.io/github/license/ironcev/sharpen.svg)](https://github.com/ironcev/sharpen/blob/master/LICENSE)

## About
*Sharpen* uses static code analysis to **identify places in your code that will benefit of introducing new C# language features**. The fact that a new language feature *can* be used at a certain place in code, does not mean that it *should* be used. *Sharpen* helps you make an informed decision by providing both positive and negative recommendations. Once your decision is made, *Sharpen* can **refactor your code on an arbitrary scale**: single place in code, single file, or a whole project, or solution.

An image is worth a thousand words, therefore:

![Sharpen in action](https://raw.githubusercontent.com/ironcev/sharpen/master/images/demo.gif)

You can [install *Sharpen* from the Visual Studio marketplace](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen).

The below chapters describe in more detail the major benefits of *Sharpen*.

### Faster Learning of New Language Features
C# is a fast evolving language. This fast evolution and short release cycles make it difficult to keep pace with new language features, no matter how exciting and useful they are. Over the years I gave numerous talks and workshops on new C# language features. I learned that **the best way to understand and adopt a language feature is to meaningfully apply it to an existing code base, whenever possible**. The word *meaningfully* plays a major role here. Simplified, artificial code samples often used to introduce new language features lack a meaningful context around them. This makes the features harder to stick and could in worst case end up in using them blindly and non-critically.

*Sharpen* comes with **an extensive documentation on C# language features**. At the same time, **it points to places in real-life production code, your code!, where those features should and should not be used**. It puts new C# language features in a meaningful context. This speeds up the learning process. It also helps to develop critical and balanced view on new language features.

<p align="center">
    <img src="https://raw.githubusercontent.com/ironcev/sharpen/master/images/faster-learning-of-new-language-features.png" alt="Sharpen puts new C# language features in a meaningful context." style="max-width:100%;">
</p>

### Critical Usage of New Language Features
Turning a perfectly readable and easy understandable nested `foreach` loop into a single 400-character-long line of incomprehensible LINQ is not the best way to utilize LINQ. Yet I witnessed it many times when recommendations coming from static code analysis tools were taken non-critically. By providing well explained recommendations, both positive and negative, *Sharpen* **helps you develop a critical view on new language features**. It teaches you to apply them only on the places where their usage will actually result in "sharper" code.

### Consistent Usage of Language Features
Once configured on your project, *Sharpen* helps you **ensure that a certain C# language feature is consistently used on the whole code base**. *Sharpen* can be configured globally on the machine level, or on a solution and project level.

### Code Refactorings on Arbitrary Scale
Once you trust the given *Sharpen* recommendations, **you can safely refactor your existing code by a single mouse click**. *Sharpen* can refactor code on an arbitrary scale, giving you a full control over the scope of refactoring. For example, you can apply the *Use expression body for get-only properties* suggestion on highly recommended places in the whole solution and at the same time apply some less recommended suggestions only on a single occurrence in code.

### Improving the Design on a Larger Scope
Certain language and corresponding .NET Framework features can simplify architecture and overall design of your code. Replacing `BackgroundWorker`s with `async-await` or replacing locally used data-only classes with tuples are just two examples. *Sharpen* comes with an **intelligent heuristics** that recognizes such places and gives appropriate suggestions. These suggestions go beyond refactoring only a local point in code. They rather aim to **improve the design of your code base on a larger scope**.

Note that in the current version of *Sharpen* the following features mentioned in the above chapters are still not available:

- Extensive documentation.
- Recommendations.
- Refactorings.
- Configuration.

## Release Notes
All notable changes to the *Sharpen* extension are documented in the [changelog](https://github.com/ironcev/sharpen/blob/master/CHANGELOG.md). Below is the excerpt from the changelog that lists only the summary of major changes.

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