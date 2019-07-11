using Fcount.viewmodels.forms.item;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.forms.item
{
    class BtnUpdItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private UpdDelItemVM updDelItemVM;
        public BtnUpdItemCommand(UpdDelItemVM updDelItemVM)
        {
            this.updDelItemVM = updDelItemVM;
        }

        public bool CanExecute(object parameter)
        {
            return this.updDelItemVM.CheckProps();
        }

        public void Execute(object parameter)
        {
            this.updDelItemVM.ExecuteUpdate();
        }
        public void RaiseCanExecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
                handle(this, new EventArgs());
        }
    }
}
