using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Fcount.viewmodels.forms;

namespace Fcount.viewmodels.utils.commands.forms
{
    class CreateQuoteCmd : ICommand
    {
        private NewQuoteVM newQuoteVM;

        public CreateQuoteCmd(NewQuoteVM newQuoteVM)
        {
            this.newQuoteVM = newQuoteVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return newQuoteVM.CanExecute();
        }

        public void Execute(object parameter)
        {
            newQuoteVM.createPDF();
        }
        public void RaiseCanExecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
                handle(this, new EventArgs());
        }
    }
}
