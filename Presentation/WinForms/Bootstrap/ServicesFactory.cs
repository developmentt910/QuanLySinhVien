

using StudentCourseManagement.Applications.Services;
using StudentCourseManagement.Infrastructure.Security;

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

        public static IRosterWriter CreateUsersWriter() => new RosterWriter(Db);
        public static IRosterReader CreateRosterReader() => new RosterReader(Db);
       
        public static AdminService CreateAdminService()
        {
            return new AdminService(CreateRosterReader(), CreateUsersWriter());
        }
        public static PasswordChangeService CreatePasswordChangeService()
        {
            return new PasswordChangeService(
                CreateRosterReader(),
                CreateUsersWriter()
            );
        }



        // External stubs
        public static ICaptchaService CreateCaptcha() => new StubCaptchaService();

        public static IForgotPasswordService CreateForgotPasswordService()
    => new ForgotPasswordService(Db);

    }
}
