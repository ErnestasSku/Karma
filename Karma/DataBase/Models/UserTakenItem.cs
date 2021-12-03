using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class UserTakenItem
    {

        public int ItemId { get; set;}
        public Item Item { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
