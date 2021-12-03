using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class SentMessage
    {
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }

        public bool Seen { get; set; }
        public DateTime Time { get; set; }
    }
}
