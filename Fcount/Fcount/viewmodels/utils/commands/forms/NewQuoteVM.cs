using Fcount.models;
using Prism.AppModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Fcount.viewmodels.utils.commands.forms
{
    class NewQuoteVM:ViewModelBase, IPageLifecycleAware
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<Provider> Providers { get; set; }
        public NewQuoteVM()
        {
            Customers = new ObservableCollection<Customer>();
            Items = new ObservableCollection<Item>();
            Providers = new ObservableCollection<Provider>();
        }

        public void OnAppearing()
        {
            Customers.Clear();
            Items.Clear();
            Providers.Clear();
            foreach (Customer customer in Customer.SelectAll())
                Customers.Add(customer);
            foreach (Item item in Item.SelectAll())
                Items.Add(item);
            foreach (Provider provider in Provider.SelectAll())
                Providers.Add(provider);
        }

        public void OnDisappearing()
        {
        }
    }
}
