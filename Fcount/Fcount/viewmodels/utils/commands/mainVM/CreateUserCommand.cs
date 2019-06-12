using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands
{
    class CreateUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel mainViewModel { get; set; }

        public CreateUserCommand(MainViewModel mainViewModel)
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
