

using StudentCourseManagement.Infrastructure.Repositories.AuthAdmin;

namespace StudentCourseManagement.Applications.Auth
{
    public sealed class LoginService
    {
        private readonly IRosterReader _usersR;
        private readonly CaptchaVerifier? _captcha;
        private readonly IRosterReader _rosterR;
        private readonly IRosterWriter _userW;


        public LoginService(
            IRosterReader usersR,
            IRosterReader rosterR,
            IRosterWriter userW,
            CaptchaVerifier? captcha = null)
        {
            _usersR = usersR;
            _rosterR = rosterR;
            _userW = userW;
            _captcha = captcha;
        }

        public string GenerateCaptcha() => _captcha?.Generate() ?? string.Empty;

        public async Task<(Roster? user, string? error)> LoginAsync(LoginDto dto)
        {
            // Kiểm tra Captcha
            if (_captcha != null && !_captcha.Verify(dto.CaptchaToken!, dto.CaptchaInput!))
                return (null, "Mã bảo vệ không đúng.");

            if (string.IsNullOrWhiteSpace(dto.PrivilegeCode))
                return (null, "Vui lòng nhập mã đặc quyền.");

            // Lấy user
            var user = await _usersR.FindByPrivilegeCode(dto.PrivilegeCode.Trim());
            if (user == null)
                return (null, "Tài khoản không tồn tại.");

            if (string.IsNullOrWhiteSpace(dto.Password))
                return (null, "Mật khẩu không được để trống.");

            bool isHashed = user.PasswordHash != null && user.PasswordHash.Contains('.');
            bool passwordValid = false;

            if (isHashed)
            {
                passwordValid = PasswordHelper.VerifyPassword(dto.Password, user.PasswordHash);
            }
            else
            {
                passwordValid = dto.Password.Equals(user.PasswordHash);

                if (passwordValid)
                {
                    string hashed = PasswordHelper.HashPassword(dto.Password);
                    await _userW.UpdatePasswordHashAsync(user.Id, hashed);

               
                    user.PasswordHash = hashed;
                }
            }

            if (!passwordValid)
                return (null, "Mật khẩu không đúng.");

            return (user, null); 
        }

    }

}
