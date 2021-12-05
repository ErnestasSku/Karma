using DataBase.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class SentMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SentMesageId { get; set; }

        public int MessageId { get; set; }
        public Message Message { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }

        public bool Seen { get; set; }
        public DateTime Time { get; set; }

        public SentMessage()
        {
            
        }
    }
}
