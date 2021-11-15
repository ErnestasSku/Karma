using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        Label UsernameLabel;
        Label PasswordLabel;
        Entry UsernameEntry;
        Entry PasswordEntry;
        Label ForgotLink;
        Button LogInButton;

        string userName { get; set; }
        string password { get; set; }

        public LogInPage()
        {
            BackgroundColor = Color.White;
            UsernameLabel = new Label
            {
                Text = "Username",
                FontSize = 24
            };
            PasswordLabel = new Label
            {
                Text = "Password",
                FontSize = 24
            };
            UsernameEntry = new Entry
            {
                MaxLength = 20,
                FontSize = 28
            };
            UsernameEntry.Completed += UsernameEntry_Completed;
            PasswordEntry = new Entry
            {
                MaxLength = 16,
                FontSize = 28,
                IsPassword = true
            };
            PasswordEntry.Completed += PasswordEntry_Completed;
            ForgotLink = new Label
            {
                Text = "Forgot password?",
                TextColor = Color.Blue,
                TextDecorations = TextDecorations.Underline,
                FontSize = 16
            };
            LogInButton = new Button
            {
                Text = "Log in",
                FontSize = 24,
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            };
            LogInButton.Clicked += LogInButton_Clicked;

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
                    new RowDefinition { Height = new GridLength (0.3, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (0.8, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (0.7, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (0.3, GridUnitType.Star) }
                }
            };

            //TODO FINISH TAP EVENT
            var ForgotTap = new TapGestureRecognizer();
            ForgotTap.Tapped += (s,e) =>
            {
                //TODO LINK TO FORGOT FORM
            };
            ForgotLink.GestureRecognizers.Add(ForgotTap);

            grid.Children.Add(UsernameLabel, 0, 0);
            grid.Children.Add(UsernameEntry, 0, 1);
            grid.Children.Add(PasswordLabel, 0, 3);
            grid.Children.Add(PasswordEntry, 0, 4);
            grid.Children.Add(LogInButton, 0, 5);
            grid.Children.Add(ForgotLink, 0, 6);
            Content = grid;
        }

        private void LogInButton_Clicked(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void PasswordEntry_Completed(object sender, System.EventArgs e)
        {
            password = ((Entry)sender).Text;
        }

        private void UsernameEntry_Completed(object sender, System.EventArgs e)
        {
            userName = ((Entry)sender).Text;
        }
    }
}