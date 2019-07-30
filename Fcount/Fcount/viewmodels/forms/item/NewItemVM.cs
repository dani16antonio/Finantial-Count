using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands.mainVM;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels.mainTabbedPages
{
    class NewItemVM : ViewModelBase
    {
        #region Properties
        public string Description {
            get {
                return _description;
            }
            set {
                _description = value;
                RaisePropertyChanged();
                this.CreateItem.RaiseCanExecuteChanged();
            }
        }
        public string Price {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                RaisePropertyChanged();
                this.CreateItem.RaiseCanExecuteChanged();
            }
        }
        public string Brand {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
                RaisePropertyChanged();
                this.CreateItem.RaiseCanExecuteChanged();
            }
        }
        public BtnItemsTabbedCommand CreateItem { get; set; }
        #endregion
        private string _description, _brand;
        private string _price;

        public INavigationService  navigationService { get; set; }
        public NewItemVM(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            CreateItem = new BtnItemsTabbedCommand(this);
        }
        internal async void ExecuteCreateBtn()
        {
            Item item = new Item()
            {
                Brand = _brand,
                Description = _description,
                Price = 0F
            };
            try
            {
                item.Price = float.Parse(_price);
            }catch(Exception e)
            {
                _price=string.Empty;
                return;
            }
            int row = Item.Insert(item);
            if (row > 0)
                await this.navigationService.GoBackAsync();
            else
                await Application.Current.MainPage.DisplayAlert("Error",
                    "No hemos podido almacena su artículo", "Aceptar");
        }

        internal bool CheckProperties()
        {
            return !(string.IsNullOrEmpty(_price) | string.IsNullOrEmpty(_description) |
                string.IsNullOrEmpty(_brand));
        }
    }
}
