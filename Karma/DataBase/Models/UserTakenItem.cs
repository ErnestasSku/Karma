using DataBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Models
{
    public class UserTakenItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTakenItemId { get; set; }
        public int ItemId { get; set;}
        public Item Item { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public UserTakenItem()
        {
            
        }
    }
}
