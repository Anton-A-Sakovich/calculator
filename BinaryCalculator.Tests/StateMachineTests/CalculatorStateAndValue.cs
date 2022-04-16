using BinaryCalculator.StateMachine;
using NUnit.Framework;
using NUnitAssert = NUnit.Framework.Assert;

namespace BinaryCalculator.Tests.StateMachineTests
{
    internal class CalculatorStateAndValue<TState>
        where TState : ICalculatorState<int, int>
    {
        public TState State { get; init; } = default!;
        public int Value { get; init; }

        public void Assert<TExpectedState>(int expectedValue, TExpectedState? expectedStateInstance = null)
            where TExpectedState : class, ICalculatorState<int, int>
        {
            NUnitAssert.That(Value, Is.EqualTo(expectedValue));
            NUnitAssert.That(State, Is.TypeOf<TExpectedState>());

            if (expectedStateInstance != null)
            {
                NUnitAssert.That(State, Is.EqualTo(expectedStateInstance));
            }
        }

        public CalculatorStateAndValue<ICalculatorState<int, int>> Clear()
        {
            var value = Value;
            var stateAfter = State.Clear(ref value);

            return new CalculatorStateAndValue<ICalculatorState<int, int>>
            {
                Value = value,
                State = stateAfter,
            };
        }

        public CalculatorStateAndValue<ICalculatorState<int, int>> ClearEntry()
        {
            var value = Value;
            var stateAfter = State.ClearEntry(ref value);

            return new CalculatorStateAndValue<ICalculatorState<int, int>>
            {
                Value = value,
                State = stateAfter,
            };
        }

        public CalculatorStateAndValue<ICalculatorState<int, int>> EnterDigit(int digit)
        {
            var value = Value;
            var stateAfter = State.EnterDigit(ref value, digit);

            return new CalculatorStateAndValue<ICalculatorState<int, int>>
            {
                Value = value,
                State = stateAfter,
            };
        }

        public CalculatorStateAndValue<ICalculatorState<int, int>> EnterOperator(IBinaryOperator<int> binaryOperator)
        {
            var value = Value;
            var stateAfter = State.EnterOperator(ref value, binaryOperator);

            return new CalculatorStateAndValue<ICalculatorState<int, int>>
            {
                Value = value,
                State = stateAfter,
            };
        }

        public CalculatorStateAndValue<ICalculatorState<int, int>> Evaluate()
        {
            var value = Value;
            var stateAfter = State.Evaluate(ref value);

            return new CalculatorStateAndValue<ICalculatorState<int, int>>
            {
                Value = value,
                State = stateAfter,
            };
        }
    }
}
