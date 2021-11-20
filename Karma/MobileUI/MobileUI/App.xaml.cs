using MobileUI.Models;
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

namespace MobileUI
{
    public partial class App : Application
    {
        public static HttpClient Client;

        public static User currentUser;

        public static ObservableRangeCollection<DataBase.Models.Item> Items;

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
            Client.BaseAddress = new System.Uri("https://192.168.0.108:45455/");

            Items = GetItems();
            currentUser = GetByUsername("justas");
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }

        public ObservableRangeCollection<DataBase.Models.Item> GetItems()
        {
            var json = Client.GetStringAsync("api/Item");
            json.Wait();
            var items = JsonConvert.DeserializeObject< List<DataBase.Models.Item>>(json.Result);

            foreach(var i in items)
            {
                i.Image = i.Image ?? "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Text-x-generic.svg/2048px-Text-x-generic.svg.png";
            }

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
