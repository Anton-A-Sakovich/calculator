using System;

namespace BinaryCalculator.StateMachine
{
    internal class CompletedOperationState<TNumber, TDigit> : ICalculatorState<TNumber, TDigit>
    {
        private readonly INumberArithmetics<TNumber, TDigit> _arithmetics;

        public TNumber FirstOperand { get; private set; }
        public Func<TNumber, TNumber>? CompletedOperation { get; private set; }

        public CompletedOperationState(INumberArithmetics<TNumber, TDigit> arithmetics, TNumber currentValue, Func<TNumber, TNumber>? completedOperation = null)
        {
            _arithmetics = arithmetics;

            FirstOperand = currentValue;
            CompletedOperation = completedOperation;
        }

        public ICalculatorState<TNumber, TDigit> StartBinaryOperation(IBinaryOperation<TNumber> operation)
        {
            return new PendingOperationState<TNumber, TDigit>(_arithmetics, FirstOperand, operation);
        }

        public ICalculatorState<TNumber, TDigit> Clear()
        {
            FirstOperand = _arithmetics.Zero;
            CompletedOperation = null;
            return this;
        }

        public ICalculatorState<TNumber, TDigit> ClearEntry()
        {
            FirstOperand = _arithmetics.Zero;
            return this;
        }

        public ICalculatorState<TNumber, TDigit> EnterDigit(TDigit digit)
        {
            FirstOperand = _arithmetics.AddDigit(FirstOperand, digit);
            return this;
        }

        public ICalculatorState<TNumber, TDigit> Evaluate()
        {
            if (_arithmetics.AreEqual(FirstOperand, _arithmetics.Zero) && CompletedOperation != null)
            {
                return new CompletedOperationState<TNumber, TDigit>(_arithmetics, CompletedOperation.Invoke(FirstOperand), CompletedOperation);
            }
            else
            {
                return this;
            }
        }
    }
}
