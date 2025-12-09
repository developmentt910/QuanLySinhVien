using Microsoft.Extensions.Configuration;
using StudentCourseManagement.Applications;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Infrastructure.Data;
using StudentCourseManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static IConductEvaluationRepository CreateConductEvaluationService()
       =>  new ConductEvaluationRepository(Db);


        



    }
}
