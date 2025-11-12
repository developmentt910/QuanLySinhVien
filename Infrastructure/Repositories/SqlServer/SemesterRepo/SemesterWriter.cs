using Microsoft.Data.SqlClient;
using System.Data;
using StudentCourseManagement.Domain.Abstractions.Repositories;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.SemesterRepo
{
    public sealed class SemesterWriter : ISemesterWriter
    {
        private readonly SqlConnectionFactory _db;
        public SemesterWriter(SqlConnectionFactory db) => _db = db;

        public async Task<Guid> CreateAsync(Domain.Entities.Semester semester, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"
INSERT INTO dbo.Semester (Id, SemesterName, Year, SemesterNumber, StartDate, EndDate, IsActive, MajorId)
VALUES (@id, @name, @year, @semesterNumber, @startDate, @endDate, @isActive, @majorId)";

            await SqlHelpers.ExecNonQueryAsync(
                conn, tx: null, sql, ct: ct,
                ps: new[]
                {
                    new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = semester.Id },
                    new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = semester.SemesterName },
                    new SqlParameter("@year", SqlDbType.Int) { Value = semester.Year },
                    new SqlParameter("@semesterNumber", SqlDbType.Int) { Value = semester.SemesterNumber },
                    new SqlParameter("@startDate", SqlDbType.DateTime) { Value = semester.StartDate },
                    new SqlParameter("@endDate", SqlDbType.DateTime) { Value = semester.EndDate },
                    new SqlParameter("@isActive", SqlDbType.Bit) { Value = semester.IsActive },
                    new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = semester.MajorId }
                }
            ).ConfigureAwait(false);

            return semester.Id;
        }

        public async Task UpdateAsync(Domain.Entities.Semester semester, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"
       UPDATE dbo.Semester
 SET SemesterName = @name,
   Year = @year,
          SemesterNumber = @semesterNumber,
   StartDate = @startDate,
   EndDate = @endDate,
    IsActive = @isActive,
     MajorId = @majorId
     WHERE Id = @id";

            await SqlHelpers.ExecNonQueryAsync(
                conn, tx: null, sql, ct: ct,
                ps: new[]
                {
                    new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = semester.Id },
                    new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = semester.SemesterName },
                    new SqlParameter("@year", SqlDbType.Int) { Value = semester.Year },
                    new SqlParameter("@semesterNumber", SqlDbType.Int) { Value = semester.SemesterNumber },
                    new SqlParameter("@startDate", SqlDbType.DateTime) { Value = semester.StartDate },
                    new SqlParameter("@endDate", SqlDbType.DateTime) { Value = semester.EndDate },
                    new SqlParameter("@isActive", SqlDbType.Bit) { Value = semester.IsActive },
                    new SqlParameter("@majorId", SqlDbType.UniqueIdentifier) { Value = semester.MajorId }
                }
            ).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"DELETE FROM dbo.Semester WHERE Id = @id";

            await SqlHelpers.ExecNonQueryAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
            ).ConfigureAwait(false);
        }
    }
}
