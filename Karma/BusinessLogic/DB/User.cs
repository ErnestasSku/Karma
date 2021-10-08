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
        string Name { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string password { get; set; }

        //Stuff like House Adress, Phone number (they can also be optional if people don't want to give their data)
        
        //Token might be useful for authentification stuff maybe? 
        //string Token;

    }
}
