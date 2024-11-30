using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection;


namespace HashFunctions
{
    public class hashPassword
    {
        public static string HashPassword(string password)
        {
            var sha = SHA256.Create();
            var ByteArray = Encoding.UTF8.GetBytes(password);
            var hashedPassword = sha.ComputeHash(ByteArray);
            return Convert.ToBase64String(hashedPassword);

            /*
            var sha = new SHA512CryptoServiceProvider();
            var hasedString = sha.ComputeHash(Encoding.Default.GetBytes(password + "CSE445/598"));
            return Convert.ToBase64String(hasedString);
            */
        }
    }
}
