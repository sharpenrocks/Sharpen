# Changelog
All notable changes to the "Sharpen" extension will be documented in this file.

The format of the file is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/).

## [Unreleased]
### Added
- "Analyze with Sharpen" menu item on the C# file editor context menu

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