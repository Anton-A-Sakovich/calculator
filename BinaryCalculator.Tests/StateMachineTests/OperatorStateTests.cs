using BinaryCalculator.StateMachine;
using Moq;
using NUnit.Framework;

namespace BinaryCalculator.Tests.StateMachineTests
{
    [TestFixture]
    public class OperatorStateTests
    {
        private const int _firstOperand = 1;
        private const int _initialSecondOperand = _firstOperand;
        private const int _digit = 3;
        private const int _evaluatedValue = 2; // 1 + 1

        private Mock<IBinaryOperator<int>> _mockBinaryOperator = null!;
        private Mock<INumberBuilder<int, int>> _mockNumberBuilder = null!;

        private CalculatorStateAndValue<OperatorState<int, int>> _before = null!;
        private CalculatorStateAndValue<ICalculatorState<int, int>> _after = null!;

        [SetUp]
        public void Setup()
        {
            _mockNumberBuilder = new Mock<INumberBuilder<int, int>>(MockBehavior.Strict);
            _mockBinaryOperator = new Mock<IBinaryOperator<int>>(MockBehavior.Strict);

            _before = new CalculatorStateAndValue<OperatorState<int, int>>
            {
                State = new OperatorState<int, int>(_mockNumberBuilder.Object, _firstOperand, _mockBinaryOperator.Object),
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
            _after.Assert<SecondOperandState<int, int>>(0);
        }

        [Test]
        public void EnterDigit()
        {
            _mockNumberBuilder.Setup(builder => builder.ToNumber(_digit)).Returns(_digit);

            _after = _before.EnterDigit(_digit);
            _after.Assert<SecondOperandState<int, int>>(_digit);

            _mockNumberBuilder.VerifyAll();
        }

        [Test]
        public void EnterOperator()
        {
            // TODO: make ICalculatorState<TNumber, TDigit> expose its operator. Seems to be safe but will allow to test it.
            _after = _before.EnterOperator(new StubSubtractOperator());
            _after.Assert<OperatorState<int, int>>(_before.Value);
        }

        [Test]
        public void Evaluate()
        {
            _mockBinaryOperator.Setup(op => op.CaptureSecondOperand(_firstOperand)).Returns(x => x + _firstOperand);

            _after = _before.Evaluate();
            _after.Assert<ResultState<int, int>>(_evaluatedValue);

            _mockBinaryOperator.VerifyAll();
        }
    }
}
