namespace BusinessLogic
{
    public class UserIndexed
    {
        private User[] array = new User[1000];
        public User this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }
    }
}
