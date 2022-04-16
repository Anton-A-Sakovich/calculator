using BinaryCalculator.StateMachine;
using Moq;
using NUnit.Framework;
using System;

namespace BinaryCalculator.Tests.StateMachineTests
{
    [TestFixture]
    public class ResultStateTests
    {
        private const int _initialResult = 3;
        private const int _digit = 4;
        private readonly Func<int, int> _lastOperation = x => x + 2;

        private Mock<INumberBuilder<int, int>> _mockNumberBuilder = null!;

        private CalculatorStateAndValue<ResultState<int, int>> _before = null!;
        private CalculatorStateAndValue<ICalculatorState<int, int>> _after = null!;

        [SetUp]
        public void Setup()
        {
            _mockNumberBuilder = new Mock<INumberBuilder<int, int>>();
            _mockNumberBuilder.Setup(builder => builder.ToNumber(_digit)).Returns(_digit);

            _before = new CalculatorStateAndValue<ResultState<int, int>>
            {
                State = new ResultState<int, int>(_mockNumberBuilder.Object, _lastOperation),
                Value = _initialResult,
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
            _after = _before.EnterDigit(_digit);
            _after.Assert(_digit, _before.State);
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
            _after.Assert(_lastOperation.Invoke(_initialResult), _before.State);
        }
    }
}
