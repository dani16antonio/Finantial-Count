using Fcount.models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fcount
{
    public partial class App : Application
    {
        public static string databaseLocation = string.Empty;
        public static string databaseName= "fcount";
        public static User user = null;

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }
        public App(string databaseLoc)
        {
            InitializeComponent();
            MainPage = new LoginPage();
            databaseLocation = databaseLoc;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
