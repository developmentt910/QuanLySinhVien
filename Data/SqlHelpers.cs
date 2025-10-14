using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCourseManagement.Database
{
    public static class SqlHelpers
    {

        public static async Task<int> ExecNonQueryAsync(
           SqlConnection conn,
           SqlTransaction? tx,
           string sql,
           CancellationToken ct = default,
           params SqlParameter[] ps)
        {
            await using var cmd = new SqlCommand(sql, conn, tx);
            if (ps?.Length > 0) cmd.Parameters.AddRange(ps);
            return await cmd.ExecuteNonQueryAsync(ct);
        }

        // sql injection 
        public static SqlParameter P(string name, object? value, SqlDbType type, int size = 0)
        {
            var p = new SqlParameter(name, type)
            {
                Value = value ?? DBNull.Value

            };

            if (size < 0) p.Size = size;
            return p;

        }
    }
}
