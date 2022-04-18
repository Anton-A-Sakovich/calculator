using BinaryCalculator.StateMachine;
using Moq;
using NUnit.Framework;

namespace BinaryCalculator.Tests.StateMachineTests
{
    [TestFixture]
    public class SecondOperandStateTests
    {
        private const int _firstOperand = 1;
        private const int _initialSecondOperand = 2;
        private const int _digit = 4;
        private const int _updatedSecondOperand = 24;
        private const int _evaluatedValue = 3;

        private Mock<IBinaryOperator<int>> _mockBinaryOperator = null!;
        private Mock<INumberBuilder<int, int>> _mockNumberBuilder = null!;

        private CalculatorStateAndValue<SecondOperandState<int, int>> _before = null!;
        private CalculatorStateAndValue<ICalculatorState<int, int>> _after = null!;

        [SetUp]
        public void Setup()
        {
            _mockNumberBuilder = new Mock<INumberBuilder<int, int>>(MockBehavior.Strict);
            _mockBinaryOperator = new Mock<IBinaryOperator<int>>(MockBehavior.Strict);

            _before = new CalculatorStateAndValue<SecondOperandState<int, int>>
            {
                State = new SecondOperandState<int, int>(_mockNumberBuilder.Object, _firstOperand, _mockBinaryOperator.Object),
                Value = _initialSecondOperand,
            };
        }

        [Test]
        public void Clear()
        {
            _after = _before.Clear();
            _after.Assert<FirstOperandState<int, int>>(0);
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
            _mockNumberBuilder.Setup(builder => builder.AppendDigit(_initialSecondOperand, _digit)).Returns(_updatedSecondOperand);

            _after = _before.EnterDigit(_digit);
            _after.Assert(_updatedSecondOperand, _before.State);

            _mockNumberBuilder.VerifyAll();
        }

        [Test]
        public void EnterOperator()
        {
            _mockBinaryOperator.Setup(op => op.CaptureSecondOperand(_initialSecondOperand)).Returns(x => x + _initialSecondOperand);

            _after = _before.EnterOperator(new StubSubtractOperator());
            _after.Assert<OperatorState<int, int>>(_evaluatedValue);

            _mockBinaryOperator.VerifyAll();
        }

        [Test]
        public void Evaluate()
        {
            _mockBinaryOperator.Setup(op => op.CaptureSecondOperand(_initialSecondOperand)).Returns(x => x + _initialSecondOperand);

            _after = _before.Evaluate();
            _after.Assert<ResultState<int, int>>(_evaluatedValue);

            _mockBinaryOperator.VerifyAll();
        }
    }
}
