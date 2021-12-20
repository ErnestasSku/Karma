using Microsoft.AspNetCore.SignalR.Client;
using MobileUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileUI.Services.Core
{
    public class ChatService
    {
        HubConnection hubConnection;
        public ChatService()
        {
            hubConnection = new HubConnectionBuilder().WithUrl("https://karmawebapi-in2.conveyor.cloud/chathub").Build();
        }
        public async Task Connect(string userName)
        {
            await hubConnection.StartAsync();
            //await hubConnection.InvokeAsync("OnConnect", userName);
        }

        public async Task Disconnect(string userName)
        {
            //await hubConnection.InvokeAsync("OnDisconnect", userName);
            await hubConnection.StopAsync();

        }

        public async Task SendMessage(string userId, string message, bool isPrivate = false)
        {
            if(isPrivate)
            {
               // await hubConnection.InvokeAsync("SendPrivateMessage", userId, message);
            }
            else
            {
                await hubConnection.InvokeAsync("SendMessage", userId, message);
            }
            
        }

        public void ReceiveMessage(Action<string, string> GetMessageAndUser, bool isPrivate = false)
        {
            if(isPrivate)
            {
                //hubConnection.On("ReceivePrivateMessage", GetMessageAndUser);
            }
            else
                hubConnection.On("ReceiveMessage", GetMessageAndUser);

        }
    }
}
