using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Infrastructure.Data;

namespace StudentCourseManagement.Infrastructure.Repositories.Academic
{
    public sealed class MajorWriter : IMajorWriter
    {
        private readonly SqlConnectionFactory _db;

        public MajorWriter(SqlConnectionFactory db) => _db = db;

        public async Task<Guid> CreateAsync(Major major, CancellationToken ct = default)
        {
      await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
 await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

       try
            {
      const string sql = @"
      INSERT INTO dbo.Major 
     (Id, MajorName, FacultyId)
       VALUES 
   (@id, @name, @facultyId)";

    await SqlHelpers.ExecNonQueryAsync(
     conn, tx, sql, CommandType.Text, default, ct,
     new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = major.Id },
      new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = major.MajorName },
    new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = major.FacultyId }
  ).ConfigureAwait(false);

            await tx.CommitAsync(ct).ConfigureAwait(false);
            return major.Id;
 }
   catch
          {
     await tx.RollbackAsync(ct).ConfigureAwait(false);
      throw;
            }
        }

        public async Task UpdateAsync(Major major, CancellationToken ct = default)
        {
       await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
      await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

   try
         {
    const string sql = @"
      UPDATE dbo.Major 
   SET 
    MajorName = @name,
       FacultyId = @facultyId
  WHERE Id = @id";

          await SqlHelpers.ExecNonQueryAsync(
conn, tx, sql, CommandType.Text, default, ct,
       new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = major.Id },
new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = major.MajorName },
       new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = major.FacultyId }
  ).ConfigureAwait(false);

     await tx.CommitAsync(ct).ConfigureAwait(false);
     }
   catch
  {
      await tx.RollbackAsync(ct).ConfigureAwait(false);
      throw;
      }
        }

 public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
       await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

      try
        {
       const string sql = @"DELETE FROM dbo.Major WHERE Id = @id";

          await SqlHelpers.ExecNonQueryAsync(
conn, tx, sql, CommandType.Text, default, ct,
     new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
).ConfigureAwait(false);

     await tx.CommitAsync(ct).ConfigureAwait(false);
  }
       catch
            {
     await tx.RollbackAsync(ct).ConfigureAwait(false);
     throw;
      }
        }
    }
}
