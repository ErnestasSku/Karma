using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// TODO: UserProfile will be a singleton of UserData? or maybe this is not even needed.
    /// TODO: figure out how the UserProfile will work.
    /// </summary>
    public class User
    {
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User(string _Name, string _LastName, string _UserName, string _Password)
        {
            Name = _Name;
            LastName = _LastName;
            UserName = _UserName;
            Password = _Password;
        }
        //Stuff like House Adress, Phone number (they can also be optional if people don't want to give their data)

        //Token might be useful for authentification stuff maybe? 
        //string Token;

    }
}
