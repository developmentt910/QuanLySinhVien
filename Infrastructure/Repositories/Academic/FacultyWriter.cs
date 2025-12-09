public sealed class FacultyWriter : IFacultyWriter
{
    private readonly SqlConnectionFactory _db;
    public FacultyWriter(SqlConnectionFactory db) => _db = db;

    public async Task<string> CreateAsync(Faculty faculty, CancellationToken ct = default)
    {
        faculty.Id = Guid.NewGuid();

        await using var conn = await _db.OpenAsync(ct);
        await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct);

        const string sql =
            @"INSERT INTO dbo.Faculty (Id, FacultyCode, FacultyName)
              VALUES (@id, @code, @name)";

        await SqlHelpers.ExecNonQueryAsync(
            conn, tx, sql, CommandType.Text, default, ct,
            new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = faculty.Id },
            new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = faculty.FacultyCode },
            new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = faculty.FacultyName }
        );

        await tx.CommitAsync(ct);
        return faculty.FacultyCode;
    }

    public async Task UpdateAsync(Faculty faculty, CancellationToken ct = default)
    {
        await using var conn = await _db.OpenAsync(ct);
        await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct);

        const string sql =
            @"UPDATE dbo.Faculty 
              SET FacultyName = @name
              WHERE FacultyCode = @code";

        await SqlHelpers.ExecNonQueryAsync(
            conn, tx, sql, CommandType.Text, default, ct,
            new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = faculty.FacultyCode },
            new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = faculty.FacultyName }
        );

        await tx.CommitAsync(ct);
    }

    public async Task DeleteAsync(string code, CancellationToken ct = default)
    {
        await using var conn = await _db.OpenAsync(ct);
        await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct);

        const string sql =
            @"DELETE FROM dbo.Faculty WHERE FacultyCode = @code";

        await SqlHelpers.ExecNonQueryAsync(
            conn, tx, sql, CommandType.Text, default, ct,
            new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = code }
        );

        await tx.CommitAsync(ct);
    }
}
