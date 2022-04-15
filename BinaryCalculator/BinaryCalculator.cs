using System;
using BinaryCalculator.StateMachine;

namespace BinaryCalculator
{
    internal class BinaryCalculator : IBinaryCalculator
    {
        private readonly IBinaryOperator<int> _addOperator = new AddOperator();
        private readonly IBinaryOperator<int> _subtractOperator = new SubtractOperator();

        private int _displayedValue = 0;
        private ICalculatorState<int, bool> _calculatorState = new FirstOperandState<int, bool>(new Int32BinaryBuilder());

        public int DisplayedValue => _displayedValue;

        public void Clear()
        {
            _calculatorState = _calculatorState.Clear(ref _displayedValue);
        }

        public void ClearEntry()
        {
            _calculatorState = _calculatorState.ClearEntry(ref _displayedValue);
        }

        public void EnterDigit(bool digit)
        {
            _calculatorState = _calculatorState.EnterDigit(ref _displayedValue, digit);
        }

        public void EnterOperator(OperatorType operatorType)
        {
            var binaryOperator = operatorType switch
            {
                OperatorType.Add => _addOperator,
                OperatorType.Subtract => _subtractOperator,
                _ => throw new ArgumentOutOfRangeException(nameof(operatorType))
            };

            _calculatorState = _calculatorState.EnterOperator(ref _displayedValue, binaryOperator);
        }

        public void Evaluate()
        {
            _calculatorState = _calculatorState.Evaluate(ref _displayedValue);
        }
    }
}
