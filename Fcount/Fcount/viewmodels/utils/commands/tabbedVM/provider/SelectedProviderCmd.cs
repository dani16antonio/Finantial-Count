using Fcount.models;
using Fcount.viewmodels.mainTabbedPages;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fcount.viewmodels.utils.commands.tabbedVM.provider
{
    class SelectedProviderCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ProvidersTabbedVM ProviderTabbedVM;
        public SelectedProviderCmd(ProvidersTabbedVM providerTabbedVM)
        {
            ProviderTabbedVM = providerTabbedVM;
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }

        public async void Execute(object parameter)
        {
            try
            {
                var listview = parameter as ListView;
                var provider = (Provider)listview.SelectedItem;
                var parameters = new NavigationParameters();
                parameters.Add("provider", provider);
                await ProviderTabbedVM.NavigationService.NavigateAsync("UpdDelProviderPage", parameters);
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Vuelva a intentar por favor", "Ok");
            }
        }
    }
}
