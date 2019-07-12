using Fcount.models;
using Fcount.viewmodels;
using Fcount.viewmodels.forms;
using Fcount.viewmodels.forms.item;
using Fcount.viewmodels.forms.provider;
using Fcount.viewmodels.mainTabbedPages;
using Fcount.views;
using Fcount.views.forms;
using Fcount.views.forms.item;
using Fcount.views.forms.provider;
using Fcount.views.mainTabbedPages;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fcount
{
    public partial class App : PrismApplication
    {
        public static string databaseLocation = string.Empty;
        public static string databaseName = "fcount";
        public static User user = null;
        public App(string databaseLoc, IPlatformInitializer initializer=null):base(initializer)
        {
            databaseLocation = databaseLoc;
        }
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NewCustomerPage, NewCustomerVM>();
            containerRegistry.RegisterForNavigation<MainAppPage, MainAppPageVM>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<NewUserPage, NewUserVM>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginVM>();
            containerRegistry.RegisterForNavigation<CostumersTabbedPage, CustomersTabbedVM>();
            containerRegistry.RegisterForNavigation<UpdDelCustomerPage, UpdDelCustomerVM>();
            containerRegistry.RegisterForNavigation<NewItemPage, NewItemVM>();
            containerRegistry.RegisterForNavigation<ItemsTabbedPage, ItemsTabbedVM>();
            containerRegistry.RegisterForNavigation<UpdDelItemPage, UpdDelItemVM>();
            containerRegistry.RegisterForNavigation<NewProviderPage, NewProviderVM>();
            containerRegistry.RegisterForNavigation<ProvidersTabbedPage, ProvidersTabbedVM>();
            containerRegistry.RegisterForNavigation<UpdDelProviderPage, UpdDelProviderVM>();
        }
        
    }
}
