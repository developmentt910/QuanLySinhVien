using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{

    public sealed class LoginThrottleStore : ILoginThrottleStore
    {
        private readonly SqlConnectionFactory _db;

        public LoginThrottleStore(SqlConnectionFactory db)
        {
            _db = db;
        }

        // tang bo dem cua 1 scope
        // return so lan thu hien tai
        public async Task<int> IncrementAndGetAsync(string scope, byte[] keyHash, DateTime windowStartUtc, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"
                    MERGE dbo.LoginThrottle AS t
                    USING (SELECT @s AS Scope, @k AS KeyHash, @w AS WindowStartUtc) AS src
                        ON t.Scope = src.Scope AND t.KeyHash = src.KeyHash AND t.WindowStartUtc = src.WindowStartUtc
                    WHEN MATCHED THEN
                        UPDATE SET Count = Count + 1
                    WHEN NOT MATCHED THEN
                        INSERT (Scope, KeyHash, WindowStartUtc, Count)
                        VALUES (src.Scope, src.KeyHash, src.WindowStartUtc, 1)
                    OUTPUT inserted.Count;";

            var scalar = await SqlHelpers.ExecScalarAsync(
               conn,
               tx: null,
               sql,
               CommandType.Text,
               timeoutSeconds: default,
               ct: ct,
               SqlHelpers.P("@s", scope, SqlDbType.NVarChar, 64),
               SqlHelpers.P("@k", keyHash, SqlDbType.VarBinary, 32),
               SqlHelpers.P("@w", windowStartUtc, SqlDbType.DateTime2)
           );

            return Convert.ToInt32(scalar);
        }


        //reset lai bo dem cua 1 scope
        public async Task ResetScopeAsync(string scope, byte[] keyHash, CancellationToken ct = default)
        {
            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"DELETE FROM dbo.LoginThrottle WHERE Scope=@s AND KeyHash=@k";
            await SqlHelpers.ExecNonQueryAsync(conn, null, sql, CommandType.Text, timeoutSeconds: default, ct: ct,
                            SqlHelpers.P("@s",scope, SqlDbType.NVarChar, 64),
                            SqlHelpers.P("@k",keyHash, SqlDbType.VarBinary,32)

                );
        }
    }
}
