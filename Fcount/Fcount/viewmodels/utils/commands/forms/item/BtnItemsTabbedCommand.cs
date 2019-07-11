using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Fcount.viewmodels.mainTabbedPages;

namespace Fcount.viewmodels.utils.commands.mainVM
{
    class BtnItemsTabbedCommand : ICommand
    {
        private NewItemVM itemsTabbedVM;

        public BtnItemsTabbedCommand(NewItemVM itemsTabbedVM)
        {
            this.itemsTabbedVM = itemsTabbedVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.itemsTabbedVM.CheckProperties();
        }

        public void Execute(object parameter)
        {
            this.itemsTabbedVM.ExecuteCreateBtn();
        }
        public void RaiseCanExecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
                handle(this, new EventArgs());
        }
    }
}
