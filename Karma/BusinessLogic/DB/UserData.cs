using System.Collections;
using System.Collections.Generic;
using Backend.Utils;

namespace Backend
{
    /// <summary>
    /// TODO:
    /// </summary>
    /// This should be similar to ItemData.cs. This class would be as a standalone for our "Database"
    public class UserData : DataInteface<User>, IEnumerable<User>
    {
        private static UserData instance = null;

        public List<User> UserList;

        private UserData()
        {
            lock (this)
            {
                UserList = new List<User>();
            }
        }

        static public UserData GetInstance()
        {
            if (instance == null)
                instance = new UserData();

            return instance;
        }

        public void LoadData()
        {

        }
        public void ReloadData()
        {

        }
        public void AddData(User data)
        {
            UserList.Add(data);
        }

        public void RemoveData(User data)
        {
            bool removed = UserList.Remove(data);

            if (!removed)
            {
                Logger.Error("Could not remove specified data");
            }
        }
        public void RemoveDataAt(int index)
        {

        }
        public List<User> Sort(int flag)
        {
            return UserList;
        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)UserList).GetEnumerator();
        }
        IEnumerator<User> IEnumerable<User>.GetEnumerator()
        {
            return ((IEnumerable<User>)UserList).GetEnumerator();
        }
    }
}
