using Microsoft.Data.SqlClient;
using System.Data;
using StudentCourseManagement.Domain.Abstractions.Repositories;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.MajorRepo
{
    public sealed class MajorReader : IMajorReader
  {
        private readonly SqlConnectionFactory _db;
     public MajorReader(SqlConnectionFactory db) => _db = db;

        private const string MajorColumns = "Id, MajorName, FacultyId";

        public async Task<Domain.Entities.Major?> FindByIdAsync(Guid id, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
      string sql = $@"SELECT TOP 1 {MajorColumns}
                FROM dbo.Major
WHERE Id = @id";

            await using var r = await SqlHelpers.ExecReaderAsync(
         conn, tx: null, sql, ct: ct,
      ps: new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
         ).ConfigureAwait(false);

            if (await r.ReadAsync(ct).ConfigureAwait(false))
                return Map(r);

          return null;
        }

        public async Task<IEnumerable<Domain.Entities.Major>> GetAllAsync(CancellationToken ct = default)
      {
          await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        string sql = $@"SELECT {MajorColumns}
       FROM dbo.Major
          ORDER BY MajorName";

            await using var r = await SqlHelpers.ExecReaderAsync(
      conn, tx: null, sql, ct: ct
        ).ConfigureAwait(false);

          var list = new List<Domain.Entities.Major>();
    while (await r.ReadAsync(ct).ConfigureAwait(false))
            {
     list.Add(Map(r));
  }
         return list;
        }

    public async Task<IEnumerable<Domain.Entities.Major>> GetByFacultyIdAsync(Guid facultyId, CancellationToken ct = default)
      {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
      string sql = $@"SELECT {MajorColumns}
  FROM dbo.Major
        WHERE FacultyId = @facultyId
              ORDER BY MajorName";

            await using var r = await SqlHelpers.ExecReaderAsync(
      conn, tx: null, sql, ct: ct,
   ps: new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = facultyId }
  ).ConfigureAwait(false);

   var list = new List<Domain.Entities.Major>();
            while (await r.ReadAsync(ct).ConfigureAwait(false))
            {
     list.Add(Map(r));
   }
  return list;
      }

        public async Task<bool> MajorNameExistsAsync(string majorName, Guid facultyId, CancellationToken ct = default)
        {
     await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
      const string sql = @"SELECT TOP 1 1 FROM dbo.Major 
 WHERE MajorName = @name AND FacultyId = @facultyId";

  var v = await SqlHelpers.ExecScalarAsync(
              conn, tx: null, sql, ct: ct,
     ps: new[]
      {
 new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = (object?)majorName ?? DBNull.Value },
               new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = facultyId }
   }
       ).ConfigureAwait(false);

            return v is not null;
  }

   public async Task<bool> MajorNameExistsExcludingIdAsync(string majorName, Guid facultyId, Guid excludeId, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 FROM dbo.Major 
    WHERE MajorName = @name AND FacultyId = @facultyId AND Id != @id";

       var v = await SqlHelpers.ExecScalarAsync(
  conn, tx: null, sql, ct: ct,
 ps: new[]
             {
     new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = (object?)majorName ?? DBNull.Value },
           new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = facultyId },
   new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = excludeId }
                }
        ).ConfigureAwait(false);

  return v is not null;
        }

      private static Domain.Entities.Major Map(SqlDataReader r) => new()
        {
   Id = r.GetGuid(r.GetOrdinal("Id")),
          MajorName = r.GetString(r.GetOrdinal("MajorName")),
   FacultyId = r.GetGuid(r.GetOrdinal("FacultyId"))
 };
    }
}
