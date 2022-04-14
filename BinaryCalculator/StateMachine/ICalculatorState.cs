namespace BinaryCalculator.StateMachine
{
    internal interface ICalculatorState<TNumber, TDigit>
    {
        TNumber FirstOperand { get; }

        ICalculatorState<TNumber, TDigit> StartBinaryOperation(IBinaryOperation<TNumber> operation);

        ICalculatorState<TNumber, TDigit> EnterDigit(TDigit digit);

        ICalculatorState<TNumber, TDigit> Clear();

        ICalculatorState<TNumber, TDigit> ClearEntry();

        ICalculatorState<TNumber, TDigit> Evaluate();
    }
}
