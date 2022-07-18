
using Database.Models;
using MobileUI.Models;
using MobileUI.Services.Core;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileUI.ViewModels

{
    public class ChatViewModel : ViewModelBase
    {

        

        private readonly ChatService chatService;
        public static Conversation conv = null;
        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }
        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }
        private ObservableCollection<Message> messageList;
        public ObservableCollection<Message> MessagesList
        {
            get => messageList;
            set => SetProperty(ref messageList, value);
        }

        public Command SendMessageCommand { get; }
        public Command ConnectCommand { get; }
        public Command DisconnectCommand { get; }

        public Command LoadMessagesCommand { get; }

        public ChatViewModel()
        {
            Title = conv.UserTwo;
            chatService = new ChatService();
            SendMessageCommand = new Command(async () => await SendMessage());
            ConnectCommand = new Command(async () => await Connect(App.CurrentUser.Username));
            DisconnectCommand = new Command(async () => await Disconnect());
            LoadMessagesCommand = new Command(async () => await LoadMessages(conv));
            UserName = App.CurrentUser.Username;

            LoadMessagesCommand.Execute(conv);
            try
            {
                chatService.ReceiveMessage(GetMessage);
            }
            catch (Exception ex)
            {

            }

        }

        private async Task LoadMessages(Conversation conv)
        {
            var json = await App.Client.GetStringAsync("api/Reply");
            var replies = JsonConvert.DeserializeObject<List<Reply>>(json);
            var list = replies.Where(x => x.ConversationId == conv.ConversationId);
            MessagesList = new ObservableCollection<Message>();
            RepliesToMessages(list);
        }

        async Task Connect(string userName)
        {
            try
            {
                IsBusy = true;
                await chatService.Connect(userName);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        async Task Disconnect()
        {
            try
            {
                IsBusy = true;
                await chatService.Disconnect(UserName);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task SendMessage()
        {
            await chatService.SendMessage(UserName, Message);
            AddMessage(UserName, Message, true);
            Reply reply = new Reply(App.CurrentUser.Username, Message, conv.ConversationId);
            Message = string.Empty;
            var json = JsonConvert.SerializeObject(reply);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await App.Client.PostAsync("api/Reply", content);

            if (!response.IsSuccessStatusCode)
            {

            }
        }

        private void GetMessage(string userName, string message)
        {
            AddMessage(userName, message, false);
        }


        private void AddMessage(string userName, string message, bool isOwner)
        {
            var tempList = MessagesList.ToList();
            tempList.Add(new Message { IsOwnerMessage = isOwner, Text = message, UserName = userName });
            MessagesList = new ObservableCollection<Message>(tempList);

        }

        public void RepliesToMessages(IEnumerable<Reply> list)
        {
            foreach (Reply reply in list)
            {
                bool b = false;
                if(reply.SenderUsername == App.CurrentUser.Username)
                {
                    b = true;
                }
                Message message = new Message(reply.SenderUsername, reply.Content, b);

                MessagesList.Add(message);
            }
        }


    }
}
