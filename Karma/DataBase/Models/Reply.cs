using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Models
{
    public class Reply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SenderUsername { get; set; }
        public string Content { get; set; }
        public int ConversationId { get; set; }
        public Reply()
        {

        }

        public Reply(string senderUsername, string content, int conversationId)
        {
            SenderUsername = senderUsername;
            Content = content;
            ConversationId = conversationId;
        }
    } 
}
