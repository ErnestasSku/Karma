using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
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
        private void LogIn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TabbedPage1();
        }
    }
}