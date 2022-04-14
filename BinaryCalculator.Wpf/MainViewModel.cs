using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace BinaryCalculator.Wpf
{
    internal class MainViewModel : ObservableObject
    {
        private string _displayText = "0";

        public MainViewModel()
        {
            ClearCommand = new RelayCommand(OnClear);
            ClearEntryCommand = new RelayCommand(OnClearEntry);
            OneCommand = new RelayCommand(OnOne);
            ZeroCommand = new RelayCommand(OnZero);
            PlusCommand = new RelayCommand(OnPlus);
            MinusCommand = new RelayCommand(OnMinus);
            EqualCommand = new RelayCommand(OnEqual);
        }

        public string DisplayText
        {
            get => _displayText;
            set => SetProperty(ref _displayText, value);
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

        }

        private void OnClearEntry()
        {

        }

        private void OnOne()
        {

        }

        private void OnZero()
        {

        }

        private void OnPlus()
        {

        }

        private void OnMinus()
        {

        }

        private void OnEqual()
        {

        }
    }
}
