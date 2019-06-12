using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands
{
    class BtnLoginCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;

        public LoginViewModel mainViewModel { get; set; }

        public BtnLoginCommand(LoginViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return this.mainViewModel.checkEntries();
        }

        public void Execute(object parameter)
        {
            this.mainViewModel.login();
        }
        public void RaiseCanExecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
                handle(this, new EventArgs());
        }
    }
}
