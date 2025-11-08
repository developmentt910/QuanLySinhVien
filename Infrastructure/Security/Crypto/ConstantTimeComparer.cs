

namespace StudentCourseManagement.Infrastructure.Security.Crypto
{
    public static class ConstantTimeComparer
    {
        public static bool EqualsSlow(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
        {
            if (a.Length != b.Length) 
                return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}
