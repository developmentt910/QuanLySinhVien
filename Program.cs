using StudentCourseManagement.Presentation.WinForms.Bootstrap;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;
using StudentCourseManagement.Presentation.Forms.Auth; // Thêm using này

namespace StudentCourseManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            ServicesFactory.UseConfiguration(config);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmRegister());
        }
    }
}