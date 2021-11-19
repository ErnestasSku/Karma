using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataBase.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        
        [Phone]
        public string PhoneNumber { get; set; }

        //public Location Location { get; set; }

        public List<Item> PostedItems { get; set; }

        public User(string userName, string password, string email)
        {
            UserName = UserName;
            Password = password;
            Email = email;
        }

    }
}
