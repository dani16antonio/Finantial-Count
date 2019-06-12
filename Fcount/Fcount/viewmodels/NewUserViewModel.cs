using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands;
using Fcount.views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels
{
    class NewUserViewModel: ViewModelsBase
    {
        private NewUserPage newUserPage;
        public CreateUserCommand createUserCommand;

        public NewUserViewModel(NewUserPage newUserPage)
        {
            this.newUserPage = newUserPage;
            //this.createUserCommand = new CreateUserCommand(this);
        }

        public void Navigate()
        {
            newUserPage.closePage();
        }
    }
}
