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
    public partial class PostingsPage : ContentPage
    {
        public PostingsPage()
        {
            InitializeComponent();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var item = listview.SelectedItem as DataBase.Models.Item;
            if (item == null)
                return;
            await App.DeleteItem(item);

        }

        private void AddNewItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddItemPage());
        }

        private async void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as DataBase.Models.Item;
            if (item == null)
                return;

            //((ListView)sender).SelectedItem = null;
            ItemDetailPageViewModel.Name = item.Name;
            ItemDetailPageViewModel.Description = item.Description;
            ItemDetailPageViewModel.Img = item.Image;
            ItemDetailPageViewModel.ContactInfo = item.ContactInfo;
            await ListingsPage.Navigation.PushAsync(new ItemDetailPage());
        }
    }
}