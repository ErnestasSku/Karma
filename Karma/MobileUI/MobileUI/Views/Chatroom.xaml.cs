using Database.Models;
using MobileUI.ViewModels;

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
    public partial class Chatroom : ContentPage
    {
        ChatViewModel vm;
        ChatViewModel VM
        {
            get => vm ?? (vm = (ChatViewModel)BindingContext);
        }
        public Chatroom(Conversation conv)
        {
            ChatViewModel.conv = conv;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.ConnectCommand.Execute(App.CurrentUser.Username);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            VM.DisconnectCommand.Execute(null);
        }

    }
}