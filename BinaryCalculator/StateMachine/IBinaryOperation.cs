using System;

namespace BinaryCalculator.StateMachine
{
    internal interface IBinaryOperation<TNumber>
    {
        Func<TNumber, TNumber> ApplyTo(TNumber secondOperand);
    }
}
