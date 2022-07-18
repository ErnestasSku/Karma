
using Database.Models;
using DataBase.Models;
using MobileUI.ViewModels;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        private async void Button_Clicked(object sender, System.EventArgs e)
        {

            Conversation conv = MessagesPageViewModel.allConversations.Where(x =>
                        (x.UserOne.Equals(App.CurrentUser.Username) && x.UserTwo.Equals(Poster.Username)) || 
                        (x.UserOne.Equals(Poster.Username) && x.UserTwo.Equals(App.CurrentUser.Username))).FirstOrDefault();
            if (conv == null)
            {
                conv = new Conversation(App.CurrentUser.Username, Poster.Username);


                var json = JsonConvert.SerializeObject(conv);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await App.Client.PostAsync("api/Conversation", content);

            }
            await ItemDetailsPage.Navigation.PushAsync(new Chatroom(conv));

        }
    }
}