using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fcount.views.mainTabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CostumerTabbedPage : ContentPage
    {
        public CostumerTabbedPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}