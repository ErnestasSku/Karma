﻿using System.IO;

namespace Backend.Utils
{
    public class UserUtilities
    {
        public bool IsUserDuplicate(string userName)
        {
            var fileText = File.ReadAllText("users.csv").Split('\n');
            foreach (var line in fileText)
            {
                var dataPieces = line.Split(",");
                if (dataPieces[2] == userName)
                {
                    return true;
                }
            }
            return false;
        }
        public void RegisterUserToFile(string name, string lastName, string userName, string password)
        {
            File.AppendAllText("user.csv", name + "," + lastName + "," + userName + "," + password + "\n");
        }
    }
}
