using Backend;
using System.Collections.Generic;

namespace DataBase.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public Location Location { get; set; }

        public List<Item> PostedItems { get; set; } 
    }
}
