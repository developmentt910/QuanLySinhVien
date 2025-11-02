

namespace StudentCourseManagement.Presentation.WinForms.Bootstrap
{

    public static class ServicesFactory
    {
        private static IConfiguration? _config;
        private static SqlConnectionFactory? _db;

        public static void UseConfiguration(IConfiguration config)
        {
            _config = config;
            _db = new SqlConnectionFactory(config);  
        }

        private static SqlConnectionFactory Db =>
            _db ?? throw new InvalidOperationException(
                "ServicesFactory chưa được cấu hình. Hãy gọi UseConfiguration(config) từ Program.");

        // Infrastructure: Repositories (Auth)
        public static IUsersReader CreateUsersReader() => new UsersReader(Db);
        public static IUsersWriter CreateUsersWriter() => new UsersWriter(Db);
        public static IRosterReader CreateRosterReader() => new RosterReader(Db);
        public static IOtpPinsReader CreateOtpReader() => new OtpPinsReader(Db);
        public static IOtpPinsWriter CreateOtpWriter() => new OtpPinsWriter(Db);
     
        public static ILoginThrottleStore CreateThrottleStore() => new LoginThrottleStore(Db);

        // External stubs
        public static IEmailService CreateEmail() => new EmailServiceStub();
        public static ICaptchaService CreateCaptcha() => new StubCaptchaService();
        public static IClock CreateClock() => new SystemClock();
    }
}
