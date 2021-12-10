using MobileUI.Models;
using MobileUI.ViewModels;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarketPage : ContentPage
    {
        public MarketPage()
        {
            InitializeComponent();
            
        }
        

        public async void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as DataBase.Models.Item;
            if (item == null)
                return;
            ((ListView)sender).SelectedItem = null;
             await ItemPage.Navigation.PushAsync(new ItemDetailPage(item));
        }

        private void SortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            MarketPageViewModel.Sort(SortType.SelectedIndex);
        }

        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            MarketPageViewModel.Filter(filter.Text);
        }
    }
}
