using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace BinaryCalculator.Wpf
{
    internal class MainViewModel : ObservableObject
    {
        private readonly IBinaryCalculator _binaryCalculator;

        private int _displayedValue;

        public MainViewModel(IBinaryCalculator binaryCalculator)
        {
            _binaryCalculator = binaryCalculator;
            _displayedValue = _binaryCalculator.DisplayedValue;

            ClearCommand = new RelayCommand(OnClear);
            ClearEntryCommand = new RelayCommand(OnClearEntry);
            OneCommand = new RelayCommand(OnOne);
            ZeroCommand = new RelayCommand(OnZero);
            PlusCommand = new RelayCommand(OnPlus);
            MinusCommand = new RelayCommand(OnMinus);
            EqualCommand = new RelayCommand(OnEqual);
        }

        public int DisplayedValue
        {
            get => _displayedValue;
            set => SetProperty(ref _displayedValue, value);
        }

        public ICommand ClearCommand { get; }
        public ICommand ClearEntryCommand { get; }
        public ICommand OneCommand { get; }
        public ICommand ZeroCommand { get; }
        public ICommand PlusCommand { get; }
        public ICommand MinusCommand { get; }
        public ICommand EqualCommand { get; }

        private void OnClear()
        {
            _binaryCalculator.Clear();
            DisplayedValue = _binaryCalculator.DisplayedValue;
        }

        private void OnClearEntry()
        {
            _binaryCalculator.ClearEntry();
            DisplayedValue = _binaryCalculator.DisplayedValue;
        }

        private void OnOne()
        {
            _binaryCalculator.EnterDigit(true);
            DisplayedValue = _binaryCalculator.DisplayedValue;
        }

        private void OnZero()
        {
            _binaryCalculator.EnterDigit(false);
            DisplayedValue = _binaryCalculator.DisplayedValue;
        }

        private void OnPlus()
        {
            _binaryCalculator.EnterOperator(OperatorType.Add);
            DisplayedValue = _binaryCalculator.DisplayedValue;
        }

        private void OnMinus()
        {
            _binaryCalculator.EnterOperator(OperatorType.Subtract);
            DisplayedValue = _binaryCalculator.DisplayedValue;
        }

        private void OnEqual()
        {
            _binaryCalculator.Evaluate();
            DisplayedValue = _binaryCalculator.DisplayedValue;
        }
    }
}
