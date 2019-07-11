using Fcount.viewmodels.forms.item;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.forms.item
{
    class BtnDelItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private UpdDelItemVM updDelItemVM;

        public BtnDelItemCommand(UpdDelItemVM updDelItemVM)
        {
            this.updDelItemVM = updDelItemVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            updDelItemVM.ExecuteDelete();
        }
    }
}
