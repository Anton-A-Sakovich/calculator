namespace BinaryCalculator.StateMachine
{
    internal class FirstOperandState<T> : ICalculatorState<T>
    {
        private readonly T _operand;

        public FirstOperandState(T operand)
        {
            _operand = operand;
        }

        public T CurrentValue => _operand;

        public ICalculatorState<T> Clear()
        {
            return new FirstOperandState<T>(default!);
        }

        public ICalculatorState<T> ClearEntry()
        {
            return new FirstOperandState<T>(default!);
        }

        public ICalculatorState<T> EnterValue(T value)
        {
            return new FirstOperandState<T>(value);
        }

        public ICalculatorState<T> Evaluate()
        {
            return new ResultState<T>(_operand, value => value);
        }

        public ICalculatorState<T> EnterOperator(IBinaryOperator<T> binaryOperator)
        {
            return new OperatorState<T>(_operand, binaryOperator);
        }
    }
}
