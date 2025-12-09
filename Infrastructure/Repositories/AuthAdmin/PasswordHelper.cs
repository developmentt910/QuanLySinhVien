using System;
using System.Security.Cryptography;
using System.Text;

namespace StudentCourseManagement.Infrastructure.Repositories.AuthAdmin
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16; // 16 bytes = 128 bit
        private const int KeySize = 32;  // 32 bytes = 256 bit
        private const int Iterations = 10000; // số vòng băm

        public static string HashPassword(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] key = pbkdf2.GetBytes(KeySize);

            string saltBase64 = Convert.ToBase64String(salt);
            string keyBase64 = Convert.ToBase64String(key);
            return $"{Iterations}.{saltBase64}.{keyBase64}";
        }

     
        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            

            int iterations = int.Parse(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] key = Convert.FromBase64String(parts[2]);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            byte[] keyToCheck = pbkdf2.GetBytes(key.Length);

            return CryptographicOperations.FixedTimeEquals(key, keyToCheck);
        }
    }
}
