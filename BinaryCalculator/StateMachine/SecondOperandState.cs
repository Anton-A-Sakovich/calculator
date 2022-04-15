namespace BinaryCalculator.StateMachine
{
    internal class SecondOperandState<T> : ICalculatorState<T>
    {
        private readonly T _firstOperand;
        private readonly T _secondOperand;
        private readonly IBinaryOperator<T> _binaryOperator;

        public SecondOperandState(T firstOperand, T secondOperand, IBinaryOperator<T> binaryOperator)
        {
            _firstOperand = firstOperand;
            _secondOperand = secondOperand;
            _binaryOperator = binaryOperator;
        }

        public T CurrentValue => _secondOperand;

        public ICalculatorState<T> Clear()
        {
            return new FirstOperandState<T>(default!);
        }

        public ICalculatorState<T> ClearEntry()
        {
            return new OperatorState<T>(_firstOperand, _binaryOperator);
        }

        public ICalculatorState<T> EnterValue(T value)
        {
            return new SecondOperandState<T>(_firstOperand, value, _binaryOperator);
        }

        public ICalculatorState<T> Evaluate()
        {
            var lastOperation = _binaryOperator.CaptureSecondOperand(_secondOperand);
            var result = lastOperation.Invoke(_firstOperand);
            return new ResultState<T>(result, lastOperation);
        }

        public ICalculatorState<T> EnterOperator(IBinaryOperator<T> binaryOperator)
        {
            var result = _binaryOperator.CaptureSecondOperand(_secondOperand).Invoke(_firstOperand);
            return new SecondOperandState<T>(result, default!, binaryOperator);
        }
    }
}
