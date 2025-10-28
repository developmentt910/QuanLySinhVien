
namespace StudentCourseManagement.Infrastructure.Security.Crypto
{
    public static class PasswordHasher
    {

        // hash mk
        public static string Hash(string password, int iterations = 100_000)
        {
            var salt = RandomNumberGenerator.GetBytes(16);
            // 1 mang hash byte dai 32byte
            var bytes = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, 32);
            return $"$pbkdf2-sha256 " +
                $"${iterations} " +
                $"${Convert.ToBase64String(salt)} " +
                $"${Convert.ToBase64String(bytes)}";
        }

        // so sanh mk user input voi mk dc luu tru
        public static bool Verifier(string password, string stored)
        {
            try
            {
                var parts = stored.Split('$', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(p => p.Trim())
                                  .ToArray();

                if (parts.Length != 4 || parts[0] != "pbkdf2-sha256")
                    return false;

                var iterations = int.Parse(parts[1]);
                var salt = Convert.FromBase64String(parts[2]);
                var expected = Convert.FromBase64String(parts[3]);
                var computed = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, 32);

                return ConstantTimeComparer.EqualsSlow(expected, computed);
            }
            catch
            {
                return false;
            }
        }

    }
}
