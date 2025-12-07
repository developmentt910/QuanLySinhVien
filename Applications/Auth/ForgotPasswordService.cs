using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace StudentCourseManagement.Infrastructure.Security
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly SqlConnectionFactory _db;

        public ForgotPasswordService(SqlConnectionFactory db)
        {
            _db = db;
        }

        public async Task<Guid?> GetUserIdByEmailAsync(string email)
        {
            using var conn = await _db.OpenAsync();

            string sql = "SELECT Id FROM Roster WHERE EmailSchool = @EmailSchool";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EmailSchool", email);

            var result = await cmd.ExecuteScalarAsync();
            if (result == null) return null;

            return Guid.Parse(result.ToString());
        }

        public async Task<bool> InsertOtpAsync(Guid userId, string otp)
        {
            using var conn = await _db.OpenAsync();

            string sql = @"
        INSERT INTO OtpPins(UserId, OtpCode, ExpiresAtUtc, CreatedAtUtc)
        VALUES (@UserId, @Otp, DATEADD(MINUTE, 3, GETDATE()), GETDATE())
    ";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Otp", otp);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }


        public async Task<bool> VerifyOtpAsync(Guid userId, string otp)
        {
            using var conn = await _db.OpenAsync();

            string sql = @"
    SELECT COUNT(*) FROM OtpPins
    WHERE UserId = @UserId
      AND OtpCode = @Otp
      AND CreatedAtUtc >= DATEADD(MINUTE, -3, GETDATE())
";


            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Otp", otp);

            int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return count > 0;
        }

        public async Task UpdatePasswordAsync(Guid userId, string newPassword)
        {
            using var conn = await _db.OpenAsync();

            string sql = @"UPDATE Roster 
                           SET PasswordHash = @Pwd 
                           WHERE Id = @UserId";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Pwd", newPassword);
            cmd.Parameters.AddWithValue("@UserId", userId);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<bool> SendOtpAsync(string email)
        {
            var userId = await GetUserIdByEmailAsync(email);
            if (userId == null) return false;

            string otp = new Random().Next(100000, 999999).ToString();

            bool inserted = await InsertOtpAsync(userId.Value, otp);
            if (!inserted) return false;

            await SendEmailOtpAsync(email, otp);

            return true;
        }



        public async Task<string> ResetPasswordAsync(string email, string otp, string newPassword)
        {
            var userId = await GetUserIdByEmailAsync(email);
            if (userId == null)
                return "Email không tồn tại.";

            bool otpValid = await VerifyOtpAsync(userId.Value, otp);
            if (!otpValid)
                return "OTP không đúng hoặc đã hết hạn.";

            await UpdatePasswordAsync(userId.Value, newPassword);

            return "OK";
        }

        private async Task SendEmailOtpAsync(string email, string otp)
        {
            var message = new MailMessage();
            message.From = new MailAddress(EmailConfig.SenderEmail);
            message.To.Add(email);

            message.Subject = "Mã OTP xác thực tài khoản";
            message.Body = $"Mã OTP của bạn là: {otp}\nMã có hiệu lực trong 3 phút.";
            message.IsBodyHtml = false;

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(EmailConfig.SenderEmail, EmailConfig.AppPassword),
                EnableSsl = true
            };

            await smtp.SendMailAsync(message);
        }

    }
}
