namespace StudentCourseManagement.Infrastructure.Data
{
    public class SqlConnectionFactory
    {
        private readonly string _connectionString;
        public SqlConnectionFactory(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Missing ConnectionStrings:DefaultConnection in appsettings.json");
        }


        // create connection 
        public SqlConnection Create()
            => new SqlConnection(_connectionString);

        // open connection
        public async Task<SqlConnection> OpenAsync(CancellationToken ct = default)
        {
            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(ct);
            return conn;
        }
    }
}
