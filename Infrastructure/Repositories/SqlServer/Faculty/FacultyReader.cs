using Microsoft.Data.SqlClient;
using System.Data;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Faculty
{
    public sealed class FacultyReader : IFacultyReader
    {
        private readonly SqlConnectionFactory _db;
        public FacultyReader(SqlConnectionFactory db) => _db = db;

        private const string FacultyColumns = "Id, FacultyName";

        public async Task<Domain.Entities.Faculty?> FindByIdAsync(Guid id, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT TOP 1 {FacultyColumns}
                            FROM dbo.Faculty
                            WHERE Id = @id";

            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
            ).ConfigureAwait(false);

            if (await r.ReadAsync(ct).ConfigureAwait(false)) 
                return Map(r);
            
            return null;
        }

        public async Task<IEnumerable<Domain.Entities.Faculty>> GetAllAsync(CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT {FacultyColumns}
                            FROM dbo.Faculty
                            ORDER BY FacultyName";

            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, ct: ct
            ).ConfigureAwait(false);

            var list = new List<Domain.Entities.Faculty>();
            while (await r.ReadAsync(ct).ConfigureAwait(false))
            {
                list.Add(Map(r));
            }
            return list;
        }

        public async Task<bool> FacultyNameExistsAsync(string facultyName, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 FROM dbo.Faculty WHERE FacultyName = @name";

            var v = await SqlHelpers.ExecScalarAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@name", SqlDbType.NVarChar, 100)
                { Value = (object?)facultyName ?? DBNull.Value }
            ).ConfigureAwait(false);

            return v is not null;
        }

        public async Task<bool> FacultyNameExistsExcludingIdAsync(string facultyName, Guid excludeId, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 FROM dbo.Faculty WHERE FacultyName = @name AND Id != @id";

            var v = await SqlHelpers.ExecScalarAsync(
                conn, tx: null, sql, ct: ct,
                ps: new[]
                {
                    new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = (object?)facultyName ?? DBNull.Value },
                    new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = excludeId }
                }
            ).ConfigureAwait(false);

            return v is not null;
        }

        private static Domain.Entities.Faculty Map(SqlDataReader r) => new()
        {
            Id = r.GetGuid(r.GetOrdinal("Id")),
            FacultyName = r.GetString(r.GetOrdinal("FacultyName"))
        };
    }
}
