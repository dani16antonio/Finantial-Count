﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fcount.viewmodels.utils.commands.newUserVM
{
    class BtnCreateUserCommand : ICommand
    {
        private NewUserViewModel newUserViewModel;
        public BtnCreateUserCommand(NewUserViewModel newUserViewModel)
        {
            this.newUserViewModel = newUserViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return newUserViewModel.checkProperty();
        }

        public void Execute(object parameter)
        {
            newUserViewModel.create();
        }
        public void RaiseCanExecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
                handle(this, new EventArgs());
        }
    }
}
