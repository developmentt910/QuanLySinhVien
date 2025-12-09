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
    public sealed class SemesterReader : ISemesterReader
  {
        private readonly SqlConnectionFactory _db;

    public SemesterReader(SqlConnectionFactory db) => _db = db;

      private const string SemesterColumns = @"Id, SemesterCode, SemesterName, AcademicYear";

        public async Task<Semester?> FindByIdAsync(Guid id, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT TOP 1 {SemesterColumns}
   FROM dbo.Semester
             WHERE Id = @id";

 await using var reader = await SqlHelpers.ExecReaderAsync(
      conn, tx: null, sql, ct: ct,
          ps: new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
  ).ConfigureAwait(false);

            if (await reader.ReadAsync(ct).ConfigureAwait(false))
  return Map(reader);

            return null;
        }

        public async Task<IEnumerable<Semester>> GetAllAsync(CancellationToken ct = default)
        {
     await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            string sql = $@"SELECT {SemesterColumns}
    FROM dbo.Semester
         ORDER BY SemesterCode DESC";

            await using var reader = await SqlHelpers.ExecReaderAsync(
 conn, tx: null, sql, ct: ct
            ).ConfigureAwait(false);

          var semesters = new List<Semester>();
   while (await reader.ReadAsync(ct).ConfigureAwait(false))
   {
                semesters.Add(Map(reader));
    }

       return semesters;
        }

        public async Task<Semester?> FindBySemesterCodeAsync(string semesterCode, CancellationToken ct = default)
        {
          if (string.IsNullOrWhiteSpace(semesterCode))
           return null;

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
       string sql = $@"SELECT TOP 1 {SemesterColumns}
    FROM dbo.Semester
             WHERE SemesterCode = @code";

        await using var reader = await SqlHelpers.ExecReaderAsync(
        conn, tx: null, sql, ct: ct,
      ps: new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = semesterCode }
            ).ConfigureAwait(false);

            if (await reader.ReadAsync(ct).ConfigureAwait(false))
         return Map(reader);

    return null;
        }

        public async Task<bool> SemesterCodeExistsAsync(string semesterCode, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(semesterCode))
                return false;

 await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
          const string sql = @"SELECT TOP 1 1 
          FROM dbo.Semester 
        WHERE SemesterCode = @code";

       var result = await SqlHelpers.ExecScalarAsync(
     conn, null, sql, CommandType.Text, default, ct,
      new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = semesterCode }
        ).ConfigureAwait(false);

       return result is not null;
      }

        public async Task<bool> SemesterCodeExistsExcludingIdAsync(string semesterCode, Guid excludeId, CancellationToken ct = default)
    {
          if (string.IsNullOrWhiteSpace(semesterCode))
     return false;

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
 const string sql = @"SELECT TOP 1 1 
     FROM dbo.Semester 
   WHERE SemesterCode = @code AND Id <> @excludeId";

            var result = await SqlHelpers.ExecScalarAsync(
                conn, null, sql, CommandType.Text, default, ct,
              new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = semesterCode },
        new SqlParameter("@excludeId", SqlDbType.UniqueIdentifier) { Value = excludeId }
       ).ConfigureAwait(false);

            return result is not null;
        }

        private static Semester Map(SqlDataReader rs) => new()
        {
        Id = rs.GetGuid(rs.GetOrdinal("Id")),
            SemesterCode = rs.GetString(rs.GetOrdinal("SemesterCode")),
          SemesterName = rs.GetString(rs.GetOrdinal("SemesterName")),
            AcademicYear = rs.GetString(rs.GetOrdinal("AcademicYear"))
        };
    }
}
