namespace BinaryCalculator.StateMachine
{
    internal interface INumberArithmetics<TNumber, TDigit>
    {
        TNumber Zero { get; }

        TNumber AddDigit(TNumber number, TDigit digit);

        bool AreEqual(TNumber first, TNumber second);
    }
}
