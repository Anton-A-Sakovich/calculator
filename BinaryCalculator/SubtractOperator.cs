using System;

namespace BinaryCalculator
{
    internal class SubtractOperator : IBinaryOperator<int>
    {
        public Func<int, int> CaptureSecondOperand(int secondOperand)
        {
            return firstOperand => firstOperand - secondOperand;
        }
    }
}
