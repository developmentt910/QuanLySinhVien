

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{
    public sealed class UsersReader : IUsersReader
    {
        private readonly SqlConnectionFactory _db;
        public UsersReader(SqlConnectionFactory db) => _db = db;

        private const string UserColumns = @"
            Id, StudentCode, PrivilegeCode, FullName, EmailNormalized,ProfileImage,
            PhoneE164, CCCD, Role, RosterId, Gender, Address,
            PasswordHash, EmailVerified, IsLocked";



        //public async Task<User?> FindByEmailAsync(string emailNormalized, CancellationToken ct = default)
        //{
        //    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        //    string sql = $@"SELECT TOP 1 {UserColumns}
        //                    FROM dbo.Users
        //                    WHERE EmailNormalized = @e";

        //    await using var r = await SqlHelpers.ExecReaderAsync(
        //        conn, tx: null, sql, ct: ct,
        //        ps: new SqlParameter("@e", SqlDbType.NVarChar, 320)
        //        { Value = (object?)emailNormalized ?? DBNull.Value }
        //    ).ConfigureAwait(false);

        //    if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
        //    return null;
        //}

        public async Task<User?> FindByStudentCode(string studentCode, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT TOP 1 {UserColumns}
                            FROM dbo.Users
                            WHERE StudentCode = @s";

            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, ct: ct,
                ps: new[]
                    {
                        new SqlParameter("@s", SqlDbType.NVarChar, 32) { Value = (object?)studentCode ?? DBNull.Value },
                    }

            ).ConfigureAwait(false);

            if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
            return null;
        }

        public async Task<User?> FindByIdAsync(Guid id, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT TOP 1 {UserColumns}
                            FROM dbo.Users
                            WHERE Id = @i";

            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@i", SqlDbType.UniqueIdentifier) { Value = id }
            ).ConfigureAwait(false);

            if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
            return null;
        }

        public async Task<bool> EmailExistsAsync(string emailNormalized, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 FROM dbo.Users WHERE EmailNormalized = @e";

            var v = await SqlHelpers.ExecScalarAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@e", SqlDbType.NVarChar, 320)
                { Value = (object?)emailNormalized ?? DBNull.Value }
            ).ConfigureAwait(false);

            return v is not null;
        }

        public async Task<bool> CccdExistsAsync(string cccd, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 FROM dbo.Users WHERE CCCD = @c";

            var v = await SqlHelpers.ExecScalarAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@c", SqlDbType.NVarChar, 12)
                { Value = (object?)cccd ?? DBNull.Value }
            ).ConfigureAwait(false);

            return v is not null;
        }

        public async Task<bool> StudentCodeExistsAsync(string studentCode, CancellationToken ct = default)
        {

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 FROM dbo.Users WHERE StudentCode = @s";

            var v = await SqlHelpers.ExecScalarAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@s", SqlDbType.NVarChar, 32)
                { Value = (object?)studentCode ?? DBNull.Value }
            ).ConfigureAwait(false);

            return v is not null;
        }

        public async Task<bool> PrivilegeCodeExistsAsync(string privilegeCode, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(privilegeCode))
                return false;

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 FROM dbo.Users WHERE PrivilegeCode = @p";

            var v = await SqlHelpers.ExecScalarAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@p", SqlDbType.NVarChar, 50)
                { Value = (object?)privilegeCode ?? DBNull.Value }
            ).ConfigureAwait(false);

            return v is not null;
        }
        public async Task<User?> FindByPrivilegeCode(string privilegeCode, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(privilegeCode))
                return null;

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT TOP 1 {UserColumns}
                    FROM dbo.Users
                    WHERE PrivilegeCode = @p";

            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@p", SqlDbType.NVarChar, 50)
                { Value = (object?)privilegeCode ?? DBNull.Value }
            ).ConfigureAwait(false);

            if (await r.ReadAsync(ct).ConfigureAwait(false))
                return Map(r);

            return null;
        }




          private static User Map(SqlDataReader r) => new()
          {
              Id = r.GetGuid(r.GetOrdinal("Id")),
              StudentCode = r["StudentCode"] as string,
              PrivilegeCode = r["PrivilegeCode"] as string,
              FullName = r["FullName"] as string ?? "",
              EmailNormalized = r["EmailNormalized"] as string ?? "",
              PhoneE164 = r["PhoneE164"] as string,
              CCCD = r["CCCD"] as string ?? "",
              Role = r["Role"] as string ?? "user",
              RosterId = r.IsDBNull(r.GetOrdinal("RosterId")) ? null : r.GetGuid(r.GetOrdinal("RosterId")),
              PasswordHash = r.IsDBNull(r.GetOrdinal("PasswordHash"))
                 ? null 
                 : r.GetString(r.GetOrdinal("PasswordHash")),
              ProfileImage = r.IsDBNull(r.GetOrdinal("ProfileImage"))
                ? null
                : (byte[])r["ProfileImage"],


              EmailVerified = !r.IsDBNull(r.GetOrdinal("EmailVerified")) && Convert.ToBoolean(r["EmailVerified"]),
              IsLocked = !r.IsDBNull(r.GetOrdinal("IsLocked")) && Convert.ToBoolean(r["IsLocked"]),
              Gender = r["Gender"] as string,
              Address = r["Address"] as string,
          };

    };
    }
