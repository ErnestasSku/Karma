using DataBase.Models;
using DataBase.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        
        public RegisterPage()
        {
            InitializeComponent();
        }

       // private void RegisterButton_Clicked(object sender, System.EventArgs e)
       // {
       //     if (password.Equals(repeatedPassword))
       //     {
       //         User newUser = new User(userName, password, email);
       //         UserService service = UserService.Instance;
       //         service.InsertUser(newUser);
       //         Navigation.PopAsync();
       //     }
       //}

        //private void EmailEntry_TextChanged(object sender, System.EventArgs e)
        //{
        //    email = ((Entry)sender).Text;
        //}

        //private void RepeatEntry_TextChanged(object sender, System.EventArgs e)
        //{
        //    repeatedPassword = ((Entry)sender).Text;
        //}

        //private void PasswordEntry_TextChanged(object sender, System.EventArgs e)
        //{
        //    password = ((Entry)sender).Text;
        //}

        //private void UsernameEntry_TextChanged(object sender, System.EventArgs e)
        //{
        //    userName = ((Entry)sender).Text;
        //}
    }
}