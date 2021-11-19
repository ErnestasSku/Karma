using DataBase.Models;
using DataBase.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        string password;
        string repeatedPassword;
        string userName;
        string email;
        
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Clicked(object sender, System.EventArgs e)
        {
            if (password.Equals(repeatedPassword))
            {
                User newUser = new User(userName, password, email);
                newUser.PhoneNumber = "+3706222222"; //TEMPORARY, need to change DB settings to not require phone number

                string json = JsonConvert.SerializeObject(newUser);
                StringContent content = new StringContent(json, Encoding.UTF8);
                var response = App.Client.PostAsync("api/User", content);
                response.Wait();

                if(response.IsCompletedSuccessfully)
                {
                    Navigation.PopAsync();
                }

                /*UserService service = UserService.Instance;
                service.InsertUser(newUser);
                Navigation.PopAsync();*/
            }
        }

        private void EmailEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            email = ((Entry)sender).Text;
        }

        private void RepeatEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            repeatedPassword = ((Entry)sender).Text;
        }

        private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = ((Entry)sender).Text;
        }

        private void UsernameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            userName = ((Entry)sender).Text;
        }


    }
}