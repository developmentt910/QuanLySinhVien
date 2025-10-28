/****** Object:  Trigger [trg_Users_UpdateTimestamp]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP TRIGGER [dbo].[trg_Users_UpdateTimestamp]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [CK_Users_Role]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [CK_Users_PhoneE164]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [CK_Users_CCCD_12Digits]
GO
ALTER TABLE [dbo].[Semesters] DROP CONSTRAINT [CK_Sem_DateRange]
GO
ALTER TABLE [dbo].[SectionSchedules] DROP CONSTRAINT [CK_Schedule_Time]
GO
ALTER TABLE [dbo].[ExamSchedules] DROP CONSTRAINT [CK_Exam_Time]
GO
ALTER TABLE [dbo].[CourseSections] DROP CONSTRAINT [CK_Section_PositiveCapacity]
GO
ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [CK_Courses_Credits]
GO
ALTER TABLE [dbo].[ConductScores] DROP CONSTRAINT [CK_Conduct_Score]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Roster]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_Spec]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_Major]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_Class]
GO
ALTER TABLE [dbo].[TuitionInvoices] DROP CONSTRAINT [FK_Inv_User]
GO
ALTER TABLE [dbo].[TuitionInvoices] DROP CONSTRAINT [FK_Inv_Sem]
GO
ALTER TABLE [dbo].[TuitionInvoiceItems] DROP CONSTRAINT [FK_Item_Invoice]
GO
ALTER TABLE [dbo].[TuitionInvoiceItems] DROP CONSTRAINT [FK_Item_Enroll]
GO
ALTER TABLE [dbo].[Specializations] DROP CONSTRAINT [FK_Spec_Major]
GO
ALTER TABLE [dbo].[SemesterGPA] DROP CONSTRAINT [FK_SemGPA_User]
GO
ALTER TABLE [dbo].[SemesterGPA] DROP CONSTRAINT [FK_SemGPA_Sem]
GO
ALTER TABLE [dbo].[SectionSchedules] DROP CONSTRAINT [FK_Schedule_Section]
GO
ALTER TABLE [dbo].[SectionRegistrations] DROP CONSTRAINT [FK_Reg_Section]
GO
ALTER TABLE [dbo].[SectionRegistrations] DROP CONSTRAINT [FK_Reg_Enroll]
GO
ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_Pay_Inv]
GO
ALTER TABLE [dbo].[OtpPins] DROP CONSTRAINT [FK_Otp_User]
GO
ALTER TABLE [dbo].[Majors] DROP CONSTRAINT [FK_Major_Department]
GO
ALTER TABLE [dbo].[Grades] DROP CONSTRAINT [FK_Grades_Enroll]
GO
ALTER TABLE [dbo].[FeeRules] DROP CONSTRAINT [FK_Fee_Major]
GO
ALTER TABLE [dbo].[ExamSchedules] DROP CONSTRAINT [FK_Exam_Section]
GO
ALTER TABLE [dbo].[Enrollments] DROP CONSTRAINT [FK_Enroll_User]
GO
ALTER TABLE [dbo].[Enrollments] DROP CONSTRAINT [FK_Enroll_Sem]
GO
ALTER TABLE [dbo].[Enrollments] DROP CONSTRAINT [FK_Enroll_Course]
GO
ALTER TABLE [dbo].[Curriculums] DROP CONSTRAINT [FK_Curr_Spec]
GO
ALTER TABLE [dbo].[CurriculumCourses] DROP CONSTRAINT [FK_CurrCourse_Curr]
GO
ALTER TABLE [dbo].[CurriculumCourses] DROP CONSTRAINT [FK_CurrCourse_Course]
GO
ALTER TABLE [dbo].[CourseSections] DROP CONSTRAINT [FK_Section_Sem]
GO
ALTER TABLE [dbo].[CourseSections] DROP CONSTRAINT [FK_Section_Course]
GO
ALTER TABLE [dbo].[ConductScores] DROP CONSTRAINT [FK_Conduct_User]
GO
ALTER TABLE [dbo].[ConductScores] DROP CONSTRAINT [FK_Conduct_Sem]
GO
ALTER TABLE [dbo].[Classes] DROP CONSTRAINT [FK_Class_Spec]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__UpdatedAt__412EB0B6]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__CreatedAt__403A8C7D]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__IsLocked__3F466844]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__EmailVeri__3E52440B]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__Role__3D5E1FD2]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__Id__3C69FB99]
GO
ALTER TABLE [dbo].[TuitionInvoices] DROP CONSTRAINT [DF__TuitionIn__Creat__3B40CD36]
GO
ALTER TABLE [dbo].[TuitionInvoices] DROP CONSTRAINT [DF__TuitionIn__Total__3A4CA8FD]
GO
ALTER TABLE [dbo].[TuitionInvoices] DROP CONSTRAINT [DF__TuitionIn__Statu__395884C4]
GO
ALTER TABLE [dbo].[TuitionInvoiceItems] DROP CONSTRAINT [DF__TuitionIn__Quant__40058253]
GO
ALTER TABLE [dbo].[SemesterGPA] DROP CONSTRAINT [DF__SemesterG__Updat__282DF8C2]
GO
ALTER TABLE [dbo].[SectionRegistrations] DROP CONSTRAINT [DF__SectionRe__Regis__1EA48E88]
GO
ALTER TABLE [dbo].[SectionRegistrations] DROP CONSTRAINT [DF__SectionRe__Statu__1DB06A4F]
GO
ALTER TABLE [dbo].[Roster] DROP CONSTRAINT [DF__Roster__CreatedA__398D8EEE]
GO
ALTER TABLE [dbo].[Roster] DROP CONSTRAINT [DF__Roster__IsUsed__38996AB5]
GO
ALTER TABLE [dbo].[Roster] DROP CONSTRAINT [DF__Roster__Id__37A5467C]
GO
ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [DF__Payments__Status__45BE5BA9]
GO
ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [DF__Payments__PaidAt__44CA3770]
GO
ALTER TABLE [dbo].[OtpPins] DROP CONSTRAINT [DF__OtpPins__Attempt__4E88ABD4]
GO
ALTER TABLE [dbo].[OtpPins] DROP CONSTRAINT [DF__OtpPins__Created__4D94879B]
GO
ALTER TABLE [dbo].[MaDacQuyen] DROP CONSTRAINT [DF__MaDacQuye__Creat__49C3F6B7]
GO
ALTER TABLE [dbo].[MaDacQuyen] DROP CONSTRAINT [DF__MaDacQuye__IsUse__48CFD27E]
GO
ALTER TABLE [dbo].[MaDacQuyen] DROP CONSTRAINT [DF__MaDacQuyen__Id__47DBAE45]
GO
ALTER TABLE [dbo].[LoginThrottle] DROP CONSTRAINT [DF__LoginThro__Count__5EBF139D]
GO
ALTER TABLE [dbo].[Grades] DROP CONSTRAINT [DF__Grades__UpdatedA__236943A5]
GO
ALTER TABLE [dbo].[FeeRules] DROP CONSTRAINT [DF__FeeRules__Curren__339FAB6E]
GO
ALTER TABLE [dbo].[Enrollments] DROP CONSTRAINT [DF__Enrollmen__Creat__17036CC0]
GO
ALTER TABLE [dbo].[Enrollments] DROP CONSTRAINT [DF__Enrollmen__IsImp__160F4887]
GO
ALTER TABLE [dbo].[Enrollments] DROP CONSTRAINT [DF__Enrollmen__IsRet__151B244E]
GO
ALTER TABLE [dbo].[Curriculums] DROP CONSTRAINT [DF__Curriculu__Creat__7B5B524B]
GO
ALTER TABLE [dbo].[CurriculumCourses] DROP CONSTRAINT [DF__Curriculu__IsReq__00200768]
GO
ALTER TABLE [dbo].[CourseSections] DROP CONSTRAINT [DF__CourseSec__Curre__06CD04F7]
GO
ALTER TABLE [dbo].[CourseSections] DROP CONSTRAINT [DF__CourseSec__Capac__05D8E0BE]
GO
ALTER TABLE [dbo].[ConductScores] DROP CONSTRAINT [DF__ConductSc__Updat__2DE6D218]
GO
ALTER TABLE [dbo].[AuditLogs] DROP CONSTRAINT [DF__AuditLogs__Creat__498EEC8D]
GO
/****** Object:  Index [UX_Users_StudentCode_NotNull]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [UX_Users_StudentCode_NotNull] ON [dbo].[Users]
GO
/****** Object:  Index [UX_Users_Email]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [UX_Users_Email] ON [dbo].[Users]
GO
/****** Object:  Index [UX_Users_CCCD]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [UX_Users_CCCD] ON [dbo].[Users]
GO
/****** Object:  Index [IX_Invoice_User_Sem]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Invoice_User_Sem] ON [dbo].[TuitionInvoices]
GO
/****** Object:  Index [UQ_Invoice]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[TuitionInvoices] DROP CONSTRAINT [UQ_Invoice]
GO
/****** Object:  Index [UQ__TuitionI__0D9D7FF3B293BC7A]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[TuitionInvoices] DROP CONSTRAINT [UQ__TuitionI__0D9D7FF3B293BC7A]
GO
/****** Object:  Index [IX_InvItems_Invoice]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_InvItems_Invoice] ON [dbo].[TuitionInvoiceItems]
GO
/****** Object:  Index [IX_Spec_Major]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Spec_Major] ON [dbo].[Specializations]
GO
/****** Object:  Index [UQ__Speciali__A25C5AA7A860C62F]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Specializations] DROP CONSTRAINT [UQ__Speciali__A25C5AA7A860C62F]
GO
/****** Object:  Index [UQ__Semester__A25C5AA75E4039C8]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Semesters] DROP CONSTRAINT [UQ__Semester__A25C5AA75E4039C8]
GO
/****** Object:  Index [UQ_SemGPA]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[SemesterGPA] DROP CONSTRAINT [UQ_SemGPA]
GO
/****** Object:  Index [IX_Schedules_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Schedules_Section] ON [dbo].[SectionSchedules]
GO
/****** Object:  Index [IX_Reg_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Reg_Section] ON [dbo].[SectionRegistrations]
GO
/****** Object:  Index [UQ_Enroll_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[SectionRegistrations] DROP CONSTRAINT [UQ_Enroll_Section]
GO
/****** Object:  Index [UX_Roster_StudentCode]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [UX_Roster_StudentCode] ON [dbo].[Roster]
GO
/****** Object:  Index [UX_Roster_EmailSchool]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [UX_Roster_EmailSchool] ON [dbo].[Roster]
GO
/****** Object:  Index [IX_Pay_Invoice]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Pay_Invoice] ON [dbo].[Payments]
GO
/****** Object:  Index [IX_Otp_User_Purpose]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Otp_User_Purpose] ON [dbo].[OtpPins]
GO
/****** Object:  Index [IX_Majors_Department]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Majors_Department] ON [dbo].[Majors]
GO
/****** Object:  Index [UQ__Majors__A25C5AA7B153D026]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Majors] DROP CONSTRAINT [UQ__Majors__A25C5AA7B153D026]
GO
/****** Object:  Index [IX_Throttle_Scope_Key_Window]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Throttle_Scope_Key_Window] ON [dbo].[LoginThrottle]
GO
/****** Object:  Index [UX_Grades_Enroll]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [UX_Grades_Enroll] ON [dbo].[Grades]
GO
/****** Object:  Index [IX_Exams_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Exams_Section] ON [dbo].[ExamSchedules]
GO
/****** Object:  Index [IX_Enroll_User]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Enroll_User] ON [dbo].[Enrollments]
GO
/****** Object:  Index [IX_Enroll_Sem]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Enroll_Sem] ON [dbo].[Enrollments]
GO
/****** Object:  Index [IX_Enroll_Course]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Enroll_Course] ON [dbo].[Enrollments]
GO
/****** Object:  Index [UQ_Enrollment]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Enrollments] DROP CONSTRAINT [UQ_Enrollment]
GO
/****** Object:  Index [UQ__Departme__A25C5AA74CE83619]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Departments] DROP CONSTRAINT [UQ__Departme__A25C5AA74CE83619]
GO
/****** Object:  Index [UQ__Curricul__A25C5AA78E536755]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Curriculums] DROP CONSTRAINT [UQ__Curricul__A25C5AA78E536755]
GO
/****** Object:  Index [IX_CurrCourse_SemOrder]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_CurrCourse_SemOrder] ON [dbo].[CurriculumCourses]
GO
/****** Object:  Index [UQ_Curriculum_Course]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[CurriculumCourses] DROP CONSTRAINT [UQ_Curriculum_Course]
GO
/****** Object:  Index [IX_Sections_Course_Sem]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Sections_Course_Sem] ON [dbo].[CourseSections]
GO
/****** Object:  Index [UQ_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[CourseSections] DROP CONSTRAINT [UQ_Section]
GO
/****** Object:  Index [UQ__Courses__A25C5AA7E7C7CA28]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [UQ__Courses__A25C5AA7E7C7CA28]
GO
/****** Object:  Index [UQ_Conduct]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[ConductScores] DROP CONSTRAINT [UQ_Conduct]
GO
/****** Object:  Index [UQ__Classes__A25C5AA77BD25E77]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Classes] DROP CONSTRAINT [UQ__Classes__A25C5AA77BD25E77]
GO
/****** Object:  Index [IX_Audit_User_Created]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP INDEX [IX_Audit_User_Created] ON [dbo].[AuditLogs]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[TuitionInvoices]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TuitionInvoices]') AND type in (N'U'))
DROP TABLE [dbo].[TuitionInvoices]
GO
/****** Object:  Table [dbo].[TuitionInvoiceItems]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TuitionInvoiceItems]') AND type in (N'U'))
DROP TABLE [dbo].[TuitionInvoiceItems]
GO
/****** Object:  Table [dbo].[Specializations]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Specializations]') AND type in (N'U'))
DROP TABLE [dbo].[Specializations]
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Semesters]') AND type in (N'U'))
DROP TABLE [dbo].[Semesters]
GO
/****** Object:  Table [dbo].[SemesterGPA]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SemesterGPA]') AND type in (N'U'))
DROP TABLE [dbo].[SemesterGPA]
GO
/****** Object:  Table [dbo].[SectionSchedules]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SectionSchedules]') AND type in (N'U'))
DROP TABLE [dbo].[SectionSchedules]
GO
/****** Object:  Table [dbo].[SectionRegistrations]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SectionRegistrations]') AND type in (N'U'))
DROP TABLE [dbo].[SectionRegistrations]
GO
/****** Object:  Table [dbo].[Roster]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roster]') AND type in (N'U'))
DROP TABLE [dbo].[Roster]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Payments]') AND type in (N'U'))
DROP TABLE [dbo].[Payments]
GO
/****** Object:  Table [dbo].[OtpPins]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OtpPins]') AND type in (N'U'))
DROP TABLE [dbo].[OtpPins]
GO
/****** Object:  Table [dbo].[Majors]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Majors]') AND type in (N'U'))
DROP TABLE [dbo].[Majors]
GO
/****** Object:  Table [dbo].[MaDacQuyen]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MaDacQuyen]') AND type in (N'U'))
DROP TABLE [dbo].[MaDacQuyen]
GO
/****** Object:  Table [dbo].[LoginThrottle]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoginThrottle]') AND type in (N'U'))
DROP TABLE [dbo].[LoginThrottle]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grades]') AND type in (N'U'))
DROP TABLE [dbo].[Grades]
GO
/****** Object:  Table [dbo].[FeeRules]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeeRules]') AND type in (N'U'))
DROP TABLE [dbo].[FeeRules]
GO
/****** Object:  Table [dbo].[ExamSchedules]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamSchedules]') AND type in (N'U'))
DROP TABLE [dbo].[ExamSchedules]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollments]') AND type in (N'U'))
DROP TABLE [dbo].[Enrollments]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departments]') AND type in (N'U'))
DROP TABLE [dbo].[Departments]
GO
/****** Object:  Table [dbo].[Curriculums]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Curriculums]') AND type in (N'U'))
DROP TABLE [dbo].[Curriculums]
GO
/****** Object:  Table [dbo].[CurriculumCourses]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CurriculumCourses]') AND type in (N'U'))
DROP TABLE [dbo].[CurriculumCourses]
GO
/****** Object:  Table [dbo].[CourseSections]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CourseSections]') AND type in (N'U'))
DROP TABLE [dbo].[CourseSections]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Courses]') AND type in (N'U'))
DROP TABLE [dbo].[Courses]
GO
/****** Object:  Table [dbo].[ConductScores]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConductScores]') AND type in (N'U'))
DROP TABLE [dbo].[ConductScores]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Classes]') AND type in (N'U'))
DROP TABLE [dbo].[Classes]
GO
/****** Object:  Table [dbo].[AuditLogs]    Script Date: 10/14/2025 1:02:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLogs]') AND type in (N'U'))
DROP TABLE [dbo].[AuditLogs]
GO
/****** Object:  Database [StudentDB]    Script Date: 10/14/2025 1:02:16 PM ******/
DROP DATABASE [StudentDB]
GO
/****** Object:  Database [StudentDB]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE DATABASE [StudentDB]   WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF;
GO
ALTER DATABASE [StudentDB] SET COMPATIBILITY_LEVEL = 160
GO
ALTER DATABASE [StudentDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentDB] SET  MULTI_USER 
GO
ALTER DATABASE [StudentDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [StudentDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/****** Object:  Table [dbo].[AuditLogs]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[Action] [nvarchar](64) NOT NULL,
	[Detail] [nvarchar](1024) NULL,
	[CreatedAtUtc] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[SpecializationId] [int] NULL,
	[CohortYear] [smallint] NULL,
	[HomeroomTeacher] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConductScores]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConductScores](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[Rank] [nvarchar](16) NULL,
	[UpdatedAtUtc] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[Credits] [int] NOT NULL,
	[Department] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseSections]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseSections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[SectionCode] [nvarchar](32) NOT NULL,
	[Lecturer] [nvarchar](128) NULL,
	[Capacity] [int] NOT NULL,
	[CurrentSize] [int] NOT NULL,
	[Room] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurriculumCourses]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurriculumCourses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurriculumId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[SemesterOrder] [int] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[MinGradeToPass] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curriculums]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curriculums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpecializationId] [int] NOT NULL,
	[Code] [nvarchar](32) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[TotalRequiredCredits] [int] NULL,
	[CreatedAtUtc] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CourseId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[IsRetake] [bit] NOT NULL,
	[IsImprovement] [bit] NOT NULL,
	[CreatedAtUtc] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamSchedules]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamSchedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [int] NOT NULL,
	[ExamType] [nvarchar](32) NOT NULL,
	[ExamStart] [datetime2](7) NOT NULL,
	[ExamEnd] [datetime2](7) NOT NULL,
	[Room] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeeRules]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeeRules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Scope] [nvarchar](16) NOT NULL,
	[MajorId] [int] NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Currency] [nvarchar](8) NOT NULL,
	[EffectiveFrom] [date] NOT NULL,
	[EffectiveTo] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EnrollmentId] [bigint] NOT NULL,
	[Midterm] [decimal](5, 2) NULL,
	[Final] [decimal](5, 2) NULL,
	[Other] [decimal](5, 2) NULL,
	[FinalNumeric] [decimal](5, 2) NULL,
	[LetterGrade] [nvarchar](4) NULL,
	[Passed] [bit] NULL,
	[UpdatedAtUtc] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginThrottle]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginThrottle](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Scope] [nvarchar](32) NOT NULL,
	[KeyHash] [varbinary](32) NOT NULL,
	[WindowStartUtc] [datetime2](7) NOT NULL,
	[Count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaDacQuyen]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaDacQuyen](
	[Id] [uniqueidentifier] NOT NULL,
	[CodeHash] [varbinary](64) NOT NULL,
	[Salt] [varbinary](16) NOT NULL,
	[ExpiresAtUtc] [datetime2](7) NULL,
	[IsUsed] [bit] NOT NULL,
	[CreateAtUtc] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Majors]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Majors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtpPins]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtpPins](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Purpose] [nvarchar](32) NOT NULL,
	[CodeHash] [varbinary](64) NOT NULL,
	[Salt] [varbinary](16) NOT NULL,
	[ExpiresAtUtc] [datetime2](7) NOT NULL,
	[ConsumedAtUtc] [datetime2](7) NULL,
	[CreatedAtUtc] [datetime2](7) NOT NULL,
	[AttemptCount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [bigint] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Method] [nvarchar](32) NOT NULL,
	[PaidAtUtc] [datetime2](7) NOT NULL,
	[RefCode] [nvarchar](64) NULL,
	[Status] [nvarchar](16) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roster]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roster](
	[Id] [uniqueidentifier] NOT NULL,
	[StudentCode] [nvarchar](32) NOT NULL,
	[EmailSchool] [nvarchar](256) NOT NULL,
	[FullName] [nvarchar](128) NULL,
	[IsUsed] [bit] NOT NULL,
	[ExpiresAtUtc] [datetime2](7) NULL,
	[CreatedAtUts] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SectionRegistrations]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SectionRegistrations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EnrollmentId] [bigint] NOT NULL,
	[SectionId] [int] NOT NULL,
	[Status] [nvarchar](16) NOT NULL,
	[RegisteredAtUtc] [datetime2](7) NOT NULL,
	[DroppedAtUtc] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SectionSchedules]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SectionSchedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [int] NOT NULL,
	[DayOfWeek] [tinyint] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Room] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SemesterGPA]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SemesterGPA](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[GPA] [decimal](3, 2) NOT NULL,
	[UpdatedAtUtc] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specializations]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specializations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MajorId] [int] NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TuitionInvoiceItems]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuitionInvoiceItems](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [bigint] NOT NULL,
	[EnrollmentId] [bigint] NULL,
	[Description] [nvarchar](256) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[LineAmount]  AS ([Quantity]*[UnitPrice]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TuitionInvoices]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuitionInvoices](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[InvoiceCode] [nvarchar](32) NOT NULL,
	[Status] [nvarchar](16) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[CreatedAtUtc] [datetime2](7) NOT NULL,
	[PaidAtUtc] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/14/2025 1:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](128) NOT NULL,
	[EmailNormalized] [nvarchar](256) NOT NULL,
	[PasswordHash] [nvarchar](512) NOT NULL,
	[CCCD] [char](12) NOT NULL,
	[PhoneE164] [nvarchar](16) NULL,
	[Role] [nvarchar](16) NOT NULL,
	[RosterId] [uniqueidentifier] NULL,
	[StudentCode] [nvarchar](32) NULL,
	[ClassId] [int] NULL,
	[MajorId] [int] NULL,
	[SpecializationId] [int] NULL,
	[CohortYear] [smallint] NULL,
	[EmailVerified] [bit] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[CreatedAtUtc] [datetime2](7) NOT NULL,
	[UpdatedAtUtc] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Audit_User_Created]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Audit_User_Created] ON [dbo].[AuditLogs]
(
	[UserId] ASC,
	[CreatedAtUtc] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Classes__A25C5AA77BD25E77]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Classes] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Conduct]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[ConductScores] ADD  CONSTRAINT [UQ_Conduct] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[SemesterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Courses__A25C5AA7E7C7CA28]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Courses] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[CourseSections] ADD  CONSTRAINT [UQ_Section] UNIQUE NONCLUSTERED 
(
	[CourseId] ASC,
	[SemesterId] ASC,
	[SectionCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sections_Course_Sem]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Sections_Course_Sem] ON [dbo].[CourseSections]
(
	[CourseId] ASC,
	[SemesterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Curriculum_Course]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[CurriculumCourses] ADD  CONSTRAINT [UQ_Curriculum_Course] UNIQUE NONCLUSTERED 
(
	[CurriculumId] ASC,
	[CourseId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CurrCourse_SemOrder]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_CurrCourse_SemOrder] ON [dbo].[CurriculumCourses]
(
	[CurriculumId] ASC,
	[SemesterOrder] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Curricul__A25C5AA78E536755]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Curriculums] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Departme__A25C5AA74CE83619]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Departments] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Enrollment]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Enrollments] ADD  CONSTRAINT [UQ_Enrollment] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[CourseId] ASC,
	[SemesterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enroll_Course]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Enroll_Course] ON [dbo].[Enrollments]
(
	[CourseId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enroll_Sem]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Enroll_Sem] ON [dbo].[Enrollments]
(
	[SemesterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enroll_User]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Enroll_User] ON [dbo].[Enrollments]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Exams_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Exams_Section] ON [dbo].[ExamSchedules]
(
	[SectionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UX_Grades_Enroll]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Grades_Enroll] ON [dbo].[Grades]
(
	[EnrollmentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Throttle_Scope_Key_Window]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Throttle_Scope_Key_Window] ON [dbo].[LoginThrottle]
(
	[Scope] ASC,
	[KeyHash] ASC,
	[WindowStartUtc] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Majors__A25C5AA7B153D026]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Majors] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Majors_Department]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Majors_Department] ON [dbo].[Majors]
(
	[DepartmentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Otp_User_Purpose]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Otp_User_Purpose] ON [dbo].[OtpPins]
(
	[UserId] ASC,
	[Purpose] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pay_Invoice]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pay_Invoice] ON [dbo].[Payments]
(
	[InvoiceId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Roster_EmailSchool]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Roster_EmailSchool] ON [dbo].[Roster]
(
	[EmailSchool] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Roster_StudentCode]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Roster_StudentCode] ON [dbo].[Roster]
(
	[StudentCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Enroll_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[SectionRegistrations] ADD  CONSTRAINT [UQ_Enroll_Section] UNIQUE NONCLUSTERED 
(
	[EnrollmentId] ASC,
	[SectionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reg_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reg_Section] ON [dbo].[SectionRegistrations]
(
	[SectionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedules_Section]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Schedules_Section] ON [dbo].[SectionSchedules]
(
	[SectionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_SemGPA]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[SemesterGPA] ADD  CONSTRAINT [UQ_SemGPA] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[SemesterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Semester__A25C5AA75E4039C8]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Semesters] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Speciali__A25C5AA7A860C62F]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[Specializations] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Spec_Major]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Spec_Major] ON [dbo].[Specializations]
(
	[MajorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvItems_Invoice]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvItems_Invoice] ON [dbo].[TuitionInvoiceItems]
(
	[InvoiceId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TuitionI__0D9D7FF3B293BC7A]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[TuitionInvoices] ADD UNIQUE NONCLUSTERED 
(
	[InvoiceCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Invoice]    Script Date: 10/14/2025 1:02:16 PM ******/
