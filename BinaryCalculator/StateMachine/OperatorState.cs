namespace BinaryCalculator.StateMachine
{
    internal class OperatorState<T> : ICalculatorState<T>
    {
        private readonly T _firstOperand;
        private readonly IBinaryOperator<T> _binaryOperator;

        public OperatorState(T firstOperand, IBinaryOperator<T> binaryOperator)
        {
            _firstOperand = firstOperand;
            _binaryOperator = binaryOperator;
        }

        public T CurrentValue => _firstOperand;

        public ICalculatorState<T> Clear()
        {
            return new OperatorState<T>(_firstOperand, _binaryOperator);
        }

        public ICalculatorState<T> ClearEntry()
        {
            return new FirstOperandState<T>(default!);
        }

        public ICalculatorState<T> EnterValue(T value)
        {
            return new SecondOperandState<T>(_firstOperand, value, _binaryOperator);
        }

        public ICalculatorState<T> Evaluate()
        {
            var secondOperand = _firstOperand;
            var lastOperation = _binaryOperator.CaptureSecondOperand(secondOperand);
            var result = lastOperation.Invoke(_firstOperand);
            return new ResultState<T>(result, lastOperation);
        }

        public ICalculatorState<T> EnterOperator(IBinaryOperator<T> binaryOperator)
        {
            return new OperatorState<T>(_firstOperand, binaryOperator);
        }
    }
}
