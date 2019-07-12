using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands.tabbedVM.provider;
using Prism.AppModel;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Fcount.viewmodels.mainTabbedPages
{
    class ProvidersTabbedVM:ViewModelBase, IPageLifecycleAware
    {
        public INavigationService NavigationService;
        public ObservableCollection<Provider> Providers { get; set; }
        public SelectedProviderCmd ProviderSelected { get; set; }
        public ProvidersTabbedVM(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Providers = new ObservableCollection<Provider>();
            ProviderSelected = new SelectedProviderCmd(this);
        }

        public void OnAppearing()
        {
            Providers.Clear();
            foreach (Provider provider in Provider.SelectAll())
                Providers.Add(provider);
        }

        public void OnDisappearing()
        {
            
        }
    }
}
