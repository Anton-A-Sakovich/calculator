using System;

namespace BinaryCalculator.Tests
{
    internal class StubAddOperator : IBinaryOperator<int>
    {
        public Func<int, int> CaptureSecondOperand(int secondOperand)
        {
            return firstOperand => firstOperand + secondOperand;
        }
    }
}
