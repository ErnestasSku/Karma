using MobileUI.Models;
using MobileUI.ViewModels;
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
            ItemDetailPageViewModel.Name = item.Name;
            ItemDetailPageViewModel.Description = item.Description;
            ItemDetailPageViewModel.Img = item.Image;
            await ItemPage.Navigation.PushAsync(new ItemDetailPage());
        }
    }
}
