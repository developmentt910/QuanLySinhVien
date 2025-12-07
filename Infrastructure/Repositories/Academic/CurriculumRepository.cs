using System.Data;
using Microsoft.Data.SqlClient;
using System;
using StudentCourseManagement.Infrastructure.Data;
using StudentCourseManagement.Domain.Abstractions.Repositories;

namespace StudentCourseManagement.Infrastructure.Repositories.Academic
{
    public class CurriculumRepository : ICurriculumRepository
    {
        private readonly SqlConnectionFactory _dbFactory;

        public CurriculumRepository(SqlConnectionFactory dbFactory)
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
                            cmd.Parameters.AddRange(parameters);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetCurriculumDetails(Guid specializationId, string semester)
        {
            string query = @"
                SELECT 
                    c.Id AS CurriculumId, 
                    s.Id AS SubjectId, 
                    s.SubjectCode, 
                    s.SubjectName, 
                    s.Credit, 
                    s.LectureHours, 
                    s.PracticeHours 
                FROM 
                    dbo.Curriculum c
                JOIN 
                    dbo.Subject s ON c.SubjectId = s.Id
                WHERE 
                    c.SpecializationId = @SpecializationId AND c.Semester = @Semester
                ORDER BY s.SubjectName";

            var parameters = new[]
            {
                new SqlParameter("@SpecializationId", SqlDbType.UniqueIdentifier) { Value = specializationId },
                new SqlParameter("@Semester", semester)
            };
            return GetData(query, parameters);
        }

        public void AddSubjectToCurriculum(Guid specializationId, Guid subjectId, string semester)
        {
            string query = @"
                INSERT INTO dbo.Curriculum 
                    (Id, SpecializationId, SubjectId, Semester) 
                VALUES 
                    (NEWID(), @SpecializationId, @SubjectId, @Semester)";

            var parameters = new[]
            {
                new SqlParameter("@SpecializationId", SqlDbType.UniqueIdentifier) { Value = specializationId },
                new SqlParameter("@SubjectId", SqlDbType.UniqueIdentifier) { Value = subjectId },
                new SqlParameter("@Semester", semester)
            };
            ExecuteCommand(query, parameters);
        }

        public void RemoveSubjectFromCurriculum(Guid curriculumId)
        {
            string query = "DELETE FROM dbo.Curriculum WHERE Id = @Id";
            var parameters = new[]
            {
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = curriculumId }
            };
            ExecuteCommand(query, parameters);
        }
    }
}