using System;

namespace BinaryCalculator.Tests
{
    internal class StubSubtractOperator : IBinaryOperator<int>
    {
        public Func<int, int> CaptureSecondOperand(int secondOperand)
        {
            return firstOperand => firstOperand - secondOperand;
        }
    }
}
