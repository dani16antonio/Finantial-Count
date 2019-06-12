using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands
{
    class BtnCreateUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public LoginViewModel mainViewModel { get; set; }

        public BtnCreateUserCommand(LoginViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.mainViewModel.startNewUserPage();
        }
    }
}
