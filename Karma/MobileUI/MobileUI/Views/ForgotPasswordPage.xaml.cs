using DataBase.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        string username;
        public ForgotPasswordPage()
        {
           InitializeComponent();
        }

        private async void Forgot_Clicked(object sender, System.EventArgs e)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "official.karma.app@gmail.com",
                    Password = "universitetas1!"
                }
            };
            MailAddress FromEmail = new MailAddress("official.karma.app@gmail.com", "Karma App");

            var json = await App.Client.GetStringAsync($"api/User/username={username}");
            User user = JsonConvert.DeserializeObject<User>(json);

            MailAddress ToEmail = new MailAddress(user.Email, user.Username);

            MailMessage mailMessage = new MailMessage()
            {
                From = FromEmail,
                Subject = "Your password",
                IsBodyHtml = true,
                BodyEncoding = System.Text.Encoding.UTF8,
                Body = $"Hello, your password is <i><b>{user.Password}</b></i>."
            };
            mailMessage.To.Add(ToEmail);
            try
            {
                Client.Send(mailMessage);
            }
            catch
            {

            }
            
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            username = ((Entry)sender).Text;
        }
    }
}