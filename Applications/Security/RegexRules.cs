namespace StudentCourseManagement.Applications.Security
{
    public class RegexRules
    {
        
        //public const string FullNameBasic = @"^[\p{L}\p{M} ]{2,128}$";      
        public const string PasswordStrong = @"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{12,}$";
        //public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        //public const string StudentCode = @"^[A-Za-z0-9]{4,32}$";
        //public const string Cccd = @"^\d{12}$";
        //public const string Phone10Digits = @"^\d{10}$";



        public static bool IsMatch(string? input, string pattern)
    => !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, pattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);


        //pattern: regex mau
    }
}
