
using DataBase.Models;
using MobileUI.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MobileUI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public Item ChosenItem 
        { 
            get => ItemDetailPageViewModel.ChosenItem; 
        }
        public User Poster { get => ItemDetailPageViewModel.Poster; }   
        public ItemDetailPage(Item item)
        {
            ItemDetailPageViewModel.ChosenItem = item;
            
            var json = App.Client.GetStringAsync($"api/User/{item.PosterId}");
            json.Wait();
            ItemDetailPageViewModel.Poster = JsonConvert.DeserializeObject<User>(json.Result);

            InitializeComponent();
            BindingContext = this;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}