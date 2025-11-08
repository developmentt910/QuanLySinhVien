
namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth
{
    public sealed class OtpPinsWriter : IOtpPinsWriter
    {
        private readonly SqlConnectionFactory _db;

        public OtpPinsWriter(SqlConnectionFactory db)
        {
            _db = db;
        }


        // tao ban ghi otp moi (insert)
        public async Task<long> CreateAsync(
            Guid userId, 
            string purpose, 
            //byte[] codeHash, 
            //byte[] salt, 
            DateTime expiresAtUtc, 
            CancellationToken ct = default)
        {//CodeHash, Salt,AttemptCount
            // @h, @s,0

            await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
            const string sql = @"INSERT INTO dbo.OtpPins (
                                        UserId, Purpose,  ExpiresAtUtc, CreatedAtUtc)
                                OUTPUT INSERTED.Id
                                VALUES (@u, @p, @e, SYSUTCDATETIME());";
            var scalar = await SqlHelpers.ExecScalarAsync(
                conn,
                tx: null,
                sql,
                CommandType.Text,
                timeoutSeconds: default,
                ct: ct,
                SqlHelpers.P("@u", userId, SqlDbType.UniqueIdentifier),
                SqlHelpers.P("@p", purpose, SqlDbType.NVarChar, 64),
                //SqlHelpers.P("@h", codeHash, SqlDbType.VarBinary, -1),
                //SqlHelpers.P("@s", salt, SqlDbType.VarBinary, -1),
                SqlHelpers.P("@e", expiresAtUtc, SqlDbType.DateTime2)
            );

            return scalar switch
            {
                long l => l,
                int i => i,
                decimal d => (long)d,
                _ => Convert.ToInt64(scalar)
            };
        }

        // danh dau opt da su dung
        //public async Task ConsumeAsync(long id, CancellationToken ct = default)
        //{
        //    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);

        //    const string sql = @"UPDATE dbo.OtpPins
        //                 SET ConsumedAtUtc = SYSUTCDATETIME()
        //                 WHERE Id = @id AND ConsumedAtUtc IS NULL;";

        //    await SqlHelpers.ExecNonQueryAsync(
        //        conn,
        //        tx: null,
        //        sql,
        //        CommandType.Text,
        //        timeoutSeconds: default,
        //        ct: ct,
        //        SqlHelpers.P("@id", id, SqlDbType.BigInt)
        //    );
        //}


        

        // tang so lan thu khi nhap sai
        //public async Task IncrementAttemptAsync(long id, CancellationToken ct = default)
        //{
        //    await using var conn = await _db.OpenAsync(ct).ConfigureAwait(false);
        //    const string sql = @"UPDATE dbo.OtpPins SET AttemptCount = AttemptCount + 1 WHERE Id = @id";
        //    await SqlHelpers.ExecNonQueryAsync(
        //        conn,
        //        tx: null,
        //        sql,
        //        CommandType.Text,
        //        timeoutSeconds: default,
        //        ct: ct,
        //        SqlHelpers.P("@id", id, SqlDbType.BigInt)
        //    );
        //}
    }
}
