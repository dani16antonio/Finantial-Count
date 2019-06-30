using Fcount.viewmodels.forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.forms.customer
{
    class BtnCreateCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public NewCustomerVM newCustomerVM;
        public BtnCreateCustomerCommand(NewCustomerVM newCustomerVM)
        {
            this.newCustomerVM = newCustomerVM;
        }
        public bool CanExecute(object parameter)
        {
            return this.newCustomerVM.CheckProp();
        }

        public void Execute(object parameter)
        {
            this.newCustomerVM.CreateCostumer();
        }

        public void RaiseCanExecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
                handle(this, new EventArgs());
        }
    }
}
