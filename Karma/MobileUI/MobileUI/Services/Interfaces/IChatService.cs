using System;
using System.Threading.Tasks;

namespace MobileUI.Services.Interfaces
{
    public interface IChatService
    {

        Task Connect();
        Task Disconnect();
        Task SendMessage(string userId, string message);
        void ReceiveMessage(Action<string, string> GetMessageAndUser);
    }
}
