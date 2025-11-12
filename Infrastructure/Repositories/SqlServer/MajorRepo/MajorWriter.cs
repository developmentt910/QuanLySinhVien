using Microsoft.Data.SqlClient;
using System.Data;
using StudentCourseManagement.Domain.Abstractions.Repositories;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.MajorRepo
{
    public sealed class MajorWriter : IMajorWriter
    {
 private readonly SqlConnectionFactory _db;
  public MajorWriter(SqlConnectionFactory db) => _db = db;

        public async Task<Guid> CreateAsync(Domain.Entities.Major major, CancellationToken ct = default)
        {
await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
const string sql = @"
          INSERT INTO dbo.Major (Id, MajorName, FacultyId)
  VALUES (@id, @name, @facultyId)";

 await SqlHelpers.ExecNonQueryAsync(
          conn, tx: null, sql, ct: ct,
 ps: new[]
    {
       new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = major.Id },
        new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = major.MajorName },
      new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = major.FacultyId }
      }
  ).ConfigureAwait(false);

    return major.Id;
}

   public async Task UpdateAsync(Domain.Entities.Major major, CancellationToken ct = default)
        {
     await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"
   UPDATE dbo.Major
       SET MajorName = @name,
      FacultyId = @facultyId
      WHERE Id = @id";

await SqlHelpers.ExecNonQueryAsync(
  conn, tx: null, sql, ct: ct,
    ps: new[]
     {
      new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = major.Id },
new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = major.MajorName },
     new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = major.FacultyId }
            }
     ).ConfigureAwait(false);
   }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
  {
      await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
 const string sql = @"DELETE FROM dbo.Major WHERE Id = @id";

  await SqlHelpers.ExecNonQueryAsync(
       conn, tx: null, sql, ct: ct,
  ps: new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
          ).ConfigureAwait(false);
        }
   }
}
