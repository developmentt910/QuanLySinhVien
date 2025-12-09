
namespace StudentCourseManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Cấu hình appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();


            ServicesFactory.UseConfiguration(config);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());

        }
    }
}