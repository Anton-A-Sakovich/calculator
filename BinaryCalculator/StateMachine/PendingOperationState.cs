namespace BinaryCalculator.StateMachine
{
    internal class PendingOperationState<TNumber, TDigit> : ICalculatorState<TNumber, TDigit>
    {
        private readonly INumberArithmetics<TNumber, TDigit> _arithmetics;

        public TNumber FirstOperand { get; }
        public TNumber SecondOperand { get; private set; }
        public IBinaryOperation<TNumber> PendingOperation { get; private set; }

        public PendingOperationState(INumberArithmetics<TNumber, TDigit> arithmetics, TNumber firstOperand, IBinaryOperation<TNumber> pendingOperation)
        {
            _arithmetics = arithmetics;

            FirstOperand = firstOperand;
            SecondOperand = _arithmetics.Zero;
            PendingOperation = pendingOperation;
        }

        public ICalculatorState<TNumber, TDigit> StartBinaryOperation(IBinaryOperation<TNumber> operation)
        {
            if (_arithmetics.AreEqual(SecondOperand, _arithmetics.Zero))
            {
                PendingOperation = operation;
                return this;
            }
            else
            {
                var completedOperation = PendingOperation.ApplyTo(SecondOperand);
                var result = completedOperation.Invoke(FirstOperand);
                return new PendingOperationState<TNumber, TDigit>(_arithmetics, result, operation);
            }
        }

        public ICalculatorState<TNumber, TDigit> Clear()
        {
            return new CompletedOperationState<TNumber, TDigit>(_arithmetics, _arithmetics.Zero, completedOperation: null);
        }

        public ICalculatorState<TNumber, TDigit> ClearEntry()
        {
            if (_arithmetics.AreEqual(SecondOperand, _arithmetics.Zero))
            {
                return new CompletedOperationState<TNumber, TDigit>(_arithmetics, FirstOperand, completedOperation: null);
            }
            else
            {
                SecondOperand = _arithmetics.Zero;
                return this;
            }
        }

        public ICalculatorState<TNumber, TDigit> EnterDigit(TDigit digit)
        {
            SecondOperand = _arithmetics.AddDigit(SecondOperand, digit);
            return this;
        }

        public ICalculatorState<TNumber, TDigit> Evaluate()
        {
            var completedOperation = PendingOperation.ApplyTo(SecondOperand);
            var result = completedOperation.Invoke(FirstOperand);
            return new CompletedOperationState<TNumber, TDigit>(_arithmetics, result, completedOperation);
        }
    }
}
