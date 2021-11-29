using DataBase.Models;
using Newtonsoft.Json;
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
    public partial class StartPage : ContentPage
    {
        string username;
        string password;
        public StartPage()
        {
            InitializeComponent();
        }
        private async void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            await Startup.Navigation.PushAsync(new ForgotPasswordPage());
        }
        private async void SignUp_Tapped(object sender, EventArgs e)
        {
            await Startup.Navigation.PushAsync(new RegisterPage());
        }

        private async void LogIn_Clicked(object sender, EventArgs e)
        {
            try {
                if (await AuthenticateUser(username, password))
                {
                    App.Current.MainPage = new TabbedPage1();
                }
                else
                {
                    wrong_password.IsVisible = true;
                }
            }
            catch (Exception)
            {

            }
            
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            username = ((Entry)sender).Text;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = ((Entry)sender).Text;
        }

        private async Task<bool> AuthenticateUser(string username, string password)
        {
            if(username == null || password == null || password == "" || username == "")
            {
                wrong_password.Text = "Enter username or password";
                return false;
            }
            //User user = null;
            
            var json = await App.Client.GetStringAsync($"api/User/username={username}");
            User user = JsonConvert.DeserializeObject<User>(json);

            if(user == null)
            {
                wrong_password.Text = "User was not found";
                return false;
            }

            if (user.Password == password)
            {
                App.CurrentUser = user;
                return true;
            }
            else
            {
                wrong_password.Text = "Wrong password";
                return false;
            }
        }

    }
}