﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinaryCalculator.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = App.Current.Services.GetRequiredService<MainViewModel>();
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            var viewModel = (DataContext as MainViewModel)!;

            switch (e.Key)
            {
                case Key.C:
                    viewModel.ClearCommand.Execute(null);
                    break;
                case Key.Delete:
                    viewModel.ClearEntryCommand.Execute(null);
                    break;
                case Key.D1:
                case Key.NumPad1:
                    viewModel.OneCommand.Execute(null);
                    break;
                case Key.D0:
                case Key.NumPad0:
                    viewModel.ZeroCommand.Execute(null);
                    break;
                case Key.Add:
                    viewModel.PlusCommand.Execute(null);
                    break;
                case Key.Subtract:
                    viewModel.MinusCommand.Execute(null);
                    break;
                case Key.Enter:
                    viewModel.EqualCommand.Execute(null);
                    break;
            }

            base.OnKeyUp(e);
        }
    }
}