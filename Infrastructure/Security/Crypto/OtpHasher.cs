

namespace StudentCourseManagement.Infrastructure.Security.Crypto
{
    public static class OtpHasher
    {
        public static string GenerateOtp6()
        {
            Span<byte> four = stackalloc byte[4];
            RandomNumberGenerator.Fill(four);
            uint val = BitConverter.ToUInt32(four);
            return (val % 1_000_000u).ToString("D6");

        }

        //public static (byte[] hash, byte[] salt) HashOtp(string otp)
        //{
        //    var salt = RandomNumberGenerator.GetBytes(16);
        //    using var h = new HMACSHA256(salt);
        //    return (h.ComputeHash(Encoding.UTF8.GetBytes(otp)), salt);

        //}

        //public static bool VerifyOtp(string otp, byte[] salt, byte[] hash)
        //{
        //    using var h = new HMACSHA256(salt);
        //    var test = h.ComputeHash(Encoding.UTF8.GetBytes(otp));
        //    return ConstantTimeComparer.EqualsSlow(test, hash);
        //}
    }
}
