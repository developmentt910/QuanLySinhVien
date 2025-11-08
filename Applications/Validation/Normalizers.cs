

namespace StudentCourseManagement.Applications.Validation
{
    public static class Normalizers
    {
        public static string NormalizeFullName(string name)
        {
            var x = (name ?? string.Empty).Trim();
            x = Regex.Replace(x, @"\s+", " ");
            var ti = CultureInfo.GetCultureInfo("vi-VN").TextInfo;
            return ti.ToTitleCase(x.ToLower());
        }

        public static string NormalizeEmail(string email) 
            => (email ?? string.Empty).Trim().ToLowerInvariant();

        public static string NormalizeCccd(string? input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return Regex.Replace(input, @"[^\d]", "");
        }

        public static string NormailizeStudentCode(string? code)
        {
            if(string.IsNullOrEmpty(code)) return string.Empty;
            return code.Trim().ToLowerInvariant();
        }
        public static string NormalizePhoneToVN(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            var cleaned = new string(input.Where(c => char.IsDigit(c) || c == '+').ToArray());

            if (cleaned.StartsWith("0") && cleaned.Length == 10)
                return "+84" + cleaned.Substring(1);

            if (cleaned.StartsWith("+84"))
            {
                if (cleaned.Length == 12) return cleaned;
                if (cleaned.Length == 11) return "+84" + cleaned.Substring(3);
            }

            if (cleaned.Length == 9)
                return "+849" + cleaned; 

            return cleaned; 
        }

    }
}
