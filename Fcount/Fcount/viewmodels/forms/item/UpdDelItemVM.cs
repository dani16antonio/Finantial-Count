using Fcount.models;
using Fcount.viewmodels.utils;
using Fcount.viewmodels.utils.commands.forms.item;
using Fcount.viewmodels.utils.commands.mainVM;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fcount.viewmodels.forms.item
{
    class UpdDelItemVM : ViewModelBase, INavigatedAware
    {
        #region Properties
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                RaisePropertyChanged();
                this.UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        public string Price
        {
            get
            {
                return _price.ToString();
            }
            set
            {
                try
                {
                    _price = float.Parse(value);
                    RaisePropertyChanged();
                    this.UpdateCommand.RaiseCanExecuteChanged();
                }
                catch (Exception)
                {
                    RaisePropertyChanged();
                    this.UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
                RaisePropertyChanged();
                this.UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
        private int _id;

        private string _description, _brand;
        private float _price;
        public BtnUpdItemCommand UpdateCommand { get; set; }
        public BtnDelItemCommand DeleteCommand { get; set; }
        private INavigationService navigationService;
        public UpdDelItemVM(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            UpdateCommand = new BtnUpdItemCommand(this);
            DeleteCommand = new BtnDelItemCommand(this);
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var item = parameters["item"] as Item;
            Price = item.Price.ToString();
            Description = item.Description;
            Brand = item.Brand;
            _id = item.Id;
        }

        internal bool CheckProps()
        {
            return !(string.IsNullOrEmpty(_price.ToString()) | string.IsNullOrEmpty(_description) |
                string.IsNullOrEmpty(_brand));
        }

        internal async void ExecuteUpdate()
        {
            var rows = Item.Update(new Item()
            {
                Id = _id,
                Description = _description,
                Brand = _brand,
                Price = _price
            });
            if (rows > 0)
                await this.navigationService.GoBackAsync();
            else
                await Application.Current.MainPage.DisplayAlert("Error",
                    "No hemos podido actualizar su artículo", "Aceptar");
        }
        internal async void ExecuteDelete()
        {
            var rows = Item.Remove(new Item()
            {
                Id = _id,
                Description = _description,
                Brand = _brand,
                Price = _price
            });
            if (rows > 0)
                await this.navigationService.GoBackAsync();
            else
                await Application.Current.MainPage.DisplayAlert("Error",
                    "No hemos podido borrar su artículo", "Aceptar");
        }
    }
}
