using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands;
using Fcount.views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fcount.viewmodels
{
    class LoginViewModel : ViewModelsBase
    {
        public BtnLoginCommand loginBtnCommand { get; set; }
        public BtnCreateUserCommand createUserCommand{ get; set; }
        private string _username, _pass;

        public LoginViewModel()
        {
            this.createUserCommand = new BtnCreateUserCommand(this);
            this.loginBtnCommand = new BtnLoginCommand(this);
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged();
                this.loginBtnCommand.RaiseCanExecuteChanged();
            }
        }

        public string Pass
        {
            get { return _pass; }
            set
            {
                _pass = value;
                RaisePropertyChanged();
                this.loginBtnCommand.RaiseCanExecuteChanged();
            }
        }

        public bool checkEntries()
        {
            if (string.IsNullOrEmpty(Username) & string.IsNullOrEmpty(Pass))
                return false;
            else
                return true;
        }


        public void startNewUserPage()
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new NewUserPage());
        }
        public void login()
        {
            User user = User.Select(_username);
            if (user == null)
            {
                Application.Current.MainPage.DisplayAlert("Error", "El usuario "+_username+" no existe.", "ok");
                return;
            }
            else
            {
                if(user.password!=_pass)
                    Application.Current.MainPage.DisplayAlert("Error", "Error de contraseña.", "ok");
            }
            App.user = user;

        }
    }
}
