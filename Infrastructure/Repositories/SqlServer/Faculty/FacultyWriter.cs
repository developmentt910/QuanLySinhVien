namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Faculty
{
    public sealed class FacultyWriter : IFacultyWriter
    {
        private readonly SqlConnectionFactory _db;
        public FacultyWriter(SqlConnectionFactory db) => _db = db;

        public async Task<Guid> CreateAsync(Domain.Entities.Faculty faculty, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            const string sql = @"
                INSERT INTO dbo.Faculty (Id, FacultyName)
                OUTPUT inserted.Id
                VALUES (@Id, @FacultyName);";

            var id = faculty.Id != Guid.Empty ? faculty.Id : Guid.NewGuid();
            
            var scalar = await SqlHelpers.ExecScalarAsync(
                conn,
                tx: null,
                sql,
                CommandType.Text,
                timeoutSeconds: default,
                ct: ct,
                SqlHelpers.P("@Id", id, SqlDbType.UniqueIdentifier),
                SqlHelpers.P("@FacultyName", faculty.FacultyName, SqlDbType.NVarChar, 100)
            ).ConfigureAwait(false);

            if (scalar is Guid g) return g;
            return id;
        }

        public async Task UpdateAsync(Domain.Entities.Faculty faculty, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            const string sql = @"
                UPDATE dbo.Faculty
                SET FacultyName = @FacultyName
                WHERE Id = @Id";

            await SqlHelpers.ExecNonQueryAsync(
                conn,
                tx: null,
                sql,
                CommandType.Text,
                timeoutSeconds: default,
                ct: ct,
                SqlHelpers.P("@Id", faculty.Id, SqlDbType.UniqueIdentifier),
                SqlHelpers.P("@FacultyName", faculty.FacultyName, SqlDbType.NVarChar, 100)
            ).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            const string sql = @"DELETE FROM dbo.Faculty WHERE Id = @Id";

            await SqlHelpers.ExecNonQueryAsync(
                conn,
                tx: null,
                sql,
                CommandType.Text,
                timeoutSeconds: default,
                ct: ct,
                SqlHelpers.P("@Id", id, SqlDbType.UniqueIdentifier)
            ).ConfigureAwait(false);
        }
    }
}
