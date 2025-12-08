

namespace StudentCourseManagement.Applications.Auth
{
    public class PasswordChangeService
    {
        private readonly IRosterReader _reader;
        private readonly IRosterWriter _writer;

        public PasswordChangeService(IRosterReader reader, IRosterWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public async Task<string?> ChangePasswordAsync(Guid userId, string oldPwd, string newPwd)
        {
            var user = await _reader.FindByIdAsync(userId);
            if (user == null)
                return "Không tìm thấy người dùng.";

            bool isHashed = user.PasswordHash != null && user.PasswordHash.Contains('.');
            bool oldPasswordValid = false;

            if (isHashed)
            {
                oldPasswordValid = PasswordHelper.VerifyPassword(oldPwd, user.PasswordHash);
            }
            else
            {
                oldPasswordValid = string.Equals(oldPwd, user.PasswordHash);

                if (oldPasswordValid)
                {
                    string hashedOld = PasswordHelper.HashPassword(oldPwd);
                    await _writer.UpdatePasswordHashAsync(userId, hashedOld);
                    user.PasswordHash = hashedOld;
                }
            }

            if (!oldPasswordValid)
                return "Mật khẩu cũ không chính xác.";

            string newHashed = PasswordHelper.HashPassword(newPwd);
            user.PasswordHash = newHashed;

            await _writer.UpdatePasswordHashAsync(userId, newHashed);

            return null; // thành công
        }
    }

}


