# calculator
A Design-By-Example (a.k.a. Test-driven development) example of developing a pocket calculator in C#.

## Intro
I'm doing this partly as a training material for developers in my company and partly as a reference on how I approach Design-By-Example. 

The idea is to create a pocket calculator engine from scratch using Design-By-Example approach, following [The Three Laws of TDD](https://www.youtube.com/watch?v=qkblc5WRn-U), combined with SOLID and clean code practices. I will break up changes into as small commits as possible (at least at the beginning where it matters) so the steps are clear and simple to understand.

What I cannot show here is the IDE techniques of refactoring (in my case Visual Studio with a heavy use of Resharper), maybe some time in the future I will do a screen recording of such a thing.

Currently this is a work in progress.

## Steps (important commits)

Below is a list of commits that may be interesting from the point of understanding the Design-By-Example development process. I marked some of the steps with the RED/GREEN/REFACTOR prefix so it's clear [which one of the stages](http://blog.cleancoder.com/uncle-bob/2014/12/17/TheCyclesOfTDD.html) the step belongs to. Later, I remembered I could package a red-green-refactor cycles into pull requests (which I did).

If you want to understand a step, I recommend pulling that state of code and reviewing it in Visual Studio. The list will be updated as new steps are done.

* [RED: First test case - PressingNumberKeyDisplaysThatNumber](https://github.com/breki/calculator/commit/1c12d15b92217798e9e00d4d4eeb9e132ab74c92)
* [RED: Created stub methods for the test case](https://github.com/breki/calculator/commit/f7d377c8bdceb4f5e8ab17095cf6f9ed82499011)
* [RED: Created CalculatorEngine class. Test stub methods now use CalculatorEngine (still non-existent) methods for their work.](https://github.com/breki/calculator/commit/9458144b81b1ac22eb55747a8fccc0f446a51f7e)
* [RED: Created the needed methods in CalculatorEngine as stubs](https://github.com/breki/calculator/commit/e29df4b966db983c7f8840f763602428fb657ee2)
* [GREEN: Implemented a very naive versions of CalculatorEngine methods](https://github.com/breki/calculator/commit/d275258caf2f8151e0d147eb4460ff0e738c5375)
* [REFACTOR: Renamed "number" to "digit" to avoid confusion](https://github.com/breki/calculator/commit/b9104cb2d9ae6b02d38e56678e21651ca819e11b)
* [RED: Added new PressingTwoDigitKeysDisplaysBothDigitsInTheSameOrder test case](https://github.com/breki/calculator/commit/642d073cf9e8747818cce11ca4cd9e193387c841) - in hindsight, this one I should have probably broken into smaller chunks of work
* [GREEN: redesigned CalculatorEngine to pass both tests](https://github.com/breki/calculator/commit/b569f6753b1761495648f2d6bddd2eb75c1d09d0)
* [REFACTOR: cleaned up CalculatorEngine a bit and made its interface more restrictive](https://github.com/breki/calculator/commit/5b2b854edd674e0000fe8dcb55e3c8716e529405)
* [PressingDotInbetweenDigitsDisplaysTheDot test case covered](https://github.com/breki/calculator/commit/96f5e4eb94a5626136930c631cdfae43c22cef89)
* [IgnoresTheSecondDotKey test case covered](https://github.com/breki/calculator/commit/0af0400e59570f4b796f2b17081df7717dc2c552)
* [ShowsZeroInitially test case covered](https://github.com/breki/calculator/pull/1/files)
* [IgnoresLeadingZeros test case covered](https://github.com/breki/calculator/pull/2/files)
* [ClrKeyClearsTheDisplay test case covered](https://github.com/breki/calculator/pull/3/files)
* [PressingEqualsKeyAfterDigitsDoesNothing test case covered](https://github.com/breki/calculator/pull/4/files)
* [PressingPlusKeyAndThenEqualsDoublesTheValue test case covered](https://github.com/breki/calculator/pull/5/files)
* [EnteringDigitAfterPlusClearsThePreviousValueFromDisplay test case covered](https://github.com/breki/calculator/pull/6/files)
