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
    class MainViewModel : ViewModelsBase
    {
        public BtnLoginCommand loginBtnCommand { get; set; }
        public CreateUserCommand createUserCommand{ get; set; }
        private string _username, _pass;
        private MainPage mainPage;

        public MainViewModel(MainPage mainPage)
        {
            this.createUserCommand = new CreateUserCommand(this);
            this.loginBtnCommand = new BtnLoginCommand(this);
            this.mainPage = mainPage;
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
            {
                //this.mainPage.entryWrong("Los campos no pueden estar en blanco.");
                return false;
            }
            else
                return true;
        }


        public void Navigate()
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
        }
    }
}
