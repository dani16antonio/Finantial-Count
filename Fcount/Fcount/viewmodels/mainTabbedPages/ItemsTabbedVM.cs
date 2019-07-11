using Fcount.models;
using Fcount.viewmodels.utils.commands.tabbedVM.itemVM;
using Prism.AppModel;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels.forms.item
{
    class ItemsTabbedVM:IPageLifecycleAware
    {
        public ObservableCollection<Item> Items { get; set; }
        public ItemCommand ItemCommand { get; set; }
        private INavigationService navigationService;
        public ItemsTabbedVM(INavigationService navigationService)
        {
            Items = new ObservableCollection<Item>();
            this.navigationService = navigationService;
            this.ItemCommand = new ItemCommand(this);
        }

        public void OnAppearing()
        {
            Items.Clear();
            foreach (Item item in Item.SelectAll())
                Items.Add(item);
        }

        public void OnDisappearing()
        {
            
        }
        public async void ItemSelected(object obj)
        {
            try
            {
                var listview = obj as ListView;
                var item = listview.SelectedItem;
                var parameter = new NavigationParameters();
                parameter.Add("item", (Item)item);
                await navigationService.NavigateAsync("UpdDelItemPage",parameter);
            }
            catch (Exception)
            {

            }
        }
    }
}
