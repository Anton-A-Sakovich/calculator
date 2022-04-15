namespace BinaryCalculator.StateMachine
{
    internal class FirstOperandState<TNumber, TDigit> : ICalculatorState<TNumber, TDigit>
        where TNumber : struct
    {
        private readonly INumberBuilder<TNumber, TDigit> _numberBuilder;

        public FirstOperandState(INumberBuilder<TNumber, TDigit> numberBuilder)
        {
            _numberBuilder = numberBuilder;
        }

        public ICalculatorState<TNumber, TDigit> Clear(ref TNumber displayedValue)
        {
            displayedValue = default!;
            return this;
        }

        public ICalculatorState<TNumber, TDigit> ClearEntry(ref TNumber displayedValue)
        {
            return Clear(ref displayedValue);
        }

        public ICalculatorState<TNumber, TDigit> EnterDigit(ref TNumber displayedValue, TDigit digit)
        {
            displayedValue = _numberBuilder.AppendDigit(displayedValue, digit);
            return this;
        }

        public ICalculatorState<TNumber, TDigit> EnterOperator(ref TNumber displayedValue, IBinaryOperator<TNumber> binaryOperator)
        {
            return new OperatorState<TNumber, TDigit>(_numberBuilder, displayedValue, binaryOperator);
        }

        public ICalculatorState<TNumber, TDigit> Evaluate(ref TNumber displayedValue)
        {
            return this;
        }
    }
}
