# Contributing to Sharpen

👍🎉❤️ First of all a big **Thanks!** for your willingness to contribute! ❤️🎉👍

Covering the whole C# evolution is a humongous task that cannot be carried out by a single person. I am happy to see that you are interested in contributing. :-)

The following is a set of guidelines for contributing to Sharpen. These are mostly guidelines, not rules. Use your best judgment, and feel free to propose changes to this document in a pull request.

## Contents

- [Code of Conduct](#code-of-conduct)
- [How Can I Contribute?](#how-can-i-contribute)
    - [Spread The Word](#spread-the-word)
    - [Become an Endgame Runner](#become-an-endgame-runner)
    - [Report Bugs](#report-bugs)
    - [Suggest Enhancements](#suggest-enhancements)
    - [Contribute to the Code](#contribute-to-the-code)
        - [C# Static Code Analysis](#c-static-code-analysis)
        - [Pull Requests](#pull-requests)
- [Styleguides](#styleguides)
    - [Git Commit Messages](#git-commit-messages)
    - [General C# Coding Conventions](#general-c-coding-conventions)
    - [Sharpen Naming Conventions](#sharpen-naming-conventions)
    - [Automatic Styleguides Checks](#automatic-styleguides-checks)
- [Credits](#credits)

## Code of Conduct

Sharpen project and everyone participating in it is governed by the [Contributor Covenant Code of Conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code.

## How Can I Contribute?

There are many ways you can contribute to Sharpen. Code contributions are just one of them.

### Spread The Word

Spreading the word about Sharpen is probably the easiest way to contribute. Here are some of the things you could do:

- Tell your colleagues and friends about Sharpen.
- Give it a star on GitHub.
- Leave a review on the [Sharpen's page on the Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen#review-details).
- Follow [Sharpen on Twitter](https://twitter.com/sharpenrocks). Twitt about it.
- Write a blog post.

### Become an Endgame Runner

As a [Sharpen's Endgame](https://github.com/sharpenrocks/Sharpen/wiki/Running-the-Endgame) runner you can help to test Sharpen's release candidates. Running the Endgame is easy and can take as little as a few minutes of your precious time. On the other hand, it contributes a lot to Sharpen's first-time quality. To become a runner drop me an email at ironcev@hotmail.com.

### Report Bugs

Before submitting a bug report perform a [cursory search](https://github.com/search?q=is%3Aissue+user%3Asharpenrocks+is%3Aopen+label%3Abug) to see if the problem has already been reported. If it has and the issue is still open, add a comment to the existing issue instead of opening a new one.

When submitting a bug try to explain the problem and include additional details to help reproduce the problem:

- **Use a clear and descriptive title** for the issue to identify the problem.
- **Describe the exact steps which reproduce the problem** in as many details as possible. For example, start by explaining how you started Sharpen, e.g., which menu command exactly you used. When listing steps, **don't just say what you did, but explain how you did it**. For example, if you selected a suggestion in the Sharpen Results window, explain if you used the mouse, or a keyboard shortcut or, e.g. `Up` and `Down` keyboard keys?
- **Provide specific examples to demonstrate the steps**. Ideally, include links to files or GitHub projects, or copy/pasteable snippets, which you use in those examples. If you're providing snippets in the issue, use [Markdown code blocks](https://help.github.com/articles/markdown-basics/#multiple-lines).
- **Describe the behavior you observed after following the steps** and point out what exactly is the problem with that behavior.
- **Explain which behavior you expected to see instead and why.**
- **Include screenshots and animated GIFs** which show you following the described steps and clearly demonstrate the problem. You can use [LICEcap](https://www.cockos.com/licecap/) to record GIFs.
- **If the problem wasn't triggered by a specific action**, describe what you were doing before the problem happened and share more information using the guidelines below.

### Suggest Enhancements

Enhancement suggestions are tracked as [GitHub issues](https://guides.github.com/features/issues/).

Before submitting an enhancement suggestion perform a [cursory search](https://github.com/search?q=is%3Aissue+user%3Asharpenrocks+is%3Aopen) to see if the enhancement has already been suggested. If it has and the issue is still open, add a comment to the existing issue instead of opening a new one.

When creating an enhancement issue provide the following information:

- **Use a clear and descriptive title** for the issue to identify the suggestion.
- **Provide a step-by-step description of the suggested enhancement** in as many details as possible.
- **Provide specific examples to demonstrate the steps**. Include copy/pasteable snippets which you use in those examples, as [Markdown code blocks](https://help.github.com/articles/markdown-basics/#multiple-lines).
- **Describe the current behavior** and **explain which behavior you expected to see instead** and why.
- **Explain why this enhancement would be useful** to most Sharpen users.

### Contribute to the Code

There are many areas in Sharpen's code where you can contribute. Static code analysis is just one of them. Here are the most prominent areas with some possible examples:

- UX and UI
    - E.g., enhancing Sharpen Results window with additional features like grouping, sorting or filtering.
    - E.g., enhancing dialogs for selection of projects and suggestions to be analyzed.
- Visual Studio integration
    - E.g., adding configurations to customize Sharpen's behavior.
- C# documentation
    - E.g., enhancing the built-in C# documentation content-wise.
    - E.g., enhancing the display and navigation through the C# documentation.
- C# language feature suggestions
    - E.g., adding new suggestions.
    - E.g., enhancing existing suggestions.
- Tests
    - E.g., adding unit tests for the existing suggestions.
    - E.g., adding smoke tests for the existing suggestions.
- Performance optimizations
    - E.g., optimizing existing suggestions.

#### C# Static Code Analysis

For most of the areas mentioned above, having a good knowledge of C# and WPF development is more than sufficient to start contributing. C# static code analysis - this means the development of new suggestions and refactorings - can be tricky, though. It requires an in-depth understanding of C# language and a good feeling for corner cases.

For example, this is a syntactically [perfectly valid C# private method](http://thehumbleprogrammer.com/buffalo-buffalo-buffalo-buffalo-buffalo-buffalo-buffalo-buffalo/#dynamic-dynamic-dynamic-dynamic-dynamic):

    dynamic dynamic(dynamic dynamic) => dynamic;

Depending on its surroundings it can have to different semantic meaning.

For an introduction to the crazy world of static code analysis, you can [read this](http://thehumbleprogrammer.com/the-could-dilemma/).

#### Pull Requests

Each pull request should be connected to a corresponding [Sharpen GitHub issue](https://github.com/sharpenrocks/Sharpen/issues). If there is no GitHub issue open for your potential contribution, open the issue first, either as a [bug report](#report-bugs) or an [enhancement](#suggest-enhancements).

Discussing your potential pull request and contribution before development greatly increases the chance that it will be accepted.

Pull request must adhere to the [styleguides](#styleguides).

Sometimes, making a pull request adhere to the standards listed in styleguides may be difficult. If the maintainers notice anything that we'd like changed, we'll maybe ask you to edit your pull request before we merge it. There's no need to open a new pull request, just edit the existing one. If you're not sure how to do that, [here is a guide](https://github.com/RichardLitt/knowledge/blob/master/github/amending-a-commit-guide.md) on the different ways you can update your pull request so that we can merge it.

Note however that updating pull requests can sometimes be an unnecessary overhead. In practice, if your contribution satisfies some minimum requirements on quality, it will most likely be accepted. Eventual smaller issues will be fixed by maintainers. Also, keep in mind that the code naturally evolves over time as we find a better way to express it. It might be that your original contribution will change over time. That's fine. It's a sign of a healthy and living project :-)

## Styleguides

### Git Commit Messages

For the reasoning behind the strict Git commit message rules, read the [How to Write a Git Commit Message](https://chris.beams.io/posts/git-commit/) by Chris Beams.

Sharpen uses a [commitizen](https://github.com/commitizen) dialect close to the [Udacity Git Commit Message Style Guide](https://udacity.github.io/git-styleguide/) with the following differences:

- There is an additional type `perf` for performance optimizations.
- Verbs are in the third person singular present. E.g. "Adds" instead of "Add" or "Added".

The best way to get a feeling for this convention is to take a look at the [existing commits](https://github.com/sharpenrocks/Sharpen/commits/master).

### General C# Coding Conventions

Sharpen's C# code mostly follows the [C# Coding Guidelines](https://csharpcodingguidelines.com/). Since they are a way too detailed to be read at once, here is a [shorter version](https://www.dofactory.com/reference/csharp-coding-standards) provided by *dofactory*. That shorter version will for sure be sufficient for contributions.

The best way to get a feeling for used C# conventions is to take a look at the existing code.

### Sharpen Naming Conventions

Sharpen has its own naming conventions for e.g., suggestions, smoke tests, etc. The best way to get a feeling for these conventions is to take a look at the existing code.

### Automatic Styleguides Checks

At the moment Sharpen does not have any automatic styleguides checks. It neither has static code analysis in place. Both are planned for the future. Meanwhile, while contributing, make sure to develop a feeling for the used conventions and do your best to follow them without automated support.

## Credits

"Contributing to Sharpen" is partially inspired and partially copied from the [Contributing to Atom](https://github.com/atom/atom/blob/master/CONTRIBUTING.md) document.

Sharpen is a volunteer effort. Pitch in and join the development! :-)

Thanks! ❤️ ❤️ ❤️