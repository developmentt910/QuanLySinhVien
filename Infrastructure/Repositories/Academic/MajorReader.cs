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
    public sealed class MajorReader : IMajorReader
    {
        private readonly SqlConnectionFactory _db;

        public MajorReader(SqlConnectionFactory db) => _db = db;

        private const string MajorColumns = @"Id, MajorName, FacultyId";

        public async Task<Major?> FindByIdAsync(Guid id, CancellationToken ct = default)
     {
       await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT TOP 1 {MajorColumns}
          FROM dbo.Major
        WHERE Id = @id";

 await using var reader = await SqlHelpers.ExecReaderAsync(
     conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
        ).ConfigureAwait(false);

            if (await reader.ReadAsync(ct).ConfigureAwait(false))
     return Map(reader);

   return null;
        }

        public async Task<IEnumerable<Major>> GetAllAsync(CancellationToken ct = default)
   {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
     string sql = $@"SELECT {MajorColumns}
     FROM dbo.Major
    ORDER BY MajorName";

         await using var reader = await SqlHelpers.ExecReaderAsync(
         conn, tx: null, sql, ct: ct
       ).ConfigureAwait(false);

     var majors = new List<Major>();
     while (await reader.ReadAsync(ct).ConfigureAwait(false))
       {
   majors.Add(Map(reader));
       }

            return majors;
   }

  public async Task<IEnumerable<Major>> GetByFacultyIdAsync(Guid facultyId, CancellationToken ct = default)
     {
     await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
     string sql = $@"SELECT {MajorColumns}
              FROM dbo.Major
          WHERE FacultyId = @facultyId
      ORDER BY MajorName";

  await using var reader = await SqlHelpers.ExecReaderAsync(
     conn, tx: null, sql, ct: ct,
       ps: new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = facultyId }
            ).ConfigureAwait(false);

            var majors = new List<Major>();
      while (await reader.ReadAsync(ct).ConfigureAwait(false))
 {
 majors.Add(Map(reader));
    }

          return majors;
   }

     public async Task<bool> MajorNameExistsAsync(string majorName, Guid facultyId, CancellationToken ct = default)
        {
       if (string.IsNullOrWhiteSpace(majorName))
    return false;

         await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
     const string sql = @"SELECT TOP 1 1 
  FROM dbo.Major 
       WHERE MajorName = @name AND FacultyId = @facultyId";

    var result = await SqlHelpers.ExecScalarAsync(
       conn, null, sql, CommandType.Text, default, ct,
       new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = majorName },
   new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = facultyId }
        ).ConfigureAwait(false);

 return result is not null;
 }

        public async Task<bool> MajorNameExistsExcludingIdAsync(string majorName, Guid facultyId, Guid excludeId, CancellationToken ct = default)
 {
            if (string.IsNullOrWhiteSpace(majorName))
       return false;

        await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
   const string sql = @"SELECT TOP 1 1 
   FROM dbo.Major 
 WHERE MajorName = @name AND FacultyId = @facultyId AND Id <> @excludeId";

  var result = await SqlHelpers.ExecScalarAsync(
 conn, null, sql, CommandType.Text, default, ct,
     new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = majorName },
    new SqlParameter("@facultyId", SqlDbType.UniqueIdentifier) { Value = facultyId },
    new SqlParameter("@excludeId", SqlDbType.UniqueIdentifier) { Value = excludeId }
   ).ConfigureAwait(false);

    return result is not null;
     }

 private static Major Map(SqlDataReader rs) => new()
        {
        Id = rs.GetGuid(rs.GetOrdinal("Id")),
MajorName = rs.GetString(rs.GetOrdinal("MajorName")),
    FacultyId = rs.GetGuid(rs.GetOrdinal("FacultyId"))
        };
  }
}
