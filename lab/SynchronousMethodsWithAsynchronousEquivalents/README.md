# Synchronous Methods with Asynchronous Equivalents

## Description

For the implementation of the `HardcodedLookupBasedEquivalentAsynchronousMethodFinder` we need a list of synchronous methods (actually, their names) that have (or could have) asynchronous equivalents.

For the details, see the implementation and the comments in the [SynchronousMethodsWithAsynchronousEquivalents.linq](SynchronousMethodsWithAsynchronousEquivalents.linq).

## Running the Experiment

Open the file in [LINQPad](http://www.linqpad.net/) and run it.

## Results

Although the heuristics is fairly simple, if not even trivial, the resulting list of method names gives excellent results in real-life code.