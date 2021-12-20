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
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
        }
        private void Logout_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new StartPage());
        }
        private async void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            await ProfilePage.Navigation.PushAsync(new ForgotPasswordPage());
        }
        private async void ChangePassword_Tapped(object sender, EventArgs e)
        {
            await ProfilePage.Navigation.PushAsync(new ChangePasswordPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await ProfilePage.Navigation.PushAsync(new Chatroom(new Database.Models.Conversation(null, null)));
        }
    }
}