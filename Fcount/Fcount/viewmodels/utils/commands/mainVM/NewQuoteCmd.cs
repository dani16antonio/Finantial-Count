using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.mainVM
{
    class NewQuoteCmd : ICommand
    {
        private MainAppPageVM mainAppPageVM;

        public NewQuoteCmd(MainAppPageVM mainAppPageVM)
        {
            this.mainAppPageVM = mainAppPageVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await mainAppPageVM.navigationService.NavigateAsync("NewQuotePage");
        }
    }
}
