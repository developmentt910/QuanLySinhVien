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
    public sealed class FacultyReader : IFacultyReader
    {
        private readonly SqlConnectionFactory _db;

        public FacultyReader(SqlConnectionFactory db) => _db = db;

        private const string FacultyColumns = @"Id, FacultyName";

        public async Task<Faculty?> FindByIdAsync(Guid id, CancellationToken ct = default)
     {
       await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
      string sql = $@"SELECT TOP 1 {FacultyColumns}
       FROM dbo.Faculty
WHERE Id = @id";

   await using var reader = await SqlHelpers.ExecReaderAsync(
 conn, tx: null, sql, ct: ct,
ps: new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
      ).ConfigureAwait(false);

            if (await reader.ReadAsync(ct).ConfigureAwait(false))
    return Map(reader);

            return null;
  }

 public async Task<IEnumerable<Faculty>> GetAllAsync(CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        string sql = $@"SELECT {FacultyColumns}
                FROM dbo.Faculty
 ORDER BY FacultyName";

       await using var reader = await SqlHelpers.ExecReaderAsync(
          conn, tx: null, sql, ct: ct
            ).ConfigureAwait(false);

            var faculties = new List<Faculty>();
         while (await reader.ReadAsync(ct).ConfigureAwait(false))
   {
       faculties.Add(Map(reader));
          }

   return faculties;
     }

    public async Task<bool> FacultyNameExistsAsync(string facultyName, CancellationToken ct = default)
        {
   if (string.IsNullOrWhiteSpace(facultyName))
          return false;

         await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT TOP 1 1 
     FROM dbo.Faculty 
        WHERE FacultyName = @name";

            var result = await SqlHelpers.ExecScalarAsync(
        conn, null, sql, CommandType.Text, default, ct,
   new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = facultyName }
      ).ConfigureAwait(false);

    return result is not null;
    }

        public async Task<bool> FacultyNameExistsExcludingIdAsync(string facultyName, Guid excludeId, CancellationToken ct = default)
        {
 if (string.IsNullOrWhiteSpace(facultyName))
     return false;

      await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
 const string sql = @"SELECT TOP 1 1 
                FROM dbo.Faculty 
  WHERE FacultyName = @name AND Id <> @excludeId";

    var result = await SqlHelpers.ExecScalarAsync(
    conn, null, sql, CommandType.Text, default, ct,
    new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = facultyName },
                new SqlParameter("@excludeId", SqlDbType.UniqueIdentifier) { Value = excludeId }
            ).ConfigureAwait(false);

            return result is not null;
 }

        private static Faculty Map(SqlDataReader rs) => new()
        {
            Id = rs.GetGuid(rs.GetOrdinal("Id")),
     FacultyName = rs.GetString(rs.GetOrdinal("FacultyName"))
        };
    }
}
