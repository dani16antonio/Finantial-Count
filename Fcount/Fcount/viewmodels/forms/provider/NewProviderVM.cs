using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands.tabbedVM.ProviderVM;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels.mainTabbedPages
{
    class NewProviderVM : ViewModelBase
    {
        private string _name, _email;
        private int _fcontact, _scontact;
        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged();
                BtnSaveProvider.RaiseCanExcecuteChanged();

            }
        }

        public int Fcontact
        {
            get
            {
                return _fcontact;
            }
            set
            {
                _fcontact = value;
                RaisePropertyChanged();
                BtnSaveProvider.RaiseCanExcecuteChanged();
            }
        }
        public int Scontact
        {
            get
            {
                return _scontact;
            }
            set
            {
                _scontact = value;
                RaisePropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged();
                BtnSaveProvider.RaiseCanExcecuteChanged();
            }
        } 
        #endregion
        public ProviderSaveBtnCmd BtnSaveProvider { get; set; }
        private INavigationService NavigationService;
        public NewProviderVM(INavigationService navigationService)
        {
            NavigationService = navigationService;
            BtnSaveProvider = new ProviderSaveBtnCmd(this);
        }

        internal async void ExecuteSave()
        {
            int rows = Provider.Insert(new Provider() {
                Name=_name,
                Email =_email,
                 Fcontact=_fcontact,
                 Scontact=_scontact
            });
            if (rows > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Guardado", "Se ha guardado el proveedor", "Ok");
                await this.NavigationService.GoBackAsync();
            }else
                await Application.Current.MainPage.DisplayAlert("Error", 
                    "No e ha guardado el proveedor, vuelva a intentar", "Ok");

        }

        internal bool CheckProps()
        {
            return !(string.IsNullOrEmpty(_email) | string.IsNullOrEmpty(_name) | _fcontact == 0);
        }
    }
}
