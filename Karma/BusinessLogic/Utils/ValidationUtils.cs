using System.Text.RegularExpressions;

namespace BusinessLogic.Utils
{
    public static class ValidationUtils
    {
        private static int MinimumPasswordLength = 8;

        public static bool isEmail(string email)
        {
            string regex = @".+@[A-Za-z]+\.[a-z]+";


            return Regex.IsMatch(email, regex);
        }

        public static bool isPhoneNumber(string phoneNumber)
        {
            //TODO: works in general cases, some edge cases might slip through
            string regex = @"\+?\d{5,10}";

            return Regex.IsMatch(phoneNumber, regex);
        }
        
        public static bool isPassword(string password)
        {
            if (password.Length < MinimumPasswordLength)
                return false;

            string regex = @".+";

            return Regex.IsMatch(password, regex);
        }
    }
}
