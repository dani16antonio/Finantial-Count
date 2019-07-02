using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands.forms.customer;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels.forms
{
    class NewCustomerVM : ViewModelBase
    {
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
                this.CreateCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                RaisePropertyChanged();
                this.CreateCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        public string Document
        {
            get { return _document; }
            set
            {
                _document = value;
                RaisePropertyChanged();
                this.CreateCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                RaisePropertyChanged();
                this.CreateCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged();
                this.CreateCustomerCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion
        public BtnCreateCustomerCommand CreateCustomerCommand { get; set; }
        private INavigationService navigationService;

        public NewCustomerVM(INavigationService navigationService)
        {
            CreateCustomerCommand = new BtnCreateCustomerCommand(this);
            this.navigationService = navigationService;
        }

        internal bool CheckProp()
        {
            return !string.IsNullOrEmpty(_name) & !string.IsNullOrEmpty(_lastname) & !string.IsNullOrEmpty(_document)
                & !string.IsNullOrEmpty(_phone)& !string.IsNullOrEmpty(_email);
        }

        internal async void CreateCostumer()
        {
            var customer = new Customer()
            {
                Name = _name,
                Lastname = _lastname,
                Phone = _phone,
                Document = _document,
                Email = _email
            };
            var result = Customer.Insert(customer);
            if (result < 1)
                await Application.Current.MainPage.DisplayAlert("Error",
                    "El cliente no pudo ser creado, vuelva a intetar por favor.",
                    "Aceptar");
            else
                await navigationService.GoBackAsync();
        }
    }
}
