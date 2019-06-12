using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands
{
    class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public MainViewModel mainViewModel { get; set; }

        public LoginCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return this.mainViewModel.checkEntries();
        }

        public void Execute(object parameter)
        {
            this.mainViewModel.Navigate();
        }
    }
}
