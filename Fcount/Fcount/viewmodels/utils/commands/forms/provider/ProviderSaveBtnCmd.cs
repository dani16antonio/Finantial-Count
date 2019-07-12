using Fcount.viewmodels.mainTabbedPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.tabbedVM.ProviderVM
{
    class ProviderSaveBtnCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private NewProviderVM ProviderTabbedVM;
        public ProviderSaveBtnCmd(NewProviderVM providerTabbedVM)
        {
            this.ProviderTabbedVM = providerTabbedVM;
        }

        public bool CanExecute(object parameter)
        {
            return this.ProviderTabbedVM.CheckProps();
        }

        public void Execute(object parameter)
        {
            this.ProviderTabbedVM.ExecuteSave();
        }
        public void RaiseCanExcecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
                handle(this, new EventArgs());
        }
    }
}
