
using Database.Models;
using DataBase.Models;
using MobileUI.Views;
using MvvmHelpers;
using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileUI.ViewModels
{
    public class MessagesPageViewModel : ViewModelBase
    {
        public static ObservableRangeCollection<Conversation>  allConversations = new ObservableRangeCollection<Conversation>();


        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }


        private ObservableRangeCollection<Conversation> conversations;
        public ObservableRangeCollection<Conversation> Conversations
        {
            get => conversations;
            set => SetProperty(ref conversations, value);
        }

        public ICommand GoToConversation { get; private set; }
        public Command LoadConversations { get; }

        public MessagesPageViewModel()
        {
            LoadConversations = new Command( async () => await LoaConversations());
            //GoToConversation = new DelegateCommand<User>(JoinConversation);
            Conversations = new ObservableRangeCollection<Conversation>();
            LoadConversations.Execute(null);

        }

        async Task LoaConversations()
        {
            var json = await App.Client.GetStringAsync($"api/Conversation");
            var conversations = JsonConvert.DeserializeObject<List<Conversation>>(json);
           // allConversations.AddRange(conversations);
            var conv = conversations;
                List<Conversation> list = conversations.FindAll(x => x.UserOne.Equals(App.CurrentUser.Username) || x.UserTwo.Equals(App.CurrentUser.Username));

            foreach(var conversation in list)
            {
                if(conversation.UserTwo.Equals(App.CurrentUser.Username))
                {
                    var user = conversation.UserTwo;
                    conversation.UserTwo = conversation.UserOne;
                    conversation.UserOne = user;
                }
            }

                Conversations.AddRange(list);

            

            allConversations.AddRange(conv);

                
        }

        public async Task JoinConversation(INavigation navigation, string one, string two)
        {
            Conversation conv = allConversations.Where(x => (x.UserOne.Equals(one) && x.UserTwo.Equals(two)) || (x.UserOne.Equals(two) && x.UserTwo.Equals(one))).First();
            if(conv == null)
            {
                conv = new Conversation(one, two);
            }

            await navigation.PushAsync(new Chatroom(conv));

        }

    }
}
