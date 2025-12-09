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
    public sealed class FacultyWriter : IFacultyWriter
    {
  private readonly SqlConnectionFactory _db;

  public FacultyWriter(SqlConnectionFactory db) => _db = db;

        public async Task<Guid> CreateAsync(Faculty faculty, CancellationToken ct = default)
        {
   await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
 await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

    try
   {
     const string sql = @"
      INSERT INTO dbo.Faculty 
    (Id, FacultyName)
        VALUES 
      (@id, @name)";

     await SqlHelpers.ExecNonQueryAsync(
      conn, tx, sql, CommandType.Text, default, ct,
  new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = faculty.Id },
     new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = faculty.FacultyName }
        ).ConfigureAwait(false);

    await tx.CommitAsync(ct).ConfigureAwait(false);
   return faculty.Id;
       }
  catch
      {
       await tx.RollbackAsync(ct).ConfigureAwait(false);
       throw;
     }
        }

  public async Task UpdateAsync(Faculty faculty, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
      await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

  try
       {
     const string sql = @"
         UPDATE dbo.Faculty 
         SET 
  FacultyName = @name
      WHERE Id = @id";

   await SqlHelpers.ExecNonQueryAsync(
    conn, tx, sql, CommandType.Text, default, ct,
    new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = faculty.Id },
        new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = faculty.FacultyName }
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
    const string sql = @"DELETE FROM dbo.Faculty WHERE Id = @id";

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