ALTER TABLE [dbo].[TuitionInvoices] ADD  CONSTRAINT [UQ_Invoice] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[SemesterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoice_User_Sem]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoice_User_Sem] ON [dbo].[TuitionInvoices]
(
	[UserId] ASC,
	[SemesterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Users_CCCD]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Users_CCCD] ON [dbo].[Users]
(
	[CCCD] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Users_Email]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Users_Email] ON [dbo].[Users]
(
	[EmailNormalized] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Users_StudentCode_NotNull]    Script Date: 10/14/2025 1:02:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Users_StudentCode_NotNull] ON [dbo].[Users]
(
	[StudentCode] ASC
)
WHERE ([StudentCode] IS NOT NULL)
WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuditLogs] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAtUtc]
GO
ALTER TABLE [dbo].[ConductScores] ADD  DEFAULT (sysutcdatetime()) FOR [UpdatedAtUtc]
GO
ALTER TABLE [dbo].[CourseSections] ADD  DEFAULT ((60)) FOR [Capacity]
GO
ALTER TABLE [dbo].[CourseSections] ADD  DEFAULT ((0)) FOR [CurrentSize]
GO
ALTER TABLE [dbo].[CurriculumCourses] ADD  DEFAULT ((1)) FOR [IsRequired]
GO
ALTER TABLE [dbo].[Curriculums] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAtUtc]
GO
ALTER TABLE [dbo].[Enrollments] ADD  DEFAULT ((0)) FOR [IsRetake]
GO
ALTER TABLE [dbo].[Enrollments] ADD  DEFAULT ((0)) FOR [IsImprovement]
GO
ALTER TABLE [dbo].[Enrollments] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAtUtc]
GO
ALTER TABLE [dbo].[FeeRules] ADD  DEFAULT (N'VND') FOR [Currency]
GO
ALTER TABLE [dbo].[Grades] ADD  DEFAULT (sysutcdatetime()) FOR [UpdatedAtUtc]
GO
ALTER TABLE [dbo].[LoginThrottle] ADD  DEFAULT ((0)) FOR [Count]
GO
ALTER TABLE [dbo].[MaDacQuyen] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[MaDacQuyen] ADD  DEFAULT ((0)) FOR [IsUsed]
GO
ALTER TABLE [dbo].[MaDacQuyen] ADD  DEFAULT (sysutcdatetime()) FOR [CreateAtUtc]
GO
ALTER TABLE [dbo].[OtpPins] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAtUtc]
GO
ALTER TABLE [dbo].[OtpPins] ADD  DEFAULT ((0)) FOR [AttemptCount]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (sysutcdatetime()) FOR [PaidAtUtc]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (N'success') FOR [Status]
GO
ALTER TABLE [dbo].[Roster] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Roster] ADD  DEFAULT ((0)) FOR [IsUsed]
GO
ALTER TABLE [dbo].[Roster] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAtUts]
GO
ALTER TABLE [dbo].[SectionRegistrations] ADD  DEFAULT (N'enrolled') FOR [Status]
GO
ALTER TABLE [dbo].[SectionRegistrations] ADD  DEFAULT (sysutcdatetime()) FOR [RegisteredAtUtc]
GO
ALTER TABLE [dbo].[SemesterGPA] ADD  DEFAULT (sysutcdatetime()) FOR [UpdatedAtUtc]
GO
ALTER TABLE [dbo].[TuitionInvoiceItems] ADD  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[TuitionInvoices] ADD  DEFAULT (N'unpaid') FOR [Status]
GO
ALTER TABLE [dbo].[TuitionInvoices] ADD  DEFAULT ((0)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[TuitionInvoices] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAtUtc]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'user') FOR [Role]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [EmailVerified]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAtUtc]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (sysutcdatetime()) FOR [UpdatedAtUtc]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Class_Spec] FOREIGN KEY([SpecializationId])
REFERENCES [dbo].[Specializations] ([Id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Class_Spec]
GO
ALTER TABLE [dbo].[ConductScores]  WITH CHECK ADD  CONSTRAINT [FK_Conduct_Sem] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[ConductScores] CHECK CONSTRAINT [FK_Conduct_Sem]
GO
ALTER TABLE [dbo].[ConductScores]  WITH CHECK ADD  CONSTRAINT [FK_Conduct_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ConductScores] CHECK CONSTRAINT [FK_Conduct_User]
GO
ALTER TABLE [dbo].[CourseSections]  WITH CHECK ADD  CONSTRAINT [FK_Section_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CourseSections] CHECK CONSTRAINT [FK_Section_Course]
GO
ALTER TABLE [dbo].[CourseSections]  WITH CHECK ADD  CONSTRAINT [FK_Section_Sem] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[CourseSections] CHECK CONSTRAINT [FK_Section_Sem]
GO
ALTER TABLE [dbo].[CurriculumCourses]  WITH CHECK ADD  CONSTRAINT [FK_CurrCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CurriculumCourses] CHECK CONSTRAINT [FK_CurrCourse_Course]
GO
ALTER TABLE [dbo].[CurriculumCourses]  WITH CHECK ADD  CONSTRAINT [FK_CurrCourse_Curr] FOREIGN KEY([CurriculumId])
REFERENCES [dbo].[Curriculums] ([Id])
GO
ALTER TABLE [dbo].[CurriculumCourses] CHECK CONSTRAINT [FK_CurrCourse_Curr]
GO
ALTER TABLE [dbo].[Curriculums]  WITH CHECK ADD  CONSTRAINT [FK_Curr_Spec] FOREIGN KEY([SpecializationId])
REFERENCES [dbo].[Specializations] ([Id])
GO
ALTER TABLE [dbo].[Curriculums] CHECK CONSTRAINT [FK_Curr_Spec]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enroll_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enroll_Course]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enroll_Sem] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enroll_Sem]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enroll_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enroll_User]
GO
ALTER TABLE [dbo].[ExamSchedules]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Section] FOREIGN KEY([SectionId])
REFERENCES [dbo].[CourseSections] ([Id])
GO
ALTER TABLE [dbo].[ExamSchedules] CHECK CONSTRAINT [FK_Exam_Section]
GO
ALTER TABLE [dbo].[FeeRules]  WITH CHECK ADD  CONSTRAINT [FK_Fee_Major] FOREIGN KEY([MajorId])
REFERENCES [dbo].[Majors] ([Id])
GO
ALTER TABLE [dbo].[FeeRules] CHECK CONSTRAINT [FK_Fee_Major]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Enroll] FOREIGN KEY([EnrollmentId])
REFERENCES [dbo].[Enrollments] ([Id])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Enroll]
GO
ALTER TABLE [dbo].[Majors]  WITH CHECK ADD  CONSTRAINT [FK_Major_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Majors] CHECK CONSTRAINT [FK_Major_Department]
GO
ALTER TABLE [dbo].[OtpPins]  WITH CHECK ADD  CONSTRAINT [FK_Otp_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[OtpPins] CHECK CONSTRAINT [FK_Otp_User]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Pay_Inv] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[TuitionInvoices] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Pay_Inv]
GO
ALTER TABLE [dbo].[SectionRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_Reg_Enroll] FOREIGN KEY([EnrollmentId])
REFERENCES [dbo].[Enrollments] ([Id])
GO
ALTER TABLE [dbo].[SectionRegistrations] CHECK CONSTRAINT [FK_Reg_Enroll]
GO
ALTER TABLE [dbo].[SectionRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_Reg_Section] FOREIGN KEY([SectionId])
REFERENCES [dbo].[CourseSections] ([Id])
GO
ALTER TABLE [dbo].[SectionRegistrations] CHECK CONSTRAINT [FK_Reg_Section]
GO
ALTER TABLE [dbo].[SectionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Section] FOREIGN KEY([SectionId])
REFERENCES [dbo].[CourseSections] ([Id])
GO
ALTER TABLE [dbo].[SectionSchedules] CHECK CONSTRAINT [FK_Schedule_Section]
GO
ALTER TABLE [dbo].[SemesterGPA]  WITH CHECK ADD  CONSTRAINT [FK_SemGPA_Sem] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[SemesterGPA] CHECK CONSTRAINT [FK_SemGPA_Sem]
GO
ALTER TABLE [dbo].[SemesterGPA]  WITH CHECK ADD  CONSTRAINT [FK_SemGPA_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[SemesterGPA] CHECK CONSTRAINT [FK_SemGPA_User]
GO
ALTER TABLE [dbo].[Specializations]  WITH CHECK ADD  CONSTRAINT [FK_Spec_Major] FOREIGN KEY([MajorId])
REFERENCES [dbo].[Majors] ([Id])
GO
ALTER TABLE [dbo].[Specializations] CHECK CONSTRAINT [FK_Spec_Major]
GO
ALTER TABLE [dbo].[TuitionInvoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_Item_Enroll] FOREIGN KEY([EnrollmentId])
REFERENCES [dbo].[Enrollments] ([Id])
GO
ALTER TABLE [dbo].[TuitionInvoiceItems] CHECK CONSTRAINT [FK_Item_Enroll]
GO
ALTER TABLE [dbo].[TuitionInvoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_Item_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[TuitionInvoices] ([Id])
GO
ALTER TABLE [dbo].[TuitionInvoiceItems] CHECK CONSTRAINT [FK_Item_Invoice]
GO
ALTER TABLE [dbo].[TuitionInvoices]  WITH CHECK ADD  CONSTRAINT [FK_Inv_Sem] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[TuitionInvoices] CHECK CONSTRAINT [FK_Inv_Sem]
GO
ALTER TABLE [dbo].[TuitionInvoices]  WITH CHECK ADD  CONSTRAINT [FK_Inv_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[TuitionInvoices] CHECK CONSTRAINT [FK_Inv_User]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Class]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Major] FOREIGN KEY([MajorId])
REFERENCES [dbo].[Majors] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Major]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Spec] FOREIGN KEY([SpecializationId])
REFERENCES [dbo].[Specializations] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Spec]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roster] FOREIGN KEY([RosterId])
REFERENCES [dbo].[Roster] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roster]
GO
ALTER TABLE [dbo].[ConductScores]  WITH CHECK ADD  CONSTRAINT [CK_Conduct_Score] CHECK  (([Score]>=(0) AND [Score]<=(100)))
GO
ALTER TABLE [dbo].[ConductScores] CHECK CONSTRAINT [CK_Conduct_Score]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [CK_Courses_Credits] CHECK  (([Credits]>(0) AND [Credits]<=(50)))
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [CK_Courses_Credits]
GO
ALTER TABLE [dbo].[CourseSections]  WITH CHECK ADD  CONSTRAINT [CK_Section_PositiveCapacity] CHECK  (([Capacity]>(0)))
GO
ALTER TABLE [dbo].[CourseSections] CHECK CONSTRAINT [CK_Section_PositiveCapacity]
GO
ALTER TABLE [dbo].[ExamSchedules]  WITH CHECK ADD  CONSTRAINT [CK_Exam_Time] CHECK  (([ExamStart]<[ExamEnd]))
GO
ALTER TABLE [dbo].[ExamSchedules] CHECK CONSTRAINT [CK_Exam_Time]
GO
ALTER TABLE [dbo].[SectionSchedules]  WITH CHECK ADD  CONSTRAINT [CK_Schedule_Time] CHECK  (([StartTime]<[EndTime]))
GO
ALTER TABLE [dbo].[SectionSchedules] CHECK CONSTRAINT [CK_Schedule_Time]
GO
ALTER TABLE [dbo].[Semesters]  WITH CHECK ADD  CONSTRAINT [CK_Sem_DateRange] CHECK  (([StartDate]<=[EndDate]))
GO
ALTER TABLE [dbo].[Semesters] CHECK CONSTRAINT [CK_Sem_DateRange]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_Users_CCCD_12Digits] CHECK  ((len([CCCD])=(12) AND NOT [CCCD] like '%[^0-9]%'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_Users_CCCD_12Digits]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_Users_PhoneE164] CHECK  (([PhoneE164] IS NULL OR left([PhoneE164],(1))='+' AND NOT [PhoneE164] like '%[^+0-9]%' AND (len(replace([PhoneE164],'+',''))>=(10) AND len(replace([PhoneE164],'+',''))<=(15))))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_Users_PhoneE164]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_Users_Role] CHECK  (([Role]=N'admin' OR [Role]=N'user'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_Users_Role]
GO
/****** Object:  Trigger [dbo].[trg_Users_UpdateTimestamp]    Script Date: 10/14/2025 1:02:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Trigger cập nhật UpdatedAtUtc khi UPDATE Users */
CREATE TRIGGER [dbo].[trg_Users_UpdateTimestamp]
ON [dbo].[Users]
AFTER UPDATE 
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE u
	SET UpdatedAtUtc = SYSUTCDATETIME()
	FROM dbo.Users u
	INNER JOIN inserted i ON u.Id = i.Id;
END
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [trg_Users_UpdateTimestamp]
GO
ALTER DATABASE [StudentDB] SET  READ_WRITE 
GO
