namespace BinaryCalculator.Tests
{
    internal class StubInt32DecimalBuilder : INumberBuilder<int, int>
    {
        public int AppendDigit(int number, int digit)
        {
            return number * 10 + digit;
        }

        public int ToNumber(int digit)
        {
            return digit;
        }
    }
}
