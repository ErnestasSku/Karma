using DataBase.Models;
using DataBase.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        string userName;
        string email;
        string password;
        string repeatedPassword;

        Label UsernameLabel;
        Label EmailLabel;
        Label PasswordLabel;
        Label RepeatLabel;
        Entry UsernameEntry;
        Entry EmailEntry;
        Entry PasswordEntry;
        Entry RepeatEntry;
        Button RegisterButton;
        public RegisterPage()
        {
            UsernameLabel = new Label
            {
                Text = "Enter your future username: ",
                FontSize = 16
            };
            EmailLabel = new Label
            {
                Text = "Enter your email address: ",
                FontSize = 16
            };
            PasswordLabel = new Label
            {
                Text = "Enter your password: ",
                FontSize = 16
            };
            RepeatLabel = new Label
            {
                Text = "Repeat your password: ",
                FontSize = 16
            };
            UsernameEntry = new Entry
            {
                MaxLength = 20
            };
            UsernameEntry.TextChanged += UsernameEntry_TextChanged;
            EmailEntry = new Entry
            {
                MaxLength = 20
            };
            EmailEntry.TextChanged += EmailEntry_TextChanged;
            PasswordEntry = new Entry
            {
                MaxLength = 16,
                IsPassword = true
            };
            PasswordEntry.TextChanged += PasswordEntry_TextChanged;
            RepeatEntry = new Entry
            {
                MaxLength = 16,
                IsPassword = true
            };
            RepeatEntry.TextChanged += RepeatEntry_TextChanged;
            RegisterButton = new Button
            {
                Text = "Register",
                FontSize = 24,
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            };
            RegisterButton.Clicked += RegisterButton_Clicked;

            var grid = new Grid
            {
                Margin = new Thickness(20, 40),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength (0.3, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (0.8, GridUnitType.Star) },

                    new RowDefinition { Height = new GridLength (0.3, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (0.8, GridUnitType.Star) },

                    new RowDefinition { Height = new GridLength (0.3, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (0.8, GridUnitType.Star) },

                    new RowDefinition { Height = new GridLength (0.3, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (0.8, GridUnitType.Star) },

                    new RowDefinition { Height = new GridLength (0.7, GridUnitType.Star) },
                }
            };

            grid.Children.Add(UsernameLabel, 0, 0);
            grid.Children.Add(UsernameEntry, 0, 1);

            grid.Children.Add(EmailLabel, 0, 2);
            grid.Children.Add(EmailEntry, 0, 3);

            grid.Children.Add(PasswordLabel, 0, 4);
            grid.Children.Add(PasswordEntry, 0, 5);

            grid.Children.Add(RepeatLabel, 0, 6);
            grid.Children.Add(RepeatEntry, 0, 7);

            grid.Children.Add(RegisterButton, 0, 8);

            Content = grid;
        }

        private void RegisterButton_Clicked(object sender, System.EventArgs e)
        {
            if (password.Equals(repeatedPassword))
            {
                User newUser = new User(userName, password, email);
                UserService service = new UserService();
                service.InsertUser(newUser);
                Navigation.PopAsync();
            }
       }

        private void EmailEntry_TextChanged(object sender, System.EventArgs e)
        {
            email = ((Entry)sender).Text;
        }

        private void RepeatEntry_TextChanged(object sender, System.EventArgs e)
        {
            repeatedPassword = ((Entry)sender).Text;
        }

        private void PasswordEntry_TextChanged(object sender, System.EventArgs e)
        {
            password = ((Entry)sender).Text;
        }

        private void UsernameEntry_TextChanged(object sender, System.EventArgs e)
        {
            userName = ((Entry)sender).Text;
        }
    }
}