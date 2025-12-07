using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.Devices;
using StudentCourseManagement.Applications.Class;
using StudentCourseManagement.Applications.Curriculum;
using StudentCourseManagement.Applications.Schedule;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Abstractions.Services;
using StudentCourseManagement.Infrastructure.Data;
using StudentCourseManagement.Infrastructure.Repositories.Academic;
using System;

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

        //THÊM MỚI CHO SCHEDULE 
        public static IScheduleRepository CreateScheduleRepository() => new ScheduleRepository(Db);
        public static IScheduleService CreateScheduleService() => new ScheduleService(CreateScheduleRepository());

        //THÊM MỚI CHO EXAM
        public static IExamScheduleRepository CreateExamScheduleRepository() => new ExamScheduleRepository(Db);
        public static IExamScheduleService CreateExamScheduleService() => new ExamScheduleService(CreateExamScheduleRepository());

        //THÊM MỚI CHO CURRICULUM
        public static ICurriculumRepository CreateCurriculumRepository() => new CurriculumRepository(Db);
        public static ICurriculumService CreateCurriculumService() => new CurriculumService(CreateCurriculumRepository());

        //THÊM MỚI CHO CLASS
        public static IClassRepository CreateClassRepository() => new ClassRepository(Db);
        public static IClassService CreateClassService() => new ClassService(CreateClassRepository());
    }
}