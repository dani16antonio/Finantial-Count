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
        public NewCustomerCommand CustomerCommand { get; set; }
        public NewItemCommand ItemCommand { get; set; }
        public NewProviderCmd ProviderCommand { get; set; }
        public INavigationService navigationService;


        public MainAppPageVM(INavigationService navigationService)
        {
            CustomerCommand = new NewCustomerCommand(this);
            ItemCommand = new NewItemCommand(this);
            ProviderCommand = new NewProviderCmd(this);
            this.navigationService = navigationService;
        }
    }
}
