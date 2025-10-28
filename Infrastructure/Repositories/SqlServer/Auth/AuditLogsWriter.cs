

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{
    public sealed class AuditLogsWriter : IAuditLogsWriter
    {
        private readonly SqlConnectionFactory _db;

        public AuditLogsWriter(SqlConnectionFactory db) => _db = db;

        private const string InsertSql = @"
INSERT INTO dbo.AuditLogs (UserId, Action, Detail, CreatedAtUtc)
VALUES (@u, @a, @d, @t);";

        public async Task WriteAsync(AuditLogEntry entry, CancellationToken ct = default)
        {
            if (entry is null) throw new ArgumentNullException(nameof(entry));
            if (string.IsNullOrWhiteSpace(entry.Action))
                throw new ArgumentException("Audit action is required.", nameof(entry));

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            await using var cmd = new SqlCommand(InsertSql, conn) { CommandType = CommandType.Text };

            cmd.Parameters.Add(new SqlParameter("@u", SqlDbType.UniqueIdentifier)
            { Value = (object?)entry.UserId ?? DBNull.Value });

            cmd.Parameters.Add(new SqlParameter("@a", SqlDbType.NVarChar, 64)
            { Value = entry.Action });

            cmd.Parameters.Add(new SqlParameter("@d", SqlDbType.NVarChar, 1024)
            { Value = (object?)entry.Detail ?? DBNull.Value });

            cmd.Parameters.Add(new SqlParameter("@t", SqlDbType.DateTime2)
            { Value = entry.CreatedAtUtc == default ? DateTime.UtcNow : entry.CreatedAtUtc });

            await cmd.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
        }

        public async Task WriteManyAsync(IEnumerable<AuditLogEntry> entries, CancellationToken ct = default)
        {
            if (entries is null) throw new ArgumentNullException(nameof(entries));

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            await using var tx = await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

            try
            {
                await using var cmd = new SqlCommand(InsertSql, conn, (SqlTransaction)tx)
                { CommandType = CommandType.Text };

                var pUser = cmd.Parameters.Add("@u", SqlDbType.UniqueIdentifier);
                var pAction = cmd.Parameters.Add("@a", SqlDbType.NVarChar, 64);
                var pDetail = cmd.Parameters.Add("@d", SqlDbType.NVarChar, 1024);
                var pTime = cmd.Parameters.Add("@t", SqlDbType.DateTime2);

                foreach (var e in entries)
                {
                    if (e is null) continue;
                    if (string.IsNullOrWhiteSpace(e.Action))
                        throw new ArgumentException("Audit action is required.", nameof(entries));

                    pUser.Value = (object?)e.UserId ?? DBNull.Value;
                    pAction.Value = e.Action;
                    pDetail.Value = (object?)e.Detail ?? DBNull.Value;
                    pTime.Value = e.CreatedAtUtc == default ? DateTime.UtcNow : e.CreatedAtUtc;

                    await cmd.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
                }

                await tx.CommitAsync(ct).ConfigureAwait(false);
            }
            catch
            {
                await tx.RollbackAsync(ct).ConfigureAwait(false);
                throw;
            }
        }
    }
}
