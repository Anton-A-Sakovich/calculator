namespace BinaryCalculator
{
    internal class Int32BinaryBuilder : INumberBuilder<int, bool>
    {
        public int AppendDigit(int number, bool digit)
        {
            return (number << 1) | (digit ? 1 : 0);
        }

        public int ToNumber(bool digit)
        {
            return digit ? 1 : 0;
        }
    }
}
