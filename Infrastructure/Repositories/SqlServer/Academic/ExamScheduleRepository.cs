using System.Data;
using System.Data.SqlClient;
using System;
using StudentCourseManagement.Infrastructure.Data;
using StudentCourseManagement.Domain.Abstractions.Repositories;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Academic
{
    public class ExamScheduleRepository : IExamScheduleRepository
    {
        private readonly SqlConnectionFactory _dbFactory;

        public ExamScheduleRepository(SqlConnectionFactory dbFactory)
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
                System.Windows.Forms.MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi CSDL", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                System.Windows.Forms.MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi CSDL", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public DataTable GetExamSchedules()
        {
            string query = @"
                SELECT 
                    lt.Id, lt.ClassId, lt.SubjectId, lt.SemesterId,
                    sub.SubjectName,
                    (sem.SemesterName + ' (' + sem.AcademicYear + ')') AS SemesterDisplayName,
                    c.ClassName,
                    lt.Room, 
                    lt.ExamDate, 
                    lt.ExamDuration,
                    lt.ExamType,
                    c.SpecializationId, s.MajorId, m.FacultyId
                FROM 
                    dbo.ExamSchedule lt
                LEFT JOIN dbo.Class c ON lt.ClassId = c.Id
                LEFT JOIN dbo.Specialization s ON c.SpecializationId = s.Id
                LEFT JOIN dbo.Major m ON s.MajorId = m.Id
                LEFT JOIN dbo.Subject sub ON lt.SubjectId = sub.Id
                LEFT JOIN dbo.Semester sem ON lt.SemesterId = sem.Id
                ORDER BY lt.ExamDate, sub.SubjectName";

            return GetData(query);
        }

        public void AddExamSchedule(Guid classId, Guid subjectId, Guid semesterId, string room, DateTime examDate, int examDuration, string examType)
        {
            string query = @"
                INSERT INTO dbo.ExamSchedule 
                    (Id, ClassId, SubjectId, SemesterId, Room, ExamDate, ExamDuration, ExamType)
                VALUES 
                    (NEWID(), @ClassId, @SubjectId, @SemesterId, @Room, @ExamDate, @ExamDuration, @ExamType)";

            var parameters = new[]
            {
                new SqlParameter("@ClassId", SqlDbType.UniqueIdentifier) { Value = classId },
                new SqlParameter("@SubjectId", SqlDbType.UniqueIdentifier) { Value = subjectId },
                new SqlParameter("@SemesterId", SqlDbType.UniqueIdentifier) { Value = semesterId },
                new SqlParameter("@Room", room),
                new SqlParameter("@ExamDate", examDate),
                new SqlParameter("@ExamDuration", examDuration),
                new SqlParameter("@ExamType", examType)
            };
            ExecuteCommand(query, parameters);
        }

        public void UpdateExamSchedule(Guid examId, Guid classId, Guid subjectId, Guid semesterId, string room, DateTime examDate, int examDuration, string examType)
        {
            string query = @"
                UPDATE dbo.ExamSchedule 
                SET 
                    ClassId = @ClassId, 
                    SubjectId = @SubjectId, 
                    SemesterId = @SemesterId, 
                    Room = @Room, 
                    ExamDate = @ExamDate, 
                    ExamDuration = @ExamDuration, 
                    ExamType = @ExamType
                WHERE 
                    Id = @Id";

            var parameters = new[]
            {
                new SqlParameter("@ClassId", SqlDbType.UniqueIdentifier) { Value = classId },
                new SqlParameter("@SubjectId", SqlDbType.UniqueIdentifier) { Value = subjectId },
                new SqlParameter("@SemesterId", SqlDbType.UniqueIdentifier) { Value = semesterId },
                new SqlParameter("@Room", room),
                new SqlParameter("@ExamDate", examDate),
                new SqlParameter("@ExamDuration", examDuration),
                new SqlParameter("@ExamType", examType),
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = examId }
            };
            ExecuteCommand(query, parameters);
        }

        public void RemoveExamSchedule(Guid examId)
        {
            string query = "DELETE FROM dbo.ExamSchedule WHERE Id = @Id";
            var parameters = new[]
            {
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = examId }
            };
            ExecuteCommand(query, parameters);
        }
    }
}