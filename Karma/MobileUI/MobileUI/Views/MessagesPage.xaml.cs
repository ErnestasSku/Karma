using Database.Models;
using DataBase.Models;
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
    public partial class MessagesPage : ContentPage
    {
        MessagesPageViewModel vm;
        MessagesPageViewModel VM
        {
            get => vm ?? (vm = (MessagesPageViewModel)BindingContext);
        }
        public MessagesPage()
        {
            InitializeComponent();
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
         {
            var si = (Conversation)listview.SelectedItem;
            string user = si.UserOne;

            if(si.UserOne == App.CurrentUser.Username)
                user = si.UserTwo;

            await VM.JoinConversation(Navigation, App.CurrentUser.Username, user);
            ((ListView)sender).SelectedItem = null;

        }
    }
}