namespace StudentCourseManagement.Infrastructure.Repositories
{
    public sealed class RosterReader : IRosterReader
    {
        private readonly SqlConnectionFactory _db;
        public RosterReader(SqlConnectionFactory db) => _db = db;

        private const string UserColumns = @"
            Id, PrivilegeCode, FullName, EmailSchool,ProfileImage,
            Phone164, CCCD, Role, Gender, Address,
            PasswordHash";




        public async Task<Roster?> FindByIdAsync(Guid id, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT TOP 1 {UserColumns}
                            FROM dbo.Roster
                            WHERE Id = @i";

            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@i", SqlDbType.UniqueIdentifier) { Value = id }
            ).ConfigureAwait(false);

            if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
            return null;
        }


        public async Task<bool> PrivilegeCodeExistsAsync(string privilegeCode, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(privilegeCode))
                return false;

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 FROM dbo.Roster WHERE PrivilegeCode = @p";

            var v = await SqlHelpers.ExecScalarAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@p", SqlDbType.NVarChar, 50)
                { Value = (object?)privilegeCode ?? DBNull.Value }
            ).ConfigureAwait(false);

            return v is not null;
        }
        public async Task<Roster?> FindByPrivilegeCode(string privilegeCode, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(privilegeCode))
                return null;

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT TOP 1 {UserColumns}
                    FROM dbo.Roster
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


        private static Roster Map(SqlDataReader rs) => new()
        {
            Id = rs.GetGuid(rs.GetOrdinal("Id")),
            PrivilegeCode = rs["PrivilegeCode"] as string,
            FullName = rs["FullName"] as string,
            EmailSchool = rs["EmailSchool"] as string,
            Gender = rs["Gender"] as string,
            Address = rs["Address"] as string,
            Role = rs["Role"] as string,
            PasswordHash = rs["PasswordHash"] as string,
            ProfileImage = rs["ProfileImage"] as byte[],
            CCCD = rs["CCCD"] as string,
            Phone164 = rs["Phone164"] as string,
        };

    };
}