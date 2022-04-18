# Binary Calculator

This is a simple WPF .NET 6 application demonstrating basics of WPF layout, MVVM architectural pattern, dependency injection pattern based on
`IServiceCollection` from `Microsoft.Extensions.DependencyInjection.Abstractions` package, unit tests based on NUnit and  Moq, and calculator
state machine.

## Calculator State Machine

The logic for the calculator state machine used in this example was taken from the default Calculator app in Windows 10 (__Standard__ mode).

Although the sample application is for binary calculator, the state machine is agnostic to which numeric system is used. The machine
can be used for a decimal calculator or any other type of calculator as well. In fact, the decimal variant of the state machine was used
in tests as it is much more readable.

### Calculator State Machine States

The following states were used to model a calculator:

1. `FirstOperandState` -- the state at which the user enters digits to build the first operand of a binary operation before entering
a special symbol, such as a binary operator or equal sign;

2. `OperatorState` -- the state into which the machine enters after the user enters a binary operator; the machine remains in this state
as long as the user continues to enter binary operator symbols;

3. `SecondOperandState` -- the state at which the user enters digits to build the second operand of a binary operation before entering
a special symbol, such as a binary operator symbol or equal sign;

4. `ResultState` -- the state which displayes the result of the selected binary operation and is able to reproduce the last step.

### Calculator State Machine Transitions

Each state has 5 possible transitions from it (possibly back to itself):

1. `Clear` -- the user enters "C";
2. `ClearEntry` -- the user enters "CE";
3. `EnterDigit` -- the user enters any digit;
4. `EnterOperator` -- the user enters any binary operator;
5. `Evaluate` -- the user enters equal sign.

The transitions table is as follows:

|  | Clear | ClearEntry | EnterDigit | EnterOperator | Evaluate |
| --- | --- | --- | --- | --- | --- |
| `FirstOperandState` | `FirstOperandState` | `FirstOperandState` | `FirstOperandState` | `OperatorState` | `FirstOperandState` |
| `OperatorState` | `FirstOperandState` | `SecondOperandState` | `SecondOperandState` | `OperatorState` | `ResultState` |
| `SecondOperandState` | `FirstOperandState` | `SecondOperandState` | `SecondOperandState` | `OperatorState` | `ResultState` |
| `ResultState` | `FirstOperandState` | `ResultState` | `ResultState` | `OperatorState` | `ResultState` |
