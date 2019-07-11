using Fcount.viewmodels.forms.item;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.tabbedVM.itemVM
{
    class ItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ItemsTabbedVM itemsTabbedVM;
        public ItemCommand(ItemsTabbedVM itemsTabbedVM)
        {
            this.itemsTabbedVM = itemsTabbedVM;
        }
        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }

        public void Execute(object parameter)
        {
            this.itemsTabbedVM.ItemSelected(parameter);
        }
    }
}
