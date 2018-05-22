using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace pwgen
{
    class Program
    {
        static void Main(string[] args)
        {   
            string passwd = PasswordGen.GenerateCryptoPassword(8);
            Console.WriteLine(passwd);
        }

    }

    public static class PasswordGen 
    
    {
        public static string GenerateCryptoPassword(int length)
        {
            // list of valid characters
            const string valid = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ1234567890!@#$%?";
            // createa
            StringBuilder result = new StringBuilder();

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (result.Length < length)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    char converted_int = valid[(int)(num % (uint)valid.Length)];

                    // checks if char is already in the string. if not, add to string
                    // other wise generate a new char
                    if (!result.ToString().ToLower().Contains(converted_int.ToString().ToLower()))
                    {
                        result.Append(converted_int);
                    }
                }
            }
            return result.ToString();
        }
        
    }  
        
}