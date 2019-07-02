using Fcount.viewmodels.utils;
using System;
using System.Collections.Generic;
using System.Text;
using Fcount.viewmodels.utils.commands.tabbedVM.CustomerVM;
using Prism.Navigation;
using Fcount.models;
using SQLite;
using Xamarin.Forms;

namespace Fcount.viewmodels.mainTabbedPages
{
    class UpdDelCustomerVM : ViewModelBase, INavigatedAware
    {
        /// <summary>
        /// Esta es  la clase View Model de la vista que acutaliza o borra la información de los clientes. 
        /// </summary>
        public BtnUpdDelUPDCustomerCommand upadateCustomerCommand { get; set; }
        public BtnUpdDelDELCustomerCommand deleteCustomerCommand { get; set; }
        private string _name, _lastname, _document, _phone, _email;
        public int _id;
        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
                this.upadateCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                RaisePropertyChanged();
                this.upadateCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        public string Document
        {
            get { return _document; }
            set
            {
                _document = value;
                RaisePropertyChanged();
                this.upadateCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                RaisePropertyChanged();
                this.upadateCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged();
                this.upadateCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
        private INavigationService navigationService;
        public UpdDelCustomerVM(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            upadateCustomerCommand = new BtnUpdDelUPDCustomerCommand(this);
            deleteCustomerCommand = new BtnUpdDelDELCustomerCommand(this);
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var item = parameters["customer"] as Customer;
            Name = item.Name;
            Lastname = item.Lastname;
            Document = item.Document;
            Phone = item.Phone;
            Email = item.Email;
            _id = item.Id;
        }
        public async void RemoveCustomer()
        {
            var customer = new Customer()
            {
                Name = Name,
                Lastname = Lastname,
                Document = Document,
                Phone = Phone,
                Email = Email,
                Id = _id
            };
            var rows = Customer.Remove(customer);
            if (rows>0)
            {
                await Application.Current.MainPage.DisplayAlert("Eliminado", "El cliente ha sido eliminado", "Acepatar");
                await navigationService.GoBackAsync();
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "El cliente no ha sido eliminado, intente otra vez",
                    "Acepatar");
        }
        public bool checkProp()
        {
            return !string.IsNullOrEmpty(_name) & !string.IsNullOrEmpty(_lastname) & !string.IsNullOrEmpty(_phone)
                & !string.IsNullOrEmpty(_email) & !string.IsNullOrEmpty(_phone);
        }
        public async void execute()
        {
            var customer = new Customer()
            {
                Name = Name,
                Lastname = Lastname,
                Document = Document,
                Phone = Phone,
                Email = Email,
                Id = _id
            };
            var rows = Customer.Update(customer);
            if (rows > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Actualizado", "El cliente ha sido actualizado", "Acepatar");
                await navigationService.GoBackAsync();
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "El cliente no ha sido eliminado, intente otra vez",
                    "Acepatar");


        }
    }
}
