using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Models
{
    public class Conversation
    {




        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConversationId   { get; set; }
        public string UserOne { get; set; }
        public string UserTwo { get; set; }

        public Conversation()
        {

        }
        public Conversation(string one, string two)
        {
            UserOne = one;
            UserTwo = two;
        }

    }
}
