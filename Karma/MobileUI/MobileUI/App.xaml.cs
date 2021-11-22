using MobileUI.Views;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using DataBase.Models;
using Xamarin.Forms.Xaml;
using System.Text;
using System.Threading;

namespace MobileUI
{
    public partial class App : Application
    {
        public static HttpClient Client;

        public static User CurrentUser;

        public static ObservableRangeCollection<Item> Items;

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
            //FOR DEBUGING VARIOUS PAGES, CHANGE < new ...Page(); > into required page to view it
            /*Item.Items = new MvvmHelpers.ObservableRangeCollection<Item>();
            Item.AddData(Item.Items);*/


            MainPage = new NavigationPage(new StartPage());
            //MainPage = new AddItemPage();  
            

            //Current.MainPage = new NavigationPage(FirstPage);
        }

        protected override void OnStart()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            Client = new HttpClient(httpClientHandler);
            Client.BaseAddress = new System.Uri("https://192.168.8.115:45455/");

            // TODO: can't do this as the UI requires App.Items.First and it can't be null, so that needs to be fixed
           // Task.Factory.StartNew(() => Items = GetItems());
            Items = GetItems();
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }

        public ObservableRangeCollection<Item> GetItems()
        {
            var json = Client.GetStringAsync("api/Item");
            json.Wait();
            var items = JsonConvert.DeserializeObject< List<DataBase.Models.Item>>(json.Result);

            foreach(var i in items)
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



    }
}
