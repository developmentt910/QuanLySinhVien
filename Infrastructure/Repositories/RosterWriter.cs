namespace StudentCourseManagement.Infrastructure.Repositories
{
    public sealed class RosterWriter : IRosterWriter
    {
        private readonly SqlConnectionFactory _db;
        public RosterWriter(SqlConnectionFactory db) => _db = db;


        public async Task UpdatePasswordHashAsync(Guid id, string passwordHash, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            const string sql = "UPDATE dbo.Roster SET PasswordHash = @p WHERE Id = @id;";

            await SqlHelpers.ExecNonQueryAsync(
                conn,
                tx: null,
                sql,
                CommandType.Text,
                timeoutSeconds: default,
                ct: ct,

                SqlHelpers.P("@p", passwordHash ?? "", SqlDbType.NVarChar, 512),
                SqlHelpers.P("@ts", DateTime.UtcNow, SqlDbType.DateTime2),
                SqlHelpers.P("@id", id, SqlDbType.UniqueIdentifier)
            ).ConfigureAwait(false);
        }


        public async Task UpdateUserInfoAsync(Roster u, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct);

            const string sql = @"
                UPDATE Roster
                SET FullName = @FullName,
                    PrivilegeCode = @PrivilegeCode,
                    Gender = @Gender,
                    Address = @Address,
                    CCCD = @CCCD,
                    Phone164 = @Phone164,
                    ProfileImage = @ProfileImage               
                WHERE Id = @Id";

            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", u.Id);
            cmd.Parameters.AddWithValue("@FullName", u.FullName);
            cmd.Parameters.AddWithValue("@PrivilegeCode", u.PrivilegeCode);
            cmd.Parameters.AddWithValue("@Gender", (object?)u.Gender ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", (object?)u.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CCCD", (object?)u.CCCD ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone164", (object?)u.Phone164 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ProfileImage", (object?)u.ProfileImage ?? DBNull.Value);

            await cmd.ExecuteNonQueryAsync(ct);
        }




    }
}
