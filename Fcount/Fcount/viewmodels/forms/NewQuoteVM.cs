using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands.forms;
using Prism.AppModel;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels.forms
{
    class NewQuoteVM:ViewModelBase, IPageLifecycleAware
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<Provider> Providers { get; set; }
        public INavigationService navigationService { get; set; }

        private Customer customer;
        private Item item;

        private Provider provider;
        private string itemsQuantity;

        #region Props
        public Customer SelectedCustomer
        {
            get
            {
                return customer;
            }
            set
            {
                if (customer != value)
                    customer = value;
                RaisePropertyChanged();
                CreateQuoteCommand.RaiseCanExecuteChanged();
            }
        }

        public Item SelectedItem
        {
            get
            {
                return item;
            }
            set
            {
                if (item != value)
                    item = value;
                RaisePropertyChanged();
                CreateQuoteCommand.RaiseCanExecuteChanged();
            }
        }

        public Provider SelectedProvider
        {
            get
            {
                return provider;
            }
            set
            {
                if (provider != value)
                    provider = value;
                RaisePropertyChanged();
                CreateQuoteCommand.RaiseCanExecuteChanged();
            }
        }

        public string ItemsQuantity {
            get
            {
                try
                {
                    return (int.Parse(itemsQuantity)).ToString();
                }
                catch (Exception)
                {
                    return "0";
                }
            }
            set
            {
                itemsQuantity = value;
                RaisePropertyChanged();
                CreateQuoteCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        public CreateQuoteCmd CreateQuoteCommand { get; set; }
        public NewQuoteVM(INavigationService navigationService)
        {
            Customers = new ObservableCollection<Customer>();
            Items = new ObservableCollection<Item>();
            Providers = new ObservableCollection<Provider>();
            CreateQuoteCommand = new CreateQuoteCmd(this);
            this.navigationService = navigationService;
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
        internal bool CanExecute()
        {
            int quantity = 0;
            try
            {
                quantity = int.Parse(itemsQuantity);
            }
            catch (Exception)
            {
                return false;
            }
            return !(item == null | customer == null | provider == null | quantity == 0);
        }

        internal async void createPDF()
        {
            string message = "Bienvenido a Finantial Count." +
                $"{Environment.NewLine}" +
                "Cotización" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                "Información del cliente." +
                $"{Environment.NewLine}" +
                $"Nombre: {customer.Lastname}, {customer.Name}" +
                $"{Environment.NewLine}" +
                $"Cédula: {customer.Document}" +
                $"{Environment.NewLine}" +
                $"Correo: {customer.Email}" +
                $"{Environment.NewLine}" +
                $"Teléfono: {customer.Phone}" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                "Información del vendedor." +
                $"{Environment.NewLine}" +
                $"Nombre: {App.user.Lastname}, {App.user.Name}" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"Artículos." +
                $"{Environment.NewLine}" +
                $"-----------------------------------" +
                $"{Environment.NewLine}" +
                $"{item.Description}. {item.Brand}, {item.Price}\tX\t{itemsQuantity}\t=\t{item.Price * int.Parse(itemsQuantity)}";
            DependencyService.Get<ICreatePDF>().Create(message);
            await App.Current.MainPage.DisplayAlert("Éxito", "Su archivo fue guardado con éxito", "Ok");
        }
    }
}
