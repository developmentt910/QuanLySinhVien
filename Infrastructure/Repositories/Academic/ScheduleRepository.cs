using System.Data;
using Microsoft.Data.SqlClient;
using System;
using StudentCourseManagement.Infrastructure.Data;
using StudentCourseManagement.Domain.Abstractions.Repositories;

namespace StudentCourseManagement.Infrastructure.Repositories.Academic
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly SqlConnectionFactory _dbFactory;

        public ScheduleRepository(SqlConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        private DataTable GetData(string query, SqlParameter[]? parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection conn = _dbFactory.Create())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        private void ExecuteCommand(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = _dbFactory.Create())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing command: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetFaculties()
        {
            string query = "SELECT Id, FacultyName FROM dbo.Faculty ORDER BY FacultyName";
            return GetData(query);
        }

        public DataTable GetMajorsByFaculty(string facultyId)
        {
            string query = "SELECT Id, MajorName FROM dbo.Major WHERE FacultyId = @FacultyId ORDER BY MajorName";
            var parameters = new[]
            {
                new SqlParameter("@FacultyId", SqlDbType.UniqueIdentifier) { Value = new Guid(facultyId) }
            };
            return GetData(query, parameters);
        }

        public DataTable GetSpecializationsByMajor(string majorId)
        {
            string query = "SELECT Id, SpecializationName FROM dbo.Specialization WHERE MajorId = @MajorId ORDER BY SpecializationName";
            var parameters = new[]
            {
                new SqlParameter("@MajorId", SqlDbType.UniqueIdentifier) { Value = new Guid(majorId) }
            };
            return GetData(query, parameters);
        }

        public DataTable GetClassesBySpecialization(string specializationId)
        {
            string query = "SELECT Id, ClassName FROM dbo.Class WHERE SpecializationId = @SpecializationId ORDER BY ClassName";
            var parameters = new[]
            {
                new SqlParameter("@SpecializationId", SqlDbType.UniqueIdentifier) { Value = new Guid(specializationId) }
            };
            return GetData(query, parameters);
        }

        public DataTable GetSemesters()
        {
            string query = "SELECT Id, (SemesterName + ' (' + AcademicYear + ')') AS DisplayName FROM dbo.Semester ORDER BY AcademicYear, SemesterName";
            return GetData(query);
        }

        public DataTable GetSchedules(string classId, string semesterId)
        {
            string query = @"
                SELECT 
                    c.ClassName,
                    sub.SubjectCode, sub.SubjectName, s.TeacherName, s.Room, sub.Credit,
                    sub.LectureHours, sub.PracticeHours, (sem.SemesterName + ' (' + sem.AcademicYear + ')') AS Semester,
                    s.LessonDate, s.StartPeriod, s.EndPeriod, s.Id, s.SubjectId
                FROM dbo.Schedule s
                JOIN dbo.Subject sub ON s.SubjectId = sub.Id
                JOIN dbo.Semester sem ON s.SemesterId = sem.Id
                JOIN dbo.Class c ON s.ClassId = c.Id
                WHERE s.ClassId = @ClassId AND s.SemesterId = @SemesterId
                ORDER BY s.LessonDate, s.StartPeriod";

            var parameters = new[]
            {
                new SqlParameter("@ClassId", SqlDbType.UniqueIdentifier) { Value = new Guid(classId) },
                new SqlParameter("@SemesterId", SqlDbType.UniqueIdentifier) { Value = new Guid(semesterId) }
            };
            return GetData(query, parameters);
        }
        public DataTable GetAvailableSubjects(string classId, string semesterId, Guid majorId, Guid specializationId)
        {
            string query = @"
                SELECT Id, SubjectName, SubjectCode, Credit, LectureHours, PracticeHours 
                FROM dbo.Subject
                WHERE 
                    MajorId = @MajorId 
                    AND (SpecializationId IS NULL OR SpecializationId = @SpecializationId)
                    AND Id NOT IN 
                        (SELECT SubjectId FROM dbo.Schedule WHERE ClassId = @ClassId AND SemesterId = @SemesterId)
                ORDER BY SubjectName";

            var parameters = new[]
            {
                new SqlParameter("@ClassId", SqlDbType.UniqueIdentifier) { Value = new Guid(classId) },
                new SqlParameter("@SemesterId", SqlDbType.UniqueIdentifier) { Value = new Guid(semesterId) },
                new SqlParameter("@MajorId", SqlDbType.UniqueIdentifier) { Value = majorId },
                new SqlParameter("@SpecializationId", SqlDbType.UniqueIdentifier) { Value = specializationId }
            };
            return GetData(query, parameters);
        }

        public void AddSchedule(string classId, string subjectId, string teacherName,
                                string room, string semesterId, DateTime lessonDate,
                                int startPeriod, int endPeriod)
        {
            string query = @"
                INSERT INTO dbo.Schedule (Id, ClassId, SubjectId, TeacherName, Room, SemesterId, LessonDate, StartPeriod, EndPeriod) 
                VALUES (NEWID(), @ClassId, @SubjectId, @TeacherName, @Room, @SemesterId, @LessonDate, @StartPeriod, @EndPeriod)";

            var parameters = new[]
            {
                new SqlParameter("@ClassId", SqlDbType.UniqueIdentifier) { Value = new Guid(classId) },
                new SqlParameter("@SubjectId", SqlDbType.UniqueIdentifier) { Value = new Guid(subjectId) },
                new SqlParameter("@TeacherName", (object)teacherName ?? DBNull.Value),
                new SqlParameter("@Room", (object)room ?? DBNull.Value),
                new SqlParameter("@SemesterId", SqlDbType.UniqueIdentifier) { Value = new Guid(semesterId) },
                new SqlParameter("@LessonDate", lessonDate),
                new SqlParameter("@StartPeriod", startPeriod),
                new SqlParameter("@EndPeriod", endPeriod)
            };
            ExecuteCommand(query, parameters);
        }

        public void RemoveSchedule(string scheduleId)
        {
            string query = "DELETE FROM dbo.Schedule WHERE Id = @ScheduleId";
            var parameters = new[]
            {
                new SqlParameter("@ScheduleId", SqlDbType.UniqueIdentifier) { Value = new Guid(scheduleId) }
            };
            ExecuteCommand(query, parameters);
        }

        public void UpdateSchedule(string scheduleId, string subjectId, string teacherName,
                           string room, DateTime lessonDate, int startPeriod, int endPeriod)
        {
            string query = @"
                UPDATE dbo.Schedule
                SET 
                    SubjectId = @SubjectId,
                    TeacherName = @TeacherName,
                    Room = @Room,
                    LessonDate = @LessonDate,
                    StartPeriod = @StartPeriod,
                    EndPeriod = @EndPeriod
                WHERE 
                    Id = @ScheduleId";

            var parameters = new[]
            {
                new SqlParameter("@SubjectId", SqlDbType.UniqueIdentifier) { Value = new Guid(subjectId) },
                new SqlParameter("@TeacherName", (object)teacherName ?? DBNull.Value),
                new SqlParameter("@Room", (object)room ?? DBNull.Value),
                new SqlParameter("@LessonDate", lessonDate),
                new SqlParameter("@StartPeriod", startPeriod),
                new SqlParameter("@EndPeriod", endPeriod),
                new SqlParameter("@ScheduleId", SqlDbType.UniqueIdentifier) { Value = new Guid(scheduleId) }
            };
            ExecuteCommand(query, parameters);
        }
        public DataTable GetSubjectsBySpecialization(Guid majorId, Guid specializationId)
        {
            string query = @"
                SELECT Id, SubjectName 
                FROM dbo.Subject 
                WHERE MajorId = @MajorId 
                  AND (SpecializationId IS NULL OR SpecializationId = @SpecializationId)
                ORDER BY SubjectName";

            var parameters = new[]
            {
                new SqlParameter("@MajorId", SqlDbType.UniqueIdentifier) { Value = majorId },
                new SqlParameter("@SpecializationId", SqlDbType.UniqueIdentifier) { Value = specializationId }
            };
            return GetData(query, parameters);
        }
        public DataTable GetAllSubjectDetailsBySpecialization(Guid majorId, Guid specializationId)
        {
            string query = @"
                SELECT Id, SubjectCode, SubjectName, Credit, LectureHours, PracticeHours 
                FROM dbo.Subject 
                WHERE MajorId = @MajorId 
                  AND (SpecializationId IS NULL OR SpecializationId = @SpecializationId)
                ORDER BY SubjectName";

            var parameters = new[]
            {
                new SqlParameter("@MajorId", SqlDbType.UniqueIdentifier) { Value = majorId },
                new SqlParameter("@SpecializationId", SqlDbType.UniqueIdentifier) { Value = specializationId }
            };
            return GetData(query, parameters);
        }
        public bool IsTeacherBusy(string teacherName, DateTime lessonDate, int startPeriod, int endPeriod, string? ignoreScheduleId = null)
        {
            string query = @"
        SELECT COUNT(*)
        FROM dbo.Schedule
        WHERE TeacherName = @TeacherName
          AND CAST(LessonDate AS DATE) = @LessonDate
          AND StartPeriod <= @EndPeriod
          AND EndPeriod >= @StartPeriod
          AND (@IgnoreId IS NULL OR Id <> @IgnoreId)";

            var parameters = new[]
            {
        new SqlParameter("@TeacherName", teacherName),
        new SqlParameter("@LessonDate", lessonDate.Date),
        new SqlParameter("@StartPeriod", startPeriod),
        new SqlParameter("@EndPeriod", endPeriod),
        new SqlParameter("@IgnoreId", (object?)ignoreScheduleId ?? DBNull.Value)
    };

            DataTable dt = GetData(query, parameters);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

    }
}