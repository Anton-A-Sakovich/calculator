namespace BinaryCalculator.StateMachine
{
    internal interface ICalculatorState<TNumber, TDigit>
        where TNumber : struct
    {
        ICalculatorState<TNumber, TDigit> Clear(ref TNumber displayedValue);

        ICalculatorState<TNumber, TDigit> ClearEntry(ref TNumber displayedValue);

        ICalculatorState<TNumber, TDigit> EnterDigit(ref TNumber displayedValue, TDigit digit);

        ICalculatorState<TNumber, TDigit> EnterOperator(ref TNumber displayedValue, IBinaryOperator<TNumber> binaryOperator);

        ICalculatorState<TNumber, TDigit> Evaluate(ref TNumber displayedValue);
    }
}
