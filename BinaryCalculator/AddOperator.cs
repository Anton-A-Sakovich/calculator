using System;

namespace BinaryCalculator
{
    internal class AddOperator : IBinaryOperator<int>
    {
        public Func<int, int> CaptureSecondOperand(int secondOperand)
        {
            return firstOperand => firstOperand + secondOperand;
        }
    }
}
