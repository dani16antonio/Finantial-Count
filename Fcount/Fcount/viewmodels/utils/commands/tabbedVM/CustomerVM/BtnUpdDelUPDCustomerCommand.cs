using Fcount.viewmodels.mainTabbedPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.tabbedVM.CustomerVM
{
    class BtnUpdDelUPDCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private UpdDelCustomerVM updDelCustomerVM;
        public BtnUpdDelUPDCustomerCommand(UpdDelCustomerVM updDelCustomerVM)
        {
            this.updDelCustomerVM = updDelCustomerVM;
        }
        public bool CanExecute(object parameter)
        {
            return updDelCustomerVM.checkProp();
        }

        public void Execute(object parameter)
        {
            updDelCustomerVM.execute();
        }

        public void RaiseCanExecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
                handle(this, new EventArgs());
        }
    }
    class BtnUpdDelDELCustomerCommand : ICommand
    {
        private UpdDelCustomerVM updDelCustomerVM;

        public event EventHandler CanExecuteChanged;
        public BtnUpdDelDELCustomerCommand(UpdDelCustomerVM updDelCustomerVM)
        {
            this.updDelCustomerVM = updDelCustomerVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            updDelCustomerVM.RemoveCustomer();
        }
        
    }
}
