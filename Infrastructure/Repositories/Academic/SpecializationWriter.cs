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
  public sealed class SpecializationWriter : ISpecializationWriter
  {
        private readonly SqlConnectionFactory _db;

        public SpecializationWriter(SqlConnectionFactory db) => _db = db;

    public async Task<Guid> CreateAsync(Specialization specialization, CancellationToken ct = default)
   {
 await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
  await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

try
      {
   const string sql = @"
       INSERT INTO dbo.Specialization 
     (Id, SpecializationName, MajorId)
   VALUES 
  (@id, @name, @majorId)";

   await SqlHelpers.ExecNonQueryAsync(
       conn, tx, sql, CommandType.Text, default, ct,
 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = specialization.Id },
     new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = specialization.SpecializationName },
    new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = specialization.MajorId }
      ).ConfigureAwait(false);

            await tx.CommitAsync(ct).ConfigureAwait(false);
            return specialization.Id;
        }
            catch
      {
        await tx.RollbackAsync(ct).ConfigureAwait(false);
    throw;
  }
    }

        public async Task UpdateAsync(Specialization specialization, CancellationToken ct = default)
        {
await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            await using var tx = (SqlTransaction)await conn.BeginTransactionAsync(ct).ConfigureAwait(false);

try
{
        const string sql = @"
UPDATE dbo.Specialization 
            SET 
      SpecializationName = @name,
    MajorId = @majorId
    WHERE Id = @id";

 await SqlHelpers.ExecNonQueryAsync(
        conn, tx, sql, CommandType.Text, default, ct,
     new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = specialization.Id },
  new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = specialization.SpecializationName },
     new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = specialization.MajorId }
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
          const string sql = @"DELETE FROM dbo.Specialization WHERE Id = @id";

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
