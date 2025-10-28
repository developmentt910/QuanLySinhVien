using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Infrastructure.Data;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{
    public sealed class RosterReader : IRosterReader
    {
        private readonly SqlConnectionFactory _db;
        public RosterReader(SqlConnectionFactory db) => _db = db;

        //Tìm theo ID 
        public async Task<Roster?> FindByIdAsync(Guid id, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = "SELECT TOP 1 * FROM dbo.Roster WHERE Id = @id";
            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, CommandType.Text, timeoutSeconds: default, ct: ct,
                ps: new[] { SqlHelpers.P("@id", id, SqlDbType.UniqueIdentifier) });


            if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
            return null;
        }

        // Tìm theo mã sinh viên
        public async Task<Roster?> FindByStudentCodeAsync(string studentCode, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = "SELECT TOP 1 * FROM dbo.Roster WHERE StudentCode = @s";
            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, CommandType.Text, timeoutSeconds: default, ct: ct,
                ps: new[] { SqlHelpers.P("@s", studentCode, SqlDbType.NVarChar, 32) });


            if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
            return null;
        }

        //  Tìm theo email trường 
        public async Task<Roster?> FindBySchoolEmailAsync(string emailSchool, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = "SELECT TOP 1 * FROM dbo.Roster WHERE EmailSchool = @e";
            await using var r = await SqlHelpers.ExecReaderAsync(
                conn, tx: null, sql, CommandType.Text, timeoutSeconds: default, ct: ct,
                ps: new[] { SqlHelpers.P("@e", emailSchool, SqlDbType.NVarChar, 256) });


            if (await r.ReadAsync(ct).ConfigureAwait(false)) return Map(r);
            return null;
        }

        //Đếm số sinh viên còn hiệu lực
        public async Task<int> CountActiveAsync(DateTime utcNow, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT COUNT(*) 
                                 FROM dbo.Roster 
                                 WHERE (ExpiresAtUtc IS NULL OR ExpiresAtUtc > @now)";
            var scalar = await SqlHelpers.ExecScalarAsync(conn, null, sql, ct: ct,
                ps: new[] { SqlHelpers.P("@now", utcNow, SqlDbType.DateTime2) });

            return Convert.ToInt32(scalar);
        }

        // Kiểm tra sinh viên còn hiệu lực hay không
        public async Task<bool> IsActiveAsync(Guid id, DateTime utcNow, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT 1 
                                 FROM dbo.Roster 
                                 WHERE Id = @id 
                                   AND (ExpiresAtUtc IS NULL OR ExpiresAtUtc > @now)";
            var scalar = await SqlHelpers.ExecScalarAsync(conn, null, sql, ct: ct,
                ps: new[] { SqlHelpers.P("@id", id, SqlDbType.UniqueIdentifier),
                            SqlHelpers.P("@now", utcNow, SqlDbType.DateTime2) });

            return scalar is not null;
        }

        // Tìm kiếm theo keyword (mã hoặc email)
        public async Task<IReadOnlyList<Roster>> SearchAsync(string? keyword, int skip, int take, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"SELECT Id, StudentCode, EmailSchool, FullName, IsUsed, ExpiresAtUtc, CreatedAtUtc
                                 FROM dbo.Roster
                                 WHERE (@kw IS NULL 
                                     OR StudentCode LIKE '%' + @kw + '%' 
                                     OR EmailSchool LIKE '%' + @kw + '%')
                                 ORDER BY CreatedAtUtc DESC
                                 OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";

            await using var r = await SqlHelpers.ExecReaderAsync(
                            conn,
                            tx: null,
                            sql,
                            CommandType.Text,
                            timeoutSeconds: default,
                            ct: ct,
                            ps: new[] {
                                SqlHelpers.P("@kw", (object?)keyword ?? DBNull.Value, SqlDbType.NVarChar, 256),
                                SqlHelpers.P("@skip", skip, SqlDbType.Int),
                                SqlHelpers.P("@take", take, SqlDbType.Int)
                            });


            var list = new List<Roster>();
            while (await r.ReadAsync(ct).ConfigureAwait(false))
                list.Add(Map(r));

            return list;
        }

        // Map từ SqlDataReader sang Entity
        private static Roster Map(SqlDataReader r) => new()
        {
            Id = r.GetGuid("Id"),
            StudentCode = r["StudentCode"] as string ?? "",
            EmailSchool = r["EmailSchool"] as string ?? "",
            FullName = r["FullName"] as string ?? "",
            IsUsed = r.GetBoolean("IsUsed"),
            ClassId = r.GetInt32("ClassId"),
            MajorId = r.GetInt32("MajorId"),
            SpecializationId = r.GetInt32("SpecializationId"),
            CohortYear = r.IsDBNull("CohortYear") ? null : r.GetInt16("CohortYear"),
            ExpiresAtUtc = r.IsDBNull("ExpiresAtUtc") ? null : r.GetDateTime("ExpiresAtUtc"),
            CreatedAtUtc = r.GetDateTime("CreatedAtUtc")
        };

    }
}
