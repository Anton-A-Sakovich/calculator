namespace BinaryCalculator.StateMachine
{
    internal interface ICalculatorState<T>
    {
        T CurrentValue { get; }

        ICalculatorState<T> Clear();

        ICalculatorState<T> ClearEntry();

        ICalculatorState<T> Evaluate();

        ICalculatorState<T> EnterValue(T value);

        ICalculatorState<T> EnterOperator(IBinaryOperator<T> binaryOperator);
    }
}
