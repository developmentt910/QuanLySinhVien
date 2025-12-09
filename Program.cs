
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;
using StudentCourseManagement.Presentation.Forms.Auth; 
﻿using Microsoft.Extensions.Configuration;
using StudentCourseManagement.Presentation.Forms.Student;
using System;
using System.Windows.Forms;

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
            Application.Run(new FrmLogin());
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmRegister());
            Application.Run(new FrmStudentManagement());






        }
    }
}