namespace BinaryCalculator.StateMachine
{
    internal class OperatorState<TNumber, TDigit> : ICalculatorState<TNumber, TDigit>
        where TNumber : struct
    {
        private readonly INumberBuilder<TNumber, TDigit> _numberBuilder;

        private readonly TNumber _firstOperand;
        private readonly IBinaryOperator<TNumber> _binaryOperator;

        public OperatorState(INumberBuilder<TNumber, TDigit> numberBuilder, TNumber firstOperand, IBinaryOperator<TNumber> binaryOperator)
        {
            _numberBuilder = numberBuilder;

            _firstOperand = firstOperand;
            _binaryOperator = binaryOperator;
        }

        public ICalculatorState<TNumber, TDigit> Clear(ref TNumber displayedValue)
        {
            displayedValue = default!;
            return new FirstOperandState<TNumber, TDigit>(_numberBuilder);
        }

        public ICalculatorState<TNumber, TDigit> ClearEntry(ref TNumber displayedValue)
        {
            displayedValue = default!;
            return this;
        }

        public ICalculatorState<TNumber, TDigit> EnterDigit(ref TNumber displayedValue, TDigit digit)
        {
            displayedValue = _numberBuilder.ToNumber(digit);
            return new SecondOperandState<TNumber, TDigit>(_numberBuilder, _firstOperand, _binaryOperator);
        }

        public ICalculatorState<TNumber, TDigit> EnterOperator(ref TNumber displayedValue,IBinaryOperator<TNumber> binaryOperator)
        {
            return new OperatorState<TNumber, TDigit>(_numberBuilder, _firstOperand, binaryOperator);
        }

        public ICalculatorState<TNumber, TDigit> Evaluate(ref TNumber displayedValue)
        {
            var secondOperand = _firstOperand;
            var lastOperation = _binaryOperator.CaptureSecondOperand(secondOperand);
            var result = lastOperation.Invoke(_firstOperand);

            displayedValue = result;
            return new ResultState<TNumber, TDigit>(_numberBuilder, lastOperation);
        }
    }
}
