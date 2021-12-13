using System;
using System.Text;

namespace Backend.Utils
{
    public static class HashingUtilities
    {
        public static String CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static String GenerateSHA256Hash(String input, String salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256HashString = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256HashString.ComputeHash(bytes);
            return ByteArrayToHexString(hash);
        }
        public static String ByteArrayToHexString(byte[] array)
        {
            StringBuilder result = new StringBuilder(array.Length * 2);
            foreach (byte b in array)
            {
                result.AppendFormat("{0:x2}-", b);
            }
            result.Length = result.Length - 1;
            return result.ToString().ToUpper();
        }
    }
}
