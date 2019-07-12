using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands.forms.provider;
using Prism.AppModel;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels.forms.provider
{
    class UpdDelProviderVM : ViewModelBase, INavigatedAware
    {
        private int _id;
        private string _name, _email;
        private int _fcontact, _scontact;
        private Provider provider;
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
                BtnUpdateProvider.RaiseCanExcecuteChanged();

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
                BtnUpdateProvider.RaiseCanExcecuteChanged();
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
                BtnUpdateProvider.RaiseCanExcecuteChanged();
            }
        }
        #endregion
        public UpdProviderCmd BtnUpdateProvider { get; set; }
        public DelProviderCmd BtnDeleteProvider { get; set; }
        public INavigationService NavigationService;
        public UpdDelProviderVM(INavigationService navigationService)
        {
            NavigationService = navigationService;
            BtnDeleteProvider = new DelProviderCmd(this);
            BtnUpdateProvider = new UpdProviderCmd(this);
        }

        internal bool checkProps()
        {
            return !(string.IsNullOrEmpty(_name) | string.IsNullOrEmpty(_email) | _fcontact == 0);
        }

        internal async void ExecuteDelete()
        {
            if (Provider.Remove(provider) > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Borrado", "Se ha borrado el proveedor", "Ok");
                await NavigationService.GoBackAsync();
            }else
                await Application.Current.MainPage.DisplayAlert("Error", 
                    "No se ha podido borrar el proveedor", "Ok");
        }

        internal async void ExecuteUpdate()
        {
            provider.Email = _email;
            provider.Name = _name;
            provider.Fcontact = _fcontact;
            provider.Scontact = _scontact;
            if (Provider.Update(provider) > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Actualizado", 
                    "Se ha actualizado el proveedor", "Ok");
                await NavigationService.GoBackAsync();
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error",
                    "No se ha podido actualizar el proveedor", "Ok");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var prov = parameters["provider"] as Provider;
            provider = new Provider()
            {
                Id = prov.Id,
                Name = prov.Name,
                Fcontact = prov.Fcontact,
                Scontact = prov.Scontact,
                Email=prov.Email
            };
            Name = prov.Name;
            Fcontact = prov.Fcontact;
            Scontact = prov.Scontact;
            Email = prov.Email;
        }
    }
}
