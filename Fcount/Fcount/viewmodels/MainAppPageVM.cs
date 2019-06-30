using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands.mainVM;
using Fcount.views.forms;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels
{
    class MainAppPageVM: ViewModelBase
    {
        public NewCustomerCommand QuoteCommand { get; set; }
        public INavigationService navigationService;

        public MainAppPageVM(INavigationService navigationService)
        {
            QuoteCommand = new NewCustomerCommand(this);
            this.navigationService = navigationService;
        }
    }
}
