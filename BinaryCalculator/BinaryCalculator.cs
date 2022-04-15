using System;
using BinaryCalculator.StateMachine;

namespace BinaryCalculator
{
    internal class BinaryCalculator : IBinaryCalculator
    {
        private readonly IBinaryOperator<int> _addOperator;
        private readonly IBinaryOperator<int> _subtractOperator;

        private int _displayedValue;
        private ICalculatorState<int, bool> _calculatorState;

        public BinaryCalculator(INumberBuilder<int, bool> numberBuilder, IBinaryOperator<int> addOperator, IBinaryOperator<int> subtractOperator)
        {
            _addOperator = addOperator;
            _subtractOperator = subtractOperator;

            _displayedValue = 0;
            _calculatorState = new FirstOperandState<int, bool>(numberBuilder);
        }
        
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
