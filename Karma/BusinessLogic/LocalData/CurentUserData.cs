using System.IO;

namespace BusinessLogic.LocalData
{
    /// <summary>
    /// Todo:
    /// </summary>
    /// This could be the logged in user's data.
    /// 
    /// It should have methods such as Authenicate(string userName, string password)
    /// and RetrieveUserData?
    public class CurentUserData
    {
        User currentUser;
        public User Authenticate(string userName, string password)
        {
            var fileText = File.ReadAllText("users.csv").Split('\n');
            foreach (var line in fileText)
            {
                var dataPieces = line.Split(",");
                if (dataPieces[2] == userName && dataPieces[3] == password)
                {
                    User user = new User(dataPieces[0], dataPieces[1], dataPieces[2], dataPieces[3]);
                    return user;
                }
            }
            return null;
        }
    }
}
