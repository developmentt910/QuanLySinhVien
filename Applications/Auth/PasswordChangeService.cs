

namespace StudentCourseManagement.Applications.Auth
{
    public sealed class PasswordChangeService
    {
        private readonly IUsersReader _usersR;
        private readonly IUsersWriter _usersW;

        public PasswordChangeService(IUsersReader usersR, IUsersWriter usersW)
        { _usersR = usersR; _usersW = usersW; }

        public async Task<Result> ChangeAsync(ChangePwdDto dto)
        {
            if (!RegexRules.IsMatch(dto.NewPassword, RegexRules.PasswordStrong))
                return Result.Fail("Mật khẩu mới chưa đủ mạnh.");

            var user = await _usersR.FindByStudentCode(dto.StudentCode);
            if (user is null) return Result.Fail("Không tìm thấy tài khoản.");

            if (!PasswordHasher.Verifier(dto.OldPassword, user.PasswordHash))
                return Result.Fail("Mật khẩu cũ không đúng.");

            var newHash = PasswordHasher.Hash(dto.NewPassword);
            await _usersW.UpdatePasswordHashAsync(user.Id, newHash);

            return Result.Success();
        }
    }
}
