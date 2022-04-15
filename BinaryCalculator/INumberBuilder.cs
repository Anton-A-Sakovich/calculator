namespace BinaryCalculator
{
    internal interface INumberBuilder<T, TDigit>
    {
        T AppendDigit(T number, TDigit digit);

        T ToNumber(TDigit digit);
    }
}
