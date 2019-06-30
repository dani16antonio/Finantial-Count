using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands.tabbedVM.QuoteVM;
using Prism.AppModel;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Fcount.viewmodels.mainTabbedPages
{
    class CustomerTabbedVM:ViewModelBase, IPageLifecycleAware
    {
        /// <summary>
        /// Clase View Model de la vista que muestra todos los clientes
        /// </summary>
        public BtnCustomerCommand CustomerCommand { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        public INavigationService navigationService;
        public CustomerTabbedVM(INavigationService navigationService)
        {
            Customers = new ObservableCollection<Customer>();
            this.CustomerCommand = new BtnCustomerCommand(this);
            this.navigationService = navigationService;
        }

        public void OnAppearing()
        {
            this.Customers.Clear();
            foreach (Customer customer in Customer.SelectAll())
                Customers.Add(customer);
        }

        public void OnDisappearing()
        {
        }
    }
}
