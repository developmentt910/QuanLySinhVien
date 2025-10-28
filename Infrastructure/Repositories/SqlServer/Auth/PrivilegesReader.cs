using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{
    public sealed class PrivilegesReader : IPrivilegesReader
    {
        private readonly SqlConnectionFactory _db;

        public PrivilegesReader(SqlConnectionFactory db) 
        {
            _db = db;
        }
        public async Task<(Guid Id, byte[] CodeHash, byte[] salt, DateTime? ExpiresAtUtc, bool IsUsed)?> GetLastestAsync()
        {
            await using var conn = await _db.OpenAsync().ConfigureAwait(false);
            const string sql = @"select top 1 Id, CodeHash, Salt, ExpiresAtUtc, CreatedAtUtc
                                 from dbo.MaDacQuyen
                                 order by CreatedAtUtc desc";

            await using var r = await SqlHelpers.ExecReaderAsync(
                    conn,
                    tx: null,
                    sql,
                    CommandType.Text,
                    timeoutSeconds: default
                    );
            if (await r.ReadAsync().ConfigureAwait(false))
            {
                var id = r.GetGuid(r.GetOrdinal("Id"));
                var hash = (byte[])r["CodeHash"];               
                var salt = (byte[])r["Salt"];                   
                DateTime? exp = r.IsDBNull(r.GetOrdinal("ExpiresAtUtc"))
                                ? null
                                : r.GetDateTime(r.GetOrdinal("ExpiresAtUtc"));
                var isUsed = !r.IsDBNull(r.GetOrdinal("IsUsed")) && r.GetBoolean(r.GetOrdinal("IsUsed")); // bit 0/1

                return (id, hash, salt, exp, isUsed);
            }

            return null;
        }
    }
}
