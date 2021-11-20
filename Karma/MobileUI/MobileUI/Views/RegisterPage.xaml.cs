using DataBase.Models;
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

        private void RegisterButton_ClickedAsync(object sender, System.EventArgs e)
        {
            if (password.Equals(repeatedPassword))
            {
                User newUser = new User(userName, password, email);
                newUser.PhoneNumber = "+3706222222"; //TEMPORARY, need to change DB settings to not require phone number
                newUser.Name = "string";
                newUser.LastName = "string";

                App.PostUser(newUser);


                 Navigation.PopAsync();

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