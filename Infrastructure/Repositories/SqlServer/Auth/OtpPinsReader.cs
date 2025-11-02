

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{
    public sealed class OtpPinsReader : IOtpPinsReader
    {
        private readonly SqlConnectionFactory _db;
        public OtpPinsReader(SqlConnectionFactory db) => _db = db;

        public async Task<(long Id, byte[] CodeHash, byte[] Salt, DateTime ExpiresAtUtc, int AttemptCount)?>
            GetLastActiveAsync(Guid userId, string purpose, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            const string sql = @"
                SELECT TOP 1 
                       Id, CodeHash, Salt, ExpiresAtUtc, AttemptCount
                FROM dbo.OtpPins
                WHERE UserId = @u
                  AND Purpose = @p
                  AND ConsumedAtUtc IS NULL
                  AND ExpiresAtUtc > SYSUTCDATETIME()
                ORDER BY CreatedAtUtc DESC;";

            await using var cmd = new SqlCommand(sql, conn)
            {
                CommandType = CommandType.Text
            };
            cmd.Parameters.Add(new SqlParameter("@u", SqlDbType.UniqueIdentifier) { Value = userId });
            cmd.Parameters.Add(new SqlParameter("@p", SqlDbType.NVarChar, 32) { Value = purpose });

            await using var r = await cmd.ExecuteReaderAsync(ct).ConfigureAwait(false);
            if (await r.ReadAsync(ct).ConfigureAwait(false))
            {
                var id = r.GetInt64(r.GetOrdinal("Id"));
                var hash = (byte[])r["CodeHash"];
                var salt = (byte[])r["Salt"];
                var exp = r.GetDateTime(r.GetOrdinal("ExpiresAtUtc"));
                var attempts = r.GetInt32(r.GetOrdinal("AttemptCount"));
                return (id, hash, salt, exp, attempts);
            }
            return null;
        }
    }
}
