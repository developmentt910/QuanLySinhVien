

namespace StudentCourseManagement.Infrastructure.Data
{
    public static class SqlHelpers
    {
        // check dam bao mo connection
        private static void EnsureOpen(SqlConnection conn)
        {
            if (conn == null)
            {
                throw new ArgumentNullException(nameof(conn));
            }

            if (conn.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("mo sql trc khi goi SqlHelper");

            }
        }

        // thuc thi cau lenh non-quey : insert/update/delete
        public static async Task<int> ExecNonQueryAsync(
           SqlConnection conn,
           SqlTransaction? tx,
           string sql,
           CommandType commandType = CommandType.Text,
           int timeoutSeconds = default,
           CancellationToken ct = default,
           params SqlParameter[] ps)
        {
            EnsureOpen(conn);

            await using var cmd = new SqlCommand(sql, conn, tx)
            {
                CommandType = commandType
            };

            if (timeoutSeconds != default)
                cmd.CommandTimeout = timeoutSeconds;

            if (ps?.Length > 0)
                foreach (var p in ps)
                    if (p.Value is null)
                        p.Value = DBNull.Value;
            cmd.Parameters.AddRange(ps);

            return await cmd.ExecuteNonQueryAsync(ct);
        }

        //truy van tra ve 1 gia tri
        public static async Task<object?> ExecScalarAsync(
            SqlConnection conn,
            SqlTransaction? tx,           
            string sql,
            CommandType commandType = CommandType.Text,
            int timeoutSeconds = default,
            CancellationToken ct = default,
            params SqlParameter[] ps
            )
        {
            await using var cmd = new SqlCommand(sql, conn, tx)
            {
                CommandType = commandType
            };

            if (timeoutSeconds != default)
            {
                cmd.CommandTimeout = timeoutSeconds;
            }
            if (ps?.Length > 0) 
                foreach(var p in ps)
                    if (p.Value is null) 
                        p.Value= DBNull.Value;               
                cmd.Parameters.AddRange(ps);
            return await cmd.ExecuteScalarAsync(ct);

        }


        // truy van tra ve nhieu dong: select
        public static async Task<SqlDataReader> ExecReaderAsync(
            SqlConnection conn,
            SqlTransaction? tx,
            string sql,
            CommandType commandType = CommandType.Text,
            int timeoutSeconds = default,
            CancellationToken ct = default,
            params SqlParameter[] ps
            )
        {
            var cmd = new SqlCommand(sql, conn, tx)
            {
                CommandType = commandType
            };

            if (timeoutSeconds != default)
            {
                cmd.CommandTimeout = timeoutSeconds;
            }

            if (ps?.Length > 0) cmd.Parameters.AddRange(ps);
            return await cmd.ExecuteReaderAsync(ct);


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
