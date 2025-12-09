using Microsoft.Data.SqlClient;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace StudentCourseManagement.Infrastructure.Repositories
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
            var dt = new DataTable();

            try
            {
                using var conn = _dbFactory.Create();
                conn.Open();

                using var cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                new SqlDataAdapter(cmd).Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }

            return dt;
        }

        private void Execute(string query, SqlParameter[] parameters)
        {
            try
            {
                using var conn = _dbFactory.Create();
                conn.Open();

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message);
            }
        }

        public DataRow GetStudentInfoByCode(string studentCode)
        {
            string query = @"
                SELECT R.Id, R.FullName, C.ClassName, F.FacultyName, R.CohortYear
                FROM Users R
                LEFT JOIN Class C ON R.ClassId = C.Id
                LEFT JOIN Major M ON C.MajorId = M.Id
                LEFT JOIN Faculty F ON M.FacultyId = F.Id
                WHERE R.StudentCode = @Code";

            var dt = GetData(query, new[] { new SqlParameter("@Code", studentCode) });

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataTable GetSemestersForEvaluation(Guid userId)
        {
            string queryGetYear = "SELECT CohortYear FROM Users WHERE Id = @Id";

            var dtYear = GetData(queryGetYear, new[] {
                new SqlParameter("@Id", userId)
            });

            if (dtYear.Rows.Count == 0)
                return new DataTable();

            int startYear = Convert.ToInt32(dtYear.Rows[0]["CohortYear"]);
            int currentYear = DateTime.Now.Year;

            string querySemester = @"
                SELECT Id,
                       SemesterName + ' (' + AcademicYear + ')' AS DisplayName
                FROM Semester
                WHERE CAST(SUBSTRING(AcademicYear, 1, 4) AS INT) BETWEEN @StartYear AND @CurrentYear
                ORDER BY AcademicYear DESC, SemesterName";

            return GetData(querySemester, new[]
            {
                new SqlParameter("@StartYear", startYear),
                new SqlParameter("@CurrentYear", currentYear)
            });
        }

        public List<TrainingEvaluation> GetEvaluations(Guid userId)
        {
            string query = @"
                SELECT T.Id, T.UserId, T.SemesterId, T.Score, T.Comment, T.EvaluatedAtUtc,
                       S.SemesterName + ' (' + S.AcademicYear + ')' AS SemesterName
                FROM TrainingEvaluation T
                JOIN Semester S ON T.SemesterId = S.Id
                WHERE T.UserId = @User
                ORDER BY S.AcademicYear DESC, S.SemesterName";

            var table = GetData(query, new[] {
                new SqlParameter("@User", userId)
            });

            var list = new List<TrainingEvaluation>();

            foreach (DataRow r in table.Rows)
            {
                list.Add(new TrainingEvaluation
                {
                    Id = (Guid)r["Id"],
                    UserId = (Guid)r["UserId"],
                    SemesterId = (Guid)r["SemesterId"],
                    Score = (int)r["Score"],
                    Comment = r["Comment"]?.ToString(),
                    SemesterName = r["SemesterName"].ToString(),
                    EvaluatedAtUtc = (DateTime)r["EvaluatedAtUtc"]
                });
            }

            return list;
        }

        public void AddEvaluation(TrainingEvaluation eval)
        {
            string q = @"
                INSERT INTO TrainingEvaluation (Id, UserId, SemesterId, Score, Comment, EvaluatedAtUtc)
                VALUES (NEWID(), @UserId, @SemId, @Score, @Comment, @Time)";

            Execute(q, new[]
            {
                new SqlParameter("@UserId", eval.UserId),
                new SqlParameter("@SemId", eval.SemesterId),
                new SqlParameter("@Score", eval.Score),
                new SqlParameter("@Comment", (object)eval.Comment ?? DBNull.Value),
                new SqlParameter("@Time", DateTime.UtcNow)
            });
        }

        public void UpdateEvaluation(TrainingEvaluation eval)
        {
            string q = @"
                UPDATE TrainingEvaluation
                SET SemesterId = @SemId, Score = @Score, Comment = @Comment, EvaluatedAtUtc = @Time
                WHERE Id = @Id";

            Execute(q, new[]
            {
                new SqlParameter("@Id", eval.Id),
                new SqlParameter("@SemId", eval.SemesterId),
                new SqlParameter("@Score", eval.Score),
                new SqlParameter("@Comment", (object)eval.Comment ?? DBNull.Value),
                new SqlParameter("@Time", DateTime.UtcNow)
            });
        }

        public void DeleteEvaluation(Guid evaluationId)
        {
            string q = "DELETE FROM TrainingEvaluation WHERE Id = @Id";

            Execute(q, new[]
            {
                new SqlParameter("@Id", evaluationId)
            });
        }
    }
}
