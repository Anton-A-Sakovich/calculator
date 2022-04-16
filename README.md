# Binary Calculator

This is a simple WPF .NET 6 application demonstrating basics of WPF layout, MVVM architectural pattern, dependency injection pattern based on
`IServiceCollection` from `Microsoft.Extensions.DependencyInjection.Abstractions` package, unit tests based on NUnit and  Moq, and calculator
state machine.

## Calculator State Machine

The logic for the calculator state machine used in this example was taken from the default Calculator app in Windows 10.

> Note that different modes of Windows Calculator app (Standard, Scientific, Programmer, etc.) use slightly different state machines
> in regard to edge cases like pressing "=" after "+". __Standard__ mode was used for the state machine in this sample app.

Although the sample application is for binary calculator, the state machine is agnostic to which numeric system is used. The machine
can be used for a decimal calculator or any other type of calculator as well. In fact, the decimal variant of the state machine was used
in tests as it is much more readable.
