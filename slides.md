# Design By Example (a.k.a. Test-Driven Development)

## What is Design By Example?
- Write the tests **before** writing the code itself
- Development process that relies on repetition of short cycles (red-green-refactor)

## Red-green-refactor cycle
1. Red: create a test that fails
2. Green: write production code that makes that test pass
3. Refactor: clean up the mess you made
- [Robert C. Martin claims](http://blog.cleancoder.com/uncle-bob/2014/12/17/TheCyclesOfTDD.html) that cycle takes a minute or so
  - So refactoring is done on a minute-by-minute basis (almost continuously)
- I recommend micro-commits, after the end of each cycle
  - This way you can always fall back to the previous (passing!) state if the approach fails 

## [The Three Laws of TDD](http://butunclebob.com/ArticleS.UncleBob.TheThreeRulesOfTdd)
1. You must write a failing test before you write any production code.
2. You must not write more of a test than is sufficient to fail, or fail to compile.
3. You must not write more production code than is sufficient to make the currently failing test pass.
- For most developers, this is the tough pill to swallow 
- Encourages the line-by-line granularity of development
  - A "line" of test code
  - Then a "line" of the production code
- A nano-cycle of TDD, happens dozen of times within the red-green-refactor cycle
- See [The Three Laws of TDD (Featuring Kotlin)](https://www.youtube.com/watch?v=qkblc5WRn-U)

## Why Design By Example?
- Breaks the problem into small, iterative steps
- Encourages simple design (KISS, YAGNI) and low coupling
- Forces the code to be testable
- Gives instant feedback
- Inspires confidence
- At any given moment, all of the tests (except the last one) pass
- Allows cheaper development of new features
 
## Refactoring to clean code
- A very important step in the process
- The code becomes hard to test -> it does too much, needs breaking up
- The goal is [SOLID code](http://butunclebob.com/ArticleS.UncleBob.PrinciplesOfOod)

## Common Misconceptions
- "I write tests after the code is written, this is the same as TDD"
  - no, because the **tests do no drive your design**
  - it's also not fun: you already know (or think you know) the code works, so writing tests to confirm that is tedious (and a lot of times difficult, since the code was not designed to be testable)
- Design By Example is not about testing
  - the goal is to drive the design through the actual usage
  - tests are just a tool to achieve the goal
  - tests are a by-product of the process
- "It's slow"
  - Take into account the long debugging sessions (sometimes in production)
  - Take into account the time it takes to modify the code when a new feature needs to be implemented
  
## Challenges
- Breaking the existing habits:
   - the urge to write production code without tests
   - the urge not the clean the code after it starts to work
   - the urge to rely on (expensive) debugging sessions
- Learning how to write maintainable code
- Learning to use development tools efficiently:
  - it is vital for refactoring
  - a good knowledge of Visual Studio / Resharper
  - learning keyboard shortcuts

## Example
- [calculator](https://github.com/breki/calculator) - example of developing a pocket calculator in C# using Design By Example process (by me)

