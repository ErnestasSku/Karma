using MobileUI.Services.Core;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileUI.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        ChatService chatService;
        public ChatService ChatService =>
            chatService ?? (chatService = DependencyService.Resolve<ChatService>());
    }
}
