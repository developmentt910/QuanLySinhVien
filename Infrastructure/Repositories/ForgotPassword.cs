using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Infrastructure.Repositories
{
    public class ForgotPassword
    {
        private readonly string _conn;

        public ForgotPassword(string conn)
        {
            _conn = conn;
        }

        private SqlConnection Connect() => new SqlConnection(_conn);

        public async Task<Guid?> GetUserIdByEmailAsync(string email)
        {
            const string sql = "SELECT Id FROM Roster WHERE EmailSchool = @e";

            using var conn = Connect();
            await conn.OpenAsync();

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@e", email);

            var result = await cmd.ExecuteScalarAsync();
            return result == null ? null : (Guid)result;
        }

        public async Task InsertOtpAsync(Guid userId, string otp)
        {
            const string sql = @"
INSERT INTO OtpPins(UserId, OtpCode, ExpiresAtUtc, CreatedAtUtc)
VALUES(@u, @o, DATEADD(MINUTE, 5, SYSUTCDATETIME()), SYSUTCDATETIME())";

            using var conn = Connect();
            await conn.OpenAsync();

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", userId);
            cmd.Parameters.AddWithValue("@o", otp);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<(long id, string otp, DateTime expires)?> GetLatestOtpAsync(Guid userId)
        {
            const string sql = @"
SELECT TOP 1 Id, OtpCode, ExpiresAtUtc
FROM OtpPins
WHERE UserId = @u AND Consumed = 0
ORDER BY CreatedAtUtc DESC";

            using var conn = Connect();
            await conn.OpenAsync();

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", userId);

            using var reader = await cmd.ExecuteReaderAsync();
            if (!reader.Read()) return null;

            return (
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetDateTime(2)
            );
        }

        public async Task MarkOtpUsedAsync(long id)
        {
            const string sql = "UPDATE OtpPins SET Consumed = 1 WHERE Id = @i";

            using var conn = Connect();
            await conn.OpenAsync();

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@i", id);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdatePasswordAsync(Guid userId, string newPwd)
        {
            const string sql = "UPDATE Roster SET PasswordHash = @p WHERE Id = @u";

            using var conn = Connect();
            await conn.OpenAsync();

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@p", newPwd);
            cmd.Parameters.AddWithValue("@u", userId);

            await cmd.ExecuteNonQueryAsync();
        }
    }

}
