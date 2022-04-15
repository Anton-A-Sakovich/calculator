namespace BinaryCalculator
{
    public interface IBinaryCalculator
    {
        int DisplayedValue { get; }

        void Clear();

        void ClearEntry();

        void EnterDigit(bool digit);

        void EnterOperator(OperatorType operatorType);

        void Evaluate();
    }
}
