 

namespace StudentCourseManagement.Infrastructure.Security.Crypto
{
    public static class KeyHasher
    {
        public static byte[] Sha256(byte[] input)
            => SHA256.HashData(input);
    }
}
