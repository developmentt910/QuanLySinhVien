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
    public sealed class SemesterWriter : ISemesterWriter
    {
    private readonly SqlConnectionFactory _db;

        public SemesterWriter(SqlConnectionFactory db) => _db = db;

 public async Task<Guid> CreateAsync(Semester semester, CancellationToken ct = default)
        {
      await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
     await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

   try
  {
      const string sql = @"
            INSERT INTO dbo.Semester 
            (Id, SemesterCode, SemesterName, AcademicYear)
    VALUES 
       (@id, @code, @name, @academicYear)";

          await SqlHelpers.ExecNonQueryAsync(
        conn, tx, sql, CommandType.Text, default, ct,
         new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = semester.Id },
        new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = semester.SemesterCode },
new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = semester.SemesterName },
         new SqlParameter("@academicYear", SqlDbType.NVarChar, 50) { Value = semester.AcademicYear }
  ).ConfigureAwait(false);

       await tx.CommitAsync(ct).ConfigureAwait(false);
  return semester.Id;
            }
  catch
     {
     await tx.RollbackAsync(ct).ConfigureAwait(false);
     throw;
      }
   }

  public async Task UpdateAsync(Semester semester, CancellationToken ct = default)
        {
      await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
       await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

try
      {
       const string sql = @"
         UPDATE dbo.Semester 
SET 
    SemesterCode = @code,
  SemesterName = @name,
      AcademicYear = @academicYear
  WHERE Id = @id";

            await SqlHelpers.ExecNonQueryAsync(
    conn, tx, sql, CommandType.Text, default, ct,
   new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = semester.Id },
        new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = semester.SemesterCode },
     new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = semester.SemesterName },
         new SqlParameter("@academicYear", SqlDbType.NVarChar, 50) { Value = semester.AcademicYear }
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
      const string sql = @"DELETE FROM dbo.Semester WHERE Id = @id";

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
