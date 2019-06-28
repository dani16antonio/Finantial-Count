using Fcount.models;
using Fcount.viewmodels;
using Fcount.viewmodels.forms;
using Fcount.views;
using Fcount.views.forms;
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
        }
        
    }
}
