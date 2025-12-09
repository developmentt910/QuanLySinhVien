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

        private const string FacultyColumns = @"Id, FacultyCode, FacultyName";

        private static Faculty Map(SqlDataReader rs) => new()
        {
            Id = rs.GetGuid(rs.GetOrdinal("Id")),
            FacultyCode = rs.GetString(rs.GetOrdinal("FacultyCode")),
            FacultyName = rs.GetString(rs.GetOrdinal("FacultyName"))
        };


        // ==================================
        //  FIND BY CODE (thay vì FIND BY ID)
        // ==================================
        public async Task<Faculty?> FindByCodeAsync(string code, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            string sql = $@"SELECT TOP 1 {FacultyColumns}
                            FROM dbo.Faculty
                            WHERE FacultyCode = @code";

            await using var reader = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, ct: ct,
                ps: new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = code }
            ).ConfigureAwait(false);

            if (await reader.ReadAsync(ct).ConfigureAwait(false))
                return Map(reader);

            return null;
        }

        // ==================================
        //  GET ALL
        // ==================================
        public async Task<IEnumerable<Faculty>> GetAllAsync(CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            string sql = $@"SELECT {FacultyColumns}
                            FROM dbo.Faculty
                            ORDER BY FacultyCode";

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

        // ==================================
        //  CHECK NAME EXISTS
        // ==================================
        public async Task<bool> FacultyNameExistsAsync(string name, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            const string sql = @"SELECT TOP 1 1 
                                 FROM dbo.Faculty 
                                 WHERE FacultyName = @name";

            var result = await SqlHelpers.ExecScalarAsync(
                conn, null, sql, CommandType.Text, default, ct,
                new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = name }
            ).ConfigureAwait(false);

            return result is not null;
        }

        // ==================================
        //  CHECK NAME EXISTS (EXCLUDING CODE)
        // ==================================
        public async Task<bool> FacultyNameExistsExcludingCodeAsync(string name, string code, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

            const string sql = @"SELECT TOP 1 1 
                                 FROM dbo.Faculty 
                                 WHERE FacultyName = @name AND FacultyCode <> @code";

            var result = await SqlHelpers.ExecScalarAsync(
                conn, null, sql, CommandType.Text, default, ct,
                new SqlParameter("@name", SqlDbType.NVarChar, 255) { Value = name },
                new SqlParameter("@code", SqlDbType.NVarChar, 50) { Value = code }
            ).ConfigureAwait(false);

            return result is not null;
        }

        
    }
}
