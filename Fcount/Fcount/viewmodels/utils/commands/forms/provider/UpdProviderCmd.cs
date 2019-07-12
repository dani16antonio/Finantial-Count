using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Fcount.viewmodels.forms.provider;

namespace Fcount.viewmodels.utils.commands.forms.provider
{
    class UpdProviderCmd : ICommand
    {
        private UpdDelProviderVM updDelProviderVM;

        public UpdProviderCmd(UpdDelProviderVM updDelProviderVM)
        {
            this.updDelProviderVM = updDelProviderVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return updDelProviderVM.checkProps();
        }

        public void Execute(object parameter)
        {
            updDelProviderVM.ExecuteUpdate();
        }

        internal void RaiseCanExcecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
                handle(this, new EventArgs());
        }
    }

    class DelProviderCmd : ICommand
    {
        private UpdDelProviderVM updDelProviderVM;

        public DelProviderCmd(UpdDelProviderVM updDelProviderVM)
        {
            this.updDelProviderVM = updDelProviderVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            updDelProviderVM.ExecuteDelete();
        }
    }
}
