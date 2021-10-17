using Backend;

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

        public Location Location;

        public User(string _Name, string _LastName, string _UserName, string _Password)
        {
            Name = _Name;
            LastName = _LastName;
            UserName = _UserName;
            Password = _Password;
        }
    }
}
