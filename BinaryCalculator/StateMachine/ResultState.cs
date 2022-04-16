using System;

namespace BinaryCalculator.StateMachine
{
    internal class ResultState<TNumber, TDigit> : ICalculatorState<TNumber, TDigit>
        where TNumber : struct
    {
        private readonly INumberBuilder<TNumber, TDigit> _numberBuilder;
        private readonly Func<TNumber, TNumber> _lastOperation;

        public ResultState(INumberBuilder<TNumber, TDigit> numberBuilder, Func<TNumber, TNumber> lastOperation)
        {
            _numberBuilder = numberBuilder;
            _lastOperation = lastOperation;
        }

        public ICalculatorState<TNumber, TDigit> Clear(ref TNumber displayedValue)
        {
            displayedValue = default!;
            return new FirstOperandState<TNumber, TDigit>(_numberBuilder);
        }

        public ICalculatorState<TNumber, TDigit> ClearEntry(ref TNumber displayedValue)
        {
            displayedValue = default!;
            return this;
        }

        public ICalculatorState<TNumber, TDigit> EnterDigit(ref TNumber displayedValue, TDigit digit)
        {
            displayedValue = _numberBuilder.ToNumber(digit);
            return this;
        }

        public ICalculatorState<TNumber, TDigit> EnterOperator(ref TNumber displayedValue, IBinaryOperator<TNumber> binaryOperator)
        {
            return new OperatorState<TNumber, TDigit>(_numberBuilder, displayedValue, binaryOperator);
        }

        public ICalculatorState<TNumber, TDigit> Evaluate(ref TNumber displayedValue)
        {
            displayedValue = _lastOperation.Invoke(displayedValue);
            return this;
        }
    }
}
