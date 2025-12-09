using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Infrastructure.Data;

namespace StudentCourseManagement.Infrastructure.Repositories.Academic
{
    public sealed class SpecializationReader : ISpecializationReader
    {
        private readonly SqlConnectionFactory _db;

        public SpecializationReader(SqlConnectionFactory db) => _db = db;

     private const string SpecColumns = @"Id, SpecializationName, MajorId";

     public async Task<Specialization?> FindByIdAsync(Guid id, CancellationToken ct = default)
        {
   await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
  string sql = $@"SELECT TOP 1 {SpecColumns}
         FROM dbo.Specialization
        WHERE Id = @id";

          await using var reader = await SqlHelpers.ExecReaderAsync(
     conn, tx: null, sql, ct: ct,
      ps: new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
            ).ConfigureAwait(false);

      if (await reader.ReadAsync(ct).ConfigureAwait(false))
                return Map(reader);

         return null;
        }

        public async Task<IEnumerable<Specialization>> GetAllAsync(CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT {SpecColumns}
 FROM dbo.Specialization
              ORDER BY SpecializationName";

          await using var reader = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, ct: ct
            ).ConfigureAwait(false);

   var specs = new List<Specialization>();
  while (await reader.ReadAsync(ct).ConfigureAwait(false))
     {
     specs.Add(Map(reader));
     }

            return specs;
        }

   public async Task<IEnumerable<Specialization>> GetByMajorIdAsync(Guid majorId, CancellationToken ct = default)
      {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
      string sql = $@"SELECT {SpecColumns}
       FROM dbo.Specialization
                WHERE MajorId = @majorId
      ORDER BY SpecializationName";

            await using var reader = await SqlHelpers.ExecReaderAsync(
           conn, tx: null, sql, ct: ct,
    ps: new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = majorId }
  ).ConfigureAwait(false);

   var specs = new List<Specialization>();
            while (await reader.ReadAsync(ct).ConfigureAwait(false))
      {
      specs.Add(Map(reader));
       }

      return specs;
        }

        public async Task<bool> SpecializationNameExistsAsync(string name, Guid majorId, CancellationToken ct = default)
 {
            if (string.IsNullOrWhiteSpace(name))
         return false;

    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 
             FROM dbo.Specialization 
   WHERE SpecializationName = @name AND MajorId = @majorId";

            var result = await SqlHelpers.ExecScalarAsync(
    conn, null, sql, CommandType.Text, default, ct,
                new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = name },
     new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = majorId }
            ).ConfigureAwait(false);

          return result is not null;
        }

        public async Task<bool> SpecializationNameExistsExcludingIdAsync(string name, Guid majorId, Guid excludeId, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(name))
   return false;

         await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
    const string sql = @"SELECT TOP 1 1 
       FROM dbo.Specialization 
          WHERE SpecializationName = @name AND MajorId = @majorId AND Id <> @excludeId";

  var result = await SqlHelpers.ExecScalarAsync(
                conn, null, sql, CommandType.Text, default, ct,
           new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = name },
      new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = majorId },
             new SqlParameter("@excludeId", SqlDbType.UniqueIdentifier) { Value = excludeId }
            ).ConfigureAwait(false);

 return result is not null;
     }

        private static Specialization Map(SqlDataReader rs) => new()
        {
          Id = rs.GetGuid(rs.GetOrdinal("Id")),
     SpecializationName = rs.GetString(rs.GetOrdinal("SpecializationName")),
            MajorId = rs.GetGuid(rs.GetOrdinal("MajorId"))
    };
    }
}
