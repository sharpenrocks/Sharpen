# Changelog
All notable changes to the "Sharpen" extension will be documented in this file.

The format of the file is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/).

Numbers in round brackets represent corresponding GitHub issues, if available.<br/>
Mentions in square brackets represent contributors.

## [0.10.1] - 2019-10-12
### Fixed
- Navigating with keyboard (up, down, left, right, ...) does not work in the Sharpen Results view (#29) [@tom-englert].
- Selected text in the Sharpen Results view is unreadable when the view loses focus (#28) [@tom-englert].

## [0.10.0] - 2019-10-10
### Added
- "Consider using ??= operator instead of assigning result of the ?? operator" suggestion.
- "Use ??= operator instead of assigning result of the ?? operator" suggestion.
- "What is/was new in C# X.Y?" link to MSDN documentation on C# version in the Sharpen Results view.
- "Learn more..." link to MSDN documentation on language features in the Sharpen Results view.

### Changed
- "Async streams" renamed to "Asynchronous streams".

## [0.9.0] - 2019-06-14
### Added
- "Consider replacing using statement with using declaration" suggestion.
- "Replace using statement with using declaration" suggestion.
- "Consider replacing switch statement containing only returns with switch expression" suggestion.
- "Consider replacing switch statement containing only assignments with switch expression" suggestion.
- "Replace switch statement containing only returns with switch expression" suggestion.
- "Replace switch statement containing only assignments with switch expression" suggestion.
- "Enable nullable context and declare local variable as nullable" suggestion.
- "Enable nullable context and declare property as nullable" suggestion.
- "Enable nullable context and declare field as nullable" suggestion.
- "Consider awaiting equivalent asynchronous method and yielding IAsyncEnumerable" suggestion.
- "Await [...] instead of calling [...]" suggestions support local functions.
- "Use var keyword in variable declaration with object creation" suggestion (#18) [@shankyjain7243].

### Fixed
- Async-await consider and await suggestions properly handle yielding.

## [0.8.0] - 2019-02-16
### Added
- Support for VS 2019.
- Loading Sharpen extension asynchronously.

### Fixed
- Sharpen does not support VS 2019 but is listed on VS Marketplace under that version (#19).
- Dependency alert: Visual Studio MPF 15.0 - already installed MPF 16.0 (#21).

## [0.7.0] - 2018-11-18
### Added
- "Analyze with Sharpen" menu item on the folder context menu.
- "Analyze with Sharpen" menu item on the file context menu.
- "Analyze with Sharpen" menu item on the project context menu.
- "Analyze with Sharpen" menu item on the solution context menu.
- "Analyze with Sharpen" menu item on the C# file editor context menu.

## [0.6.1] - 2018-10-07
### Added
- Better display of Async and Await findings in the Sharpen Results view.
- "Await task instead of calling Task.Result" suggestion.

## [0.6.0] - 2018-10-03
### Added
- "Await Task.Delay() instead of calling Thread.Sleep()" suggestion.
- "Await Task.WhenAll() instead of calling Task.WaitAll()" suggestion.
- "Await Task.WhenAny() instead of calling Task.WaitAny()" suggestion.
- "Await task instead of calling Task.Wait()" suggestion.
- "Await equivalent asynchronous method" suggestion.
- "Consider awaiting equivalent asynchronous method" suggestion.

### Fixed
- Consecutive analysis runs fully block Visual Studio (#15).

## [0.5.0] - 2018-05-25
### Added
- "Use nameof expression in dependency property declarations" suggestion.
- "Use nameof expression for throwing argument exceptions" suggestion.

## [0.4.0] - 2018-05-12
### Added
- "Discard out variables in object creations" suggestion.
- "Discard out variables in method invocations" suggestion.
- "Use out variables in object creations" suggestion.
- "Use expression body for local functions" suggestion.

## [0.3.0] - 2018-01-16
### Added
- "Use out variables in method invocations" suggestion.
- Grouping of the analysis results by C# language feature.

## [0.2.0] - 2017-12-14
### Added
- "Use default expression in optional constructor parameters" suggestion.
- "Use default expression in optional method parameters" suggestion.
- "Use default expression in return statements" suggestion.

## [0.1.1] - 2017-11-21
### Added
- Icon, preview image and release notes.

## [0.1.0] - 2017-11-21
### Added
- Grouping the results by C# Version > Suggestion > &lt;Project&gt;\File.
- Display of the analysis results in a tree view.
- Analysis of the whole solution.
- "Use expression body for get-only properties" suggestion.
- "Use expression body for get-only indexers" suggestion.
- "Use expression body for constructors" suggestion.
- "Use expression body for destructors" suggestion.
- "Use expression body for get accessors in properties" suggestion.
- "Use expression body for get accessors in indexers" suggestion.
- "Use expression body for set accessors in properties" suggestion.
- "Use expression body for set accessors in indexers" suggestion.