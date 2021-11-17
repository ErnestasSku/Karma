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
    }
}