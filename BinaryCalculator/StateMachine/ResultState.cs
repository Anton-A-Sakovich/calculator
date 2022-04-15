using System;

namespace BinaryCalculator.StateMachine
{
    internal class ResultState<T> : ICalculatorState<T>
    {
        private readonly T _result;
        private readonly Func<T, T> _lastOperation;

        public ResultState(T result, Func<T, T> lastOperation)
        {
            _result = result;
            _lastOperation = lastOperation;
        }

        public T CurrentValue => _result;

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
            return new ResultState<T>(_lastOperation.Invoke(_result), _lastOperation);
        }

        public ICalculatorState<T> EnterOperator(IBinaryOperator<T> binaryOperator)
        {
            return new OperatorState<T>(_result, binaryOperator);
        }
    }
}
