
namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{
    public sealed class UsersWriter : IUsersWriter
    {
        private readonly SqlConnectionFactory _db;
        public UsersWriter(SqlConnectionFactory db) => _db = db;

        public async Task<Guid> CreateAsync(User u, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            const string sql = @"
        INSERT INTO dbo.Users (
            Id, StudentCode, PrivilegeCode, FullName, EmailNormalized,ProfileImage,
            PhoneE164, CCCD, Role, RosterId,
            PasswordHash, EmailVerified, IsLocked,
            Gender, Address,
            ClassId, MajorId, SpecializationId, CohortYear,
            CreatedAtUtc, UpdatedAtUtc
        )
        OUTPUT inserted.Id
        VALUES (
            @Id, @StudentCode, @PrivilegeCode, @FullName, @EmailNormalized,@ProfileImage,
            @PhoneE164, @CCCD, @Role, @RosterId,
            @PasswordHash, @EmailVerified, @IsLocked,
            @Gender, @Address,
            @ClassId, @MajorId, @SpecializationId, @CohortYear,
            @CreatedAtUtc, @UpdatedAtUtc
        );";

            var id = u.Id != Guid.Empty ? u.Id : Guid.NewGuid();
                var scalar = await SqlHelpers.ExecScalarAsync(
                    conn,
                    tx: null,
                    sql,
                    CommandType.Text,
                    timeoutSeconds: default,
                    ct: ct,
                    SqlHelpers.P("@Id", id, SqlDbType.UniqueIdentifier),
                    SqlHelpers.P("@StudentCode", (object?)u.StudentCode ?? DBNull.Value, SqlDbType.NVarChar, 50),
                    SqlHelpers.P("@PrivilegeCode", (object?)u.PrivilegeCode ?? DBNull.Value, SqlDbType.NVarChar, 50),
                    SqlHelpers.P("@FullName", u.FullName, SqlDbType.NVarChar, 200),
                    SqlHelpers.P("@EmailNormalized", u.EmailNormalized, SqlDbType.NVarChar, 200),
                    SqlHelpers.P("@ProfileImage", (object?)u.ProfileImage ?? DBNull.Value, SqlDbType.VarBinary, -1),
                    SqlHelpers.P("@PhoneE164", (object?)u.PhoneE164 ?? DBNull.Value, SqlDbType.NVarChar, 20),
                    SqlHelpers.P("@CCCD", (object?)u.CCCD ?? DBNull.Value, SqlDbType.NVarChar, 12),
                    SqlHelpers.P("@Role", u.Role, SqlDbType.NVarChar, 50),
                    SqlHelpers.P("@RosterId", (object?)u.RosterId ?? DBNull.Value, SqlDbType.UniqueIdentifier),
                    SqlHelpers.P("@PasswordHash", (object?)u.PasswordHash ?? DBNull.Value, SqlDbType.NVarChar, 256),
                    SqlHelpers.P("@EmailVerified", u.EmailVerified, SqlDbType.Bit),
                    SqlHelpers.P("@IsLocked", u.IsLocked, SqlDbType.Bit),
                    SqlHelpers.P("@Gender", (object?)u.Gender ?? DBNull.Value, SqlDbType.NVarChar, 10),
                    SqlHelpers.P("@Address", (object?)u.Address ?? DBNull.Value, SqlDbType.NVarChar, 300),
                    SqlHelpers.P("@ClassId", (object?)u.ClassId ?? DBNull.Value, SqlDbType.UniqueIdentifier),
                    SqlHelpers.P("@MajorId", (object?)u.MajorId ?? DBNull.Value, SqlDbType.UniqueIdentifier),
                    SqlHelpers.P("@SpecializationId", (object?)u.SpecializationId ?? DBNull.Value, SqlDbType.UniqueIdentifier),
                    SqlHelpers.P("@CohortYear", (object?)u.CohortYear ?? DBNull.Value, SqlDbType.Int),
                    SqlHelpers.P("@CreatedAtUtc", u.CreatedAtUtc, SqlDbType.DateTime2),
                    SqlHelpers.P("@UpdatedAtUtc", u.UpdatedAtUtc, SqlDbType.DateTime2)
                ).ConfigureAwait(false);

                if (scalar is Guid g) return g;

                return id;
        }                
        public async Task LinkRosterUsedAsync(Guid rosterId, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = "UPDATE dbo.Roster SET IsUsed = 1 WHERE Id = @id;";
            await SqlHelpers.ExecNonQueryAsync(
                conn,
                tx: null,
                sql,
                CommandType.Text,
                timeoutSeconds: default,
                ct: ct,
                SqlHelpers.P("@id", rosterId, SqlDbType.UniqueIdentifier)
            ).ConfigureAwait(false);
        }

        //public async Task MarkEmailVerifiedAsync(Guid id, DateTime verifiedAtUtc, CancellationToken ct = default)
        //{
        //    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        //    const string sql = @"UPDATE dbo.Users SET EmailVerified = 1, UpdatedAtUtc = @ts WHERE Id = @id;";
        //    await SqlHelpers.ExecNonQueryAsync(
        //        conn,
        //        tx: null,
        //        sql,
        //        CommandType.Text,
        //        timeoutSeconds: default,
        //        ct: ct,
        //        SqlHelpers.P("@id", id, SqlDbType.UniqueIdentifier),
        //        SqlHelpers.P("@ts", verifiedAtUtc, SqlDbType.DateTime2)
        //    ).ConfigureAwait(false);
        //}

        //public async Task SetLockedAsync(Guid id, bool locked, CancellationToken ct = default)
        //{
        //    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        //    const string sql = "UPDATE dbo.Users SET IsLocked = @b, UpdatedAtUtc = @ts WHERE Id = @id;";
        //    await SqlHelpers.ExecNonQueryAsync(
        //        conn,
        //        tx: null,
        //        sql,
        //        CommandType.Text,
        //        timeoutSeconds: default,
        //        ct: ct,
        //        SqlHelpers.P("@b", locked, SqlDbType.Bit),
        //        SqlHelpers.P("@ts", DateTime.UtcNow, SqlDbType.DateTime2),
        //        SqlHelpers.P("@id", id, SqlDbType.UniqueIdentifier)
        //    ).ConfigureAwait(false);
        //}

        public async Task UpdatePasswordHashAsync(Guid id, string passwordHash, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            const string sql = "UPDATE dbo.Users SET PasswordHash = @p, UpdatedAtUtc = @ts WHERE Id = @id;";

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


        public async Task UpdateUserInfoAsync(User u, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct);

            const string sql = @"
                UPDATE Users
                SET FullName = @FullName,
                    Gender = @Gender,
                    Address = @Address,
                    CCCD = @CCCD,
                    PhoneE164 = @PhoneE164,
                    ProfileImage = @ProfileImage,
                    UpdatedAtUtc = @UpdatedAtUtc
                WHERE Id = @Id";

            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", u.Id);
            cmd.Parameters.AddWithValue("@FullName", u.FullName);
            cmd.Parameters.AddWithValue("@Gender", (object?)u.Gender ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", (object?)u.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CCCD", (object?)u.CCCD ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PhoneE164", (object?)u.PhoneE164 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ProfileImage", (object?)u.ProfileImage ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdatedAtUtc", DateTime.UtcNow);

            await cmd.ExecuteNonQueryAsync(ct);
        }




    }
}
