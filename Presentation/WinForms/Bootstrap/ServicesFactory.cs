using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.Devices;
using StudentCourseManagement.Applications.Class;
using StudentCourseManagement.Applications.Curriculum;
using StudentCourseManagement.Applications.Schedule;
using StudentCourseManagement.Applications.SemesterApp;
using StudentCourseManagement.Applications.MajorApp;
using StudentCourseManagement.Applications.Faculty;
using StudentCourseManagement.Applications.SpecializationApp;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Abstractions.Services;
using StudentCourseManagement.Infrastructure.Data;
using StudentCourseManagement.Infrastructure.Repositories.Academic;
using System;

using StudentCourseManagement.Applications.Services;
using StudentCourseManagement.Infrastructure.Security;
using StudentCourseManagement.Infrastructure.Repositories.AuthAdmin;

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

        public static ISemesterReader CreateSemesterReader() => new SemesterReader(Db);
        public static ISemesterWriter CreateSemesterWriter() => new SemesterWriter(Db);
      public static SemesterService CreateSemesterService() => new SemesterService(
            CreateSemesterReader(),
        CreateSemesterWriter()
     );

  public static IMajorReader CreateMajorReader() => new MajorReader(Db);
        public static IMajorWriter CreateMajorWriter() => new MajorWriter(Db);
        public static MajorService CreateMajorService() => new MajorService(
        CreateMajorReader(),
        CreateMajorWriter(),
         CreateFacultyReader()
        );

   public static IFacultyReader CreateFacultyReader() => new FacultyReader(Db);
        public static IFacultyWriter CreateFacultyWriter() => new FacultyWriter(Db);
    public static FacultyService CreateFacultyService() => new FacultyService(
   CreateFacultyReader(),
            CreateFacultyWriter()
        );

    public static ISpecializationReader CreateSpecializationReader() => new SpecializationReader(Db);
        public static ISpecializationWriter CreateSpecializationWriter() => new SpecializationWriter(Db);
      public static SpecializationService CreateSpecializationService() => new SpecializationService(
CreateSpecializationReader(),
     CreateSpecializationWriter(),
 CreateMajorReader()
        );

        public static IConductEvaluationRepository CreateConductEvaluationService()
      => new ConductEvaluationRepository(Db);

    }


}