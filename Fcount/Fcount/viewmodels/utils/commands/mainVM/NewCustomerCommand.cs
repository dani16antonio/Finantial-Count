using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.mainVM
{
    class NewCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainAppPageVM mainAppPageVM;
        public NewCustomerCommand(MainAppPageVM mainAppPageVM)
        {
            this.mainAppPageVM = mainAppPageVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.mainAppPageVM.createUser();
        }
    }
}
