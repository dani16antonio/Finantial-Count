using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.mainVM
{
    class NewItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainAppPageVM MainAppPage;
        public NewItemCommand(MainAppPageVM MainAppPage)
        {
            this.MainAppPage=MainAppPage;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.MainAppPage.navigationService.NavigateAsync("NewItemPage");
        }
    }
}
