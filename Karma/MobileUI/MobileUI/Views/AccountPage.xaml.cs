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
        private async void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            await ProfilePage.Navigation.PushAsync(new ForgotPasswordPage());
        }
        private async void Login_Tapped(object sender, EventArgs e)
        {
            await ProfilePage.Navigation.PushAsync(new LogInPage());
        }
        private async void Register_Tapped(object sender, EventArgs e)
        {
            await ProfilePage.Navigation.PushAsync(new RegisterPage());
        }

    }
}