using System;

namespace BinaryCalculator
{
    internal interface IBinaryOperator<T>
    {
        Func<T, T> CaptureSecondOperand(T secondOperand);
    }
}
