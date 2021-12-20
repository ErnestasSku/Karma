using MobileUI.Views;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using DataBase.Models;
using System.Text;
using MobileUI.Services.Core;
using Database.Models;

namespace MobileUI
{
    public partial class App : Application
    {
        public static HttpClient Client;

        public static User CurrentUser;

        public static ObservableRangeCollection<Item> Items;
        public static ObservableRangeCollection<Item> UserItems;


        private Lazy<List<Item>> _userPostedItems;


        public ObservableRangeCollection<Item> UserPostedItems
        {
            get
            {
                return new ObservableRangeCollection<Item>(_userPostedItems.Value);
            }
        }
        

        public App()
        {
            InitializeComponent();
            DependencyService.Register<ChatService>();

            MainPage = new NavigationPage(new StartPage());

        }

        protected override void OnStart()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            Client = new HttpClient(httpClientHandler);

            Client.BaseAddress = new System.Uri("https://karmawebapi-in2.conveyor.cloud/");

            Items = GetItems();


        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }


        public static async Task<ObservableRangeCollection<DataBase.Models.Item>> GetItemsAsync()
        {
            var json = await Client.GetStringAsync("api/Item");
            //json.Wait();
            var items = JsonConvert.DeserializeObject< List<DataBase.Models.Item>>(json);

            foreach(var i in items)
            {
                i.Image = i.Image ?? "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Text-x-generic.svg/2048px-Text-x-generic.svg.png";
            }

            return new ObservableRangeCollection<DataBase.Models.Item>(items);
        }
        public static ObservableRangeCollection<Item> GetItems()
        {
            var json = Client.GetStringAsync("api/Item");
            json.Wait();
            var items = JsonConvert.DeserializeObject<List<DataBase.Models.Item>>(json.Result);

            foreach (var i in items)
            {
                i.Image = i.Image ?? "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Text-x-generic.svg/2048px-Text-x-generic.svg.png";
            }

            // Lazy way
           /* return new Lazy<ObservableRangeCollection<Item>>(() =>
            {
                return new ObservableRangeCollection<Item>(items);
            });*/

            return new ObservableRangeCollection<DataBase.Models.Item>(items);
        }
        public static async Task PostUser(User value)
        {
            var json = JsonConvert.SerializeObject(value);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await App.Client.PostAsync("api/User", content);

            if (!response.IsSuccessStatusCode)
            {

            }
        }
        public User GetByUsername(string username)
        {
            var json = Client.GetStringAsync($"api/User/username={username}");
            json.Wait();
            User user = JsonConvert.DeserializeObject<User>(json.Result);
            return user;
        }
        public static async Task PostItem(DataBase.Models.Item value)
        {
            var json = JsonConvert.SerializeObject(value);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await App.Client.PostAsync("api/Item", content);
            if (!response.IsSuccessStatusCode)
            {
               
            }
        }
        public static ObservableRangeCollection<DataBase.Models.Item> GetUserItems(string username)
        {
            var json = Client.GetStringAsync($"api/Item/user={username}/posted");
            json.Wait();
            var items = JsonConvert.DeserializeObject<List<DataBase.Models.Item>>(json.Result);

            foreach (var i in items)
            {
                i.Image = i.Image ?? "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Text-x-generic.svg/2048px-Text-x-generic.svg.png";
            }
            return new ObservableRangeCollection<DataBase.Models.Item>(items);
        }
        public static async Task DeleteItem(DataBase.Models.Item value)
        {
            var response = await Client.DeleteAsync($"api/Item/{value.ItemId}");
            if (!response.IsSuccessStatusCode)
            {

            }
        }

    }
}
