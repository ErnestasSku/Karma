using System;
using System.Collections.Generic;
using System.Text;

namespace MobileUI.Models
{
    public class Message
    {
        public string UserName { get; set; }
        public string Text   { get; set; }
        public bool IsOwnerMessage { get; set; }

        public Message ()

        {

        }

        public Message(string username, string text, bool isOwner)
        {
            UserName = username;
                Text = text;
            IsOwnerMessage = isOwner;

        }

    }
}
