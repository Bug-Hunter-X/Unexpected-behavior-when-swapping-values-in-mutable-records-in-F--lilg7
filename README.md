# Unexpected Behavior When Swapping Values in Mutable Records in F#

This repository demonstrates an unexpected behavior encountered when attempting to swap the values of fields within a mutable record in F#.  The issue is subtle and can lead to unexpected results if not understood correctly. 

## The Problem

When swapping values within a mutable record using a function, a direct assignment within the function does not always modify the original record if it's not passed using the `byref` keyword. This is because F# by default passes the arguments by value rather than by reference unless you specify otherwise.

## Solution

The solution involves using the `byref` keyword when passing mutable records to functions to ensure that modifications within the function directly affect the original record.

## How to Reproduce

1. Clone this repository.
2. Open the `bug.fs` file to see the code demonstrating the unexpected behavior.
3. Open the `bugSolution.fs` file to see the corrected code demonstrating the correct way to swap values in mutable records.
4. Compile and run the files using a F# compiler. You'll observe the difference in output between the two versions.
