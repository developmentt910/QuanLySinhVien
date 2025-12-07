

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

            if (!string.Equals(user.PasswordHash, oldPwd))
                return "Mật khẩu cũ không chính xác.";

            user.PasswordHash = newPwd;

            await _writer.UpdatePasswordHashAsync(userId, newPwd);

            return null; // thành công
        }


    }

}

