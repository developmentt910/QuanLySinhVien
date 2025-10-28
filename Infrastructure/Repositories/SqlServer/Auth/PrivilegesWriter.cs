using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{
    public sealed class PrivilegesWriter : IPrivilegesWriter
    {
        private readonly SqlConnectionFactory _db;

        public PrivilegesWriter(SqlConnectionFactory db) {
            _db = db;
        }
        public async Task MarkUsedAsync(Guid privilegeId)
        {
            await using var conn = await _db.OpenAsync().ConfigureAwait(false);
            var sql = "UPDATE dbo.MaDacQuyen SET IsUsed=1 WHERE Id=@id";
            await SqlHelpers.ExecNonQueryAsync(
                        conn,
                        tx: null,
                        sql,
                        CommandType.Text,
                        timeoutSeconds: default,
                        default,
                SqlHelpers.P("@id", privilegeId, SqlDbType.UniqueIdentifier)
            );
        }
    }
}
