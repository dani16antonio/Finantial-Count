using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.mainVM
{
    class NewProviderCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainAppPageVM mainAppPageVM;
        public NewProviderCmd(MainAppPageVM mainAppPageVM)
        {
            this.mainAppPageVM = mainAppPageVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await mainAppPageVM.navigationService.NavigateAsync("NewProviderPage");
        }
    }
}
