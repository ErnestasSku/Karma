using MobileUI.Models;
using MobileUI.ViewModels;
using System.Linq;
using Xamarin.Forms;

namespace MobileUI.Views
{
    public partial class MainPage : ContentPage
    {
        public Item currentItem = Item.Items.First();
        public Item previousItem;
        
        public MainPage()
        {
            InitializeComponent();
            
        }
        private async void Item_Tapped(object sender, System.EventArgs e)
        {
            ItemDetailPageViewModel.Name = currentItem.Name;
            ItemDetailPageViewModel.Description = currentItem.Description;
            ItemDetailPageViewModel.Img = currentItem.ImgSource;
            await HomePage.Navigation.PushAsync(new ItemDetailPage()); 
        }
        void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            previousItem = e.PreviousItem as Item;
            currentItem = e.CurrentItem as Item;
        }
    }
}
