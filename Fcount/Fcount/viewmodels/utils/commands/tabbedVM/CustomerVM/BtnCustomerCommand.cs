using Fcount.models;
using Fcount.viewmodels.mainTabbedPages;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.tabbedVM.QuoteVM
{
    class BtnCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public CustomerTabbedVM customerTabbedVM;
        public BtnCustomerCommand(CustomerTabbedVM customerTabbedVM)
        {
            this.customerTabbedVM = customerTabbedVM;
        }
        public bool CanExecute(object parameter)
        {
            return parameter!=null;
        }

        public async void Execute(object parameter)
        {
            try
            {
                var listView = parameter as Xamarin.Forms.ListView;
                var customer = (Customer)listView.SelectedItem;
                var param = new NavigationParameters();
                param.Add("customer", customer);
                await customerTabbedVM.navigationService.NavigateAsync("NewCustomerPage", param);
            }
            catch (Exception)
            {
            }
        }
    }
}
