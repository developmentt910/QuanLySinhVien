using Microsoft.Extensions.Configuration; // để dùng ConfigurationBuilder
using StudentCourseManagement.Presentation.Forms.result;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;
using System;
using System.Windows.Forms;

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

            // Khởi tạo WinForms
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            //System.Windows.Forms.Application.Run(new FrmConductEvaluation());

            System.Windows.Forms.Application.Run(new FrmConductEvaluation());

        }
    }
}
