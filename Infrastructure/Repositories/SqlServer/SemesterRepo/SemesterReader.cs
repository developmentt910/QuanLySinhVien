using Microsoft.Data.SqlClient;
using System.Data;
using StudentCourseManagement.Domain.Abstractions.Repositories;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.SemesterRepo
{
    public sealed class SemesterReader : ISemesterReader
    {
        private readonly SqlConnectionFactory _db;
        public SemesterReader(SqlConnectionFactory db) => _db = db;

        private const string SemesterColumns = "Id, SemesterName, Year, SemesterNumber, StartDate, EndDate, IsActive, MajorId";

        public async Task<Domain.Entities.Semester?> FindByIdAsync(Guid id, CancellationToken ct = default)
   {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
         string sql = $@"SELECT TOP 1 {SemesterColumns}
    FROM dbo.Semester
   WHERE Id = @id";

await using var r = await SqlHelpers.ExecReaderAsync(
    conn, tx: null, sql, ct: ct,
    ps: new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
       ).ConfigureAwait(false);

  if (await r.ReadAsync(ct).ConfigureAwait(false))
                return Map(r);

       return null;
        }

        public async Task<IEnumerable<Domain.Entities.Semester>> GetAllAsync(CancellationToken ct = default)
        {
 await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
string sql = $@"SELECT {SemesterColumns}
        FROM dbo.Semester
  ORDER BY Year DESC, SemesterNumber";

 await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, ct: ct
).ConfigureAwait(false);

     var list = new List<Domain.Entities.Semester>();
       while (await r.ReadAsync(ct).ConfigureAwait(false))
            {
    list.Add(Map(r));
            }
    return list;
        }

        public async Task<IEnumerable<Domain.Entities.Semester>> GetByMajorIdAsync(Guid majorId, CancellationToken ct = default)
    {
    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT {SemesterColumns}
           FROM dbo.Semester
             WHERE MajorId = @majorId
       ORDER BY Year DESC, SemesterNumber";

 await using var r = await SqlHelpers.ExecReaderAsync(
           conn, tx: null, sql, ct: ct,
       ps: new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = majorId }
            ).ConfigureAwait(false);

            var list = new List<Domain.Entities.Semester>();
        while (await r.ReadAsync(ct).ConfigureAwait(false))
            {
  list.Add(Map(r));
      }
   return list;
        }

   public async Task<bool> SemesterNameExistsAsync(string semesterName, Guid majorId, CancellationToken ct = default)
        {
       await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 FROM dbo.Semester 
 WHERE SemesterName = @name AND MajorId = @majorId";

            var v = await SqlHelpers.ExecScalarAsync(
    conn, tx: null, sql, ct: ct,
              ps: new[]
      {
       new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = (object?)semesterName ?? DBNull.Value },
       new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = majorId }
                }
   ).ConfigureAwait(false);

            return v is not null;
    }

   public async Task<bool> SemesterNameExistsExcludingIdAsync(string semesterName, Guid majorId, Guid excludeId, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        const string sql = @"SELECT TOP 1 1 FROM dbo.Semester 
   WHERE SemesterName = @name AND MajorId = @majorId AND Id != @id";

        var v = await SqlHelpers.ExecScalarAsync(
 conn, tx: null, sql, ct: ct,
        ps: new[]
 {
        new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = (object?)semesterName ?? DBNull.Value },
    new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = majorId },
        new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = excludeId }
     }
            ).ConfigureAwait(false);

      return v is not null;
    }

   public async Task<IEnumerable<Domain.Entities.Semester>> GetActiveSemestersAsync(CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
  string sql = $@"SELECT {SemesterColumns}
      FROM dbo.Semester
     WHERE IsActive = 1
         ORDER BY Year DESC, SemesterNumber";

    await using var r = await SqlHelpers.ExecReaderAsync(
      conn, tx: null, sql, ct: ct
         ).ConfigureAwait(false);

var list = new List<Domain.Entities.Semester>();
            while (await r.ReadAsync(ct).ConfigureAwait(false))
        {
    list.Add(Map(r));
        }
            return list;
   }

 private static Domain.Entities.Semester Map(SqlDataReader r) => new()
        {
 Id = r.GetGuid(r.GetOrdinal("Id")),
            SemesterName = r.GetString(r.GetOrdinal("SemesterName")),
     Year = r.GetInt32(r.GetOrdinal("Year")),
          SemesterNumber = r.GetInt32(r.GetOrdinal("SemesterNumber")),
   StartDate = r.GetDateTime(r.GetOrdinal("StartDate")),
 EndDate = r.GetDateTime(r.GetOrdinal("EndDate")),
          IsActive = r.GetBoolean(r.GetOrdinal("IsActive")),
     MajorId = r.GetGuid(r.GetOrdinal("MajorId"))
        };
    }
}
