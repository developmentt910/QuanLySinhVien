

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{
    public sealed class RosterReader : IRosterReader
    {
        private readonly SqlConnectionFactory _db;
        public RosterReader(SqlConnectionFactory db) => _db = db;

        //Tìm theo ID 
        //public async Task<Roster?> FindByIdAsync(Guid id, CancellationToken ct = default)
        //{
        //    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        //    const string sql = "SELECT TOP 1 * FROM dbo.Roster WHERE Id = @id";
        //    await using var r = await SqlHelpers.ExecReaderAsync(
        //        conn, tx: null, sql, CommandType.Text, timeoutSeconds: default, ct: ct,
        //        ps: new[] { SqlHelpers.P("@id", id, SqlDbType.UniqueIdentifier) });


        //    if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
        //    return null;
        //}

        // Tìm theo mã sinh viên


        //  Tìm theo email trường 

        // Kiểm tra sinh viên còn hiệu lực hay không
        //public async Task<bool> IsActiveAsync(Guid id, DateTime utcNow, CancellationToken ct = default)
        //{
        //    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        //    const string sql = @"SELECT 1 
        //                         FROM dbo.Roster 
        //                         WHERE Id = @id 
        //                           AND (ExpiresAtUtc IS NULL OR ExpiresAtUtc > @now)";
        //    var scalar = await SqlHelpers.ExecScalarAsync(conn, null, sql, ct: ct,
        //        ps: new[] { SqlHelpers.P("@id", id, SqlDbType.UniqueIdentifier),
        //                    SqlHelpers.P("@now", utcNow, SqlDbType.DateTime2) });

        //    return scalar is not null;
        //}

        // Tìm kiếm theo keyword (mã hoặc email)
        //public async Task<IReadOnlyList<Roster>> SearchAsync(string? keyword, int skip, int take, CancellationToken ct = default)
        //{
        //    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        //    const string sql = @"SELECT Id, StudentCode, EmailSchool, FullName, IsUsed, ExpiresAtUtc, CreatedAtUtc
        //                         FROM dbo.Roster
        //                         WHERE (@kw IS NULL 
        //                             OR StudentCode LIKE '%' + @kw + '%' 
        //                             OR EmailSchool LIKE '%' + @kw + '%')
        //                         ORDER BY CreatedAtUtc DESC
        //                         OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";

        //    await using var r = await SqlHelpers.ExecReaderAsync(
        //                    conn,
        //                    tx: null,
        //                    sql,
        //                    CommandType.Text,
        //                    timeoutSeconds: default,
        //                    ct: ct,
        //                    ps: new[] {
        //                        SqlHelpers.P("@kw", (object?)keyword ?? DBNull.Value, SqlDbType.NVarChar, 256),
        //                        SqlHelpers.P("@skip", skip, SqlDbType.Int),
        //                        SqlHelpers.P("@take", take, SqlDbType.Int)
        //                    });


        //    var list = new List<Roster>();
        //    while (await r.ReadAsync(ct).ConfigureAwait(false))
        //        list.Add(Map(r));

        //    return list;
        //}

        public async Task<Roster?> FindByStudentCodeAsync(string studentCode, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = "SELECT TOP 1 * FROM dbo.Roster WHERE StudentCode = @s";
            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, CommandType.Text, timeoutSeconds: default, ct: ct,
                ps: new[] { SqlHelpers.P("@s", studentCode, SqlDbType.NVarChar, 32) });


            if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
            return null;
        }

        public async Task<Roster?> FindByPrivilegeCodeAsync(string privilegeCode, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(privilegeCode))
                return null;

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = "SELECT TOP 1 * FROM dbo.Roster WHERE PrivilegeCode = @p";

            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, CommandType.Text, timeoutSeconds: default, ct: ct,
                ps: new[] { SqlHelpers.P("@p", privilegeCode, SqlDbType.NVarChar, 50) });

            if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
            return null;
        }
        private static Roster Map(SqlDataReader r) => new Roster
        {
            Id = r.GetGuid(r.GetOrdinal("Id")),
            StudentCode = r["StudentCode"] as string ?? "",
            EmailSchool = r["EmailSchool"] as string ?? "",
            FullName = r["FullName"] as string ?? "",
            Gender = r["Gender"] as string ?? "",
            Address = r["Address"] as string ?? "",
            PrivilegeCode = r["PrivilegeCode"] as string,
            Role = r["Role"] as string ?? "user",
            IsUsed = !r.IsDBNull(r.GetOrdinal("IsUsed")) && r.GetBoolean(r.GetOrdinal("IsUsed")),
            ClassId = r.IsDBNull(r.GetOrdinal("ClassId")) ? null : r.GetGuid(r.GetOrdinal("ClassId")),
            MajorId = r.IsDBNull(r.GetOrdinal("MajorId")) ? null : r.GetGuid(r.GetOrdinal("MajorId")),
            SpecializationId = r.IsDBNull(r.GetOrdinal("SpecializationId")) ? null : r.GetGuid(r.GetOrdinal("SpecializationId")),

            CohortYear = r.IsDBNull(r.GetOrdinal("CohortYear")) ? null : r.GetInt32(r.GetOrdinal("CohortYear")),
            ExpiresAtUtc = r.IsDBNull(r.GetOrdinal("ExpiresAtUtc")) ? null : r.GetDateTime(r.GetOrdinal("ExpiresAtUtc")),
            CreatedAtUtc = r.GetDateTime(r.GetOrdinal("CreatedAtUtc"))
        };


    }
}
