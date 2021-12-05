using DataBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        
        public string MessageText { get; set; }

        public int RelatedItemId { get; set; }

        public Item RelatedItem { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }

        public Message()
        {

        }

    }
}
