using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        Label ForgotLabel;
        Entry EmailEntry;
        Button RemindButton;
        public ForgotPasswordPage()
        {
            ForgotLabel = new Label
            {
                Text = "Forgot your password? Enter your email and we will send a reminder. ",
                FontSize = 24
            };
            EmailEntry = new Entry
            {
                MaxLength = 20,
                FontSize = 28
            };
            RemindButton = new Button
            {
                Text = "Remind",
                FontSize = 24,
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            };

            var grid = new Grid
            {
                Margin = new Thickness(20, 40),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (3, GridUnitType.Star) }
                }
            };

            grid.Children.Add(ForgotLabel, 0, 0);
            grid.Children.Add(EmailEntry, 0, 1);
            grid.Children.Add(RemindButton, 0, 2);

            Content = grid;
        }
    }
}