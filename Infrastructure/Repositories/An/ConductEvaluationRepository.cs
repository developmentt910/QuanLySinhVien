using System.Data;
using Microsoft.Data.SqlClient;
using System;
using StudentCourseManagement.Infrastructure.Data;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Entities;

namespace StudentCourseManagement.Infrastructure.Repositories.An // Namespace Auth
{
    public class ConductEvaluationRepository : IConductEvaluationRepository
    {
        private readonly SqlConnectionFactory _dbFactory;

        public ConductEvaluationRepository(SqlConnectionFactory dbFactory)
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

        public DataRow GetStudentInfoByCode(string studentCode)
        {
            string query = @"
                SELECT R.Id, R.FullName, C.ClassName, F.FacultyName
                FROM dbo.Users R
                LEFT JOIN dbo.Class C ON R.ClassId = C.Id
                LEFT JOIN dbo.Major M ON C.MajorId = M.Id
                LEFT JOIN dbo.Faculty F ON M.FacultyId = F.Id
                WHERE R.StudentCode = @StudentCode";

            var parameters = new[]
            {
                new SqlParameter("@StudentCode", studentCode)
            };

            DataTable dt = GetData(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }

        public List<TrainingEvaluation> GetEvaluations(Guid rosterId)
        {
            var list = new List<TrainingEvaluation>();
            string query = @"
                SELECT T.Id, T.UserId, T.SemesterId, T.Score, T.Comment, T.EvaluatedAtUtc,
                       S.SemesterName + ' (' + S.AcademicYear + ')' AS SemesterName
                FROM dbo.TrainingEvaluation T
                JOIN dbo.Semester S ON T.SemesterId = S.Id
                WHERE T.UserId = @UserId
                ORDER BY S.AcademicYear, S.SemesterName";

            var parameters = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = rosterId }
            };

            DataTable dt = GetData(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TrainingEvaluation
                {
                    Id = (Guid)row["Id"],
                    UserId = (Guid)row["UserId"],
                    SemesterId = (Guid)row["SemesterId"],
                    Score = (int)row["Score"],
                    Comment = row["Comment"]?.ToString(),
                    SemesterName = row["SemesterName"]?.ToString(),
                    EvaluatedAtUtc = (DateTime)row["EvaluatedAtUtc"]
                });
            }
            return list;
        }

        public void AddEvaluation(TrainingEvaluation eval)
        {
            string query = @"
                INSERT INTO dbo.TrainingEvaluation (Id, UserId, SemesterId, Score, Comment, EvaluatedAtUtc)
                VALUES (NEWID(), @UserId, @SemesterId, @Score, @Comment, @EvaluatedAtUtc)";

            var parameters = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = eval.UserId },
                new SqlParameter("@SemesterId", SqlDbType.UniqueIdentifier) { Value = eval.SemesterId },
                new SqlParameter("@Score", eval.Score),
                new SqlParameter("@Comment", (object)eval.Comment ?? DBNull.Value),
                new SqlParameter("@EvaluatedAtUtc", DateTime.UtcNow)
            };
            ExecuteCommand(query, parameters);
        }

        public void UpdateEvaluation(TrainingEvaluation eval)
        {
            string query = @"
                UPDATE dbo.TrainingEvaluation
                SET SemesterId = @SemesterId, Score = @Score, Comment = @Comment, EvaluatedAtUtc = @EvaluatedAtUtc
                WHERE Id = @Id";

            var parameters = new[]
            {
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = eval.Id },
                new SqlParameter("@SemesterId", SqlDbType.UniqueIdentifier) { Value = eval.SemesterId },
                new SqlParameter("@Score", eval.Score),
                new SqlParameter("@Comment", (object)eval.Comment ?? DBNull.Value),
                new SqlParameter("@EvaluatedAtUtc", DateTime.UtcNow)
            };
            ExecuteCommand(query, parameters);
        }

        public void DeleteEvaluation(Guid evaluationId)
        {
            string query = "DELETE FROM dbo.TrainingEvaluation WHERE Id = @Id";
            var parameters = new[]
            {
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = evaluationId }
            };
            ExecuteCommand(query, parameters);
        }
        public DataTable GetSemestersForEvaluation()
        {
            string query = "SELECT Id, (SemesterName + ' (' + AcademicYear + ')') AS DisplayName FROM dbo.Semester ORDER BY AcademicYear DESC, SemesterName";
            return GetData(query, null);
        }
    }
}

