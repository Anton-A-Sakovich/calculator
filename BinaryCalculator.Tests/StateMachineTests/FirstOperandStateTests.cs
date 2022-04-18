using BinaryCalculator.StateMachine;
using Moq;
using NUnit.Framework;

namespace BinaryCalculator.Tests.StateMachineTests
{
    [TestFixture]
    public class FirstOperandStateTests
    {
        private const int _initialValue = 1;
        private const int _digit = 2;
        private const int _updatedValue = _initialValue * 10 + _digit;

        private Mock<INumberBuilder<int, int>> _mockNumberBuilder = null!;

        private CalculatorStateAndValue<FirstOperandState<int, int>> _before = null!;
        private CalculatorStateAndValue<ICalculatorState<int, int>> _after = null!;

        [SetUp]
        public void Setup()
        {
            _mockNumberBuilder = new Mock<INumberBuilder<int, int>>(MockBehavior.Strict);

            _before = new CalculatorStateAndValue<FirstOperandState<int, int>>
            {
                State = new FirstOperandState<int, int>(_mockNumberBuilder.Object),
                Value = _initialValue,
            };
        }

        [Test]
        public void Clear()
        {
            _after = _before.Clear();
            _after.Assert(0, _before.State);
        }

        [Test]
        public void ClearEntry()
        {
            _after = _before.ClearEntry();
            _after.Assert(0, _before.State);
        }

        [Test]
        public void EnterDigit()
        {
            _mockNumberBuilder.Setup(builder => builder.AppendDigit(_initialValue, _digit)).Returns(_updatedValue);

            _after = _before.EnterDigit(_digit);
            _after.Assert(_updatedValue, _before.State);

            _mockNumberBuilder.VerifyAll();
        }

        [Test]
        public void EnterOperator()
        {
            _after = _before.EnterOperator(new StubSubtractOperator());
            _after.Assert<OperatorState<int, int>>(_before.Value);
        }

        [Test]
        public void Evaluate()
        {
            _after = _before.Evaluate();
            _after.Assert(_before.Value, _before.State);
        }
    }
}
