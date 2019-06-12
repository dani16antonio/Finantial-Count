using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands;
using Fcount.viewmodels.utils.commands.newUserVM;
using Fcount.views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels
{
    class NewUserViewModel : ViewModelsBase
    {
        public BtnCreateCommand createUserCommand { get; set; }
        private string _username, _pass, _name, _lastname, _confpass;
        private NewUserPage newUserPage;

        #region Properties
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged();
                this.createUserCommand.RaiseCanExecuteChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
                this.createUserCommand.RaiseCanExecuteChanged();
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                RaisePropertyChanged();
                this.createUserCommand.RaiseCanExecuteChanged();
            }
        }

        public string Pass
        {
            get { return _pass; }
            set
            {
                _pass = value;
                RaisePropertyChanged();
                this.createUserCommand.RaiseCanExecuteChanged();
            }
        }
        public string Confpass
        {
            get { return _confpass; }
            set
            {
                _confpass = value;
                RaisePropertyChanged();
                this.createUserCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
        public NewUserViewModel(NewUserPage newUserPage)
        {
            createUserCommand = new BtnCreateCommand(this);
            this.newUserPage = newUserPage;
        }

        public async void create()
        {
            if (_pass != _confpass)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "La contraseñas no coinciden", "Ok");
                return;
            }
            var user = new User()
            {
                Username = _username,
                Name = _name,
                Lastname = _lastname,
                password = _pass
            };
            if (User.Select(user.Username) == null)
                if (User.Insert(user) == 1)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Se creó el usuario", "Ok");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Fallo", "No se pudo crear el usuario", "Ok");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "El usuario "+user.Username+" ya existe", "Ok");
            

        }

        public bool checkProperty()
        {
            if (string.IsNullOrEmpty(_username) | string.IsNullOrEmpty(_lastname)
                | string.IsNullOrEmpty(_name) | string.IsNullOrEmpty(_pass) | string.IsNullOrEmpty(_confpass))
                return false;
            return true;
        }
    }
}
