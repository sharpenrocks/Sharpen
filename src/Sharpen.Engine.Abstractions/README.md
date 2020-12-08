# Architectural Decisions

We assume that the Roslyn v2.4.0.0 API directly used in abstractions like e.g. `SyntaxTree`, `SyntaxNode`, or `FileLinePositionSpan` will remain backward compatible in newer Roslyn versions.

We will not add our own abstraction ower them unless definitely needed.

Later on, we can create tooling for static checking of backward compatibility of the used API.