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
            
            if (await AuthenticateUser(username, password))
            {
                App.Current.MainPage = new TabbedPage1();
            }
            else
            {
                //TODO: show that password is incorect
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
            var json = await App.Client.GetStringAsync($"api/User/username={username}");
            User user = JsonConvert.DeserializeObject<User>(json);

            if (user.Password == password)
            {
                App.CurrentUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}