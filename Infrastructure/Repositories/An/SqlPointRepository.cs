using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentCourseManagement.Infrastructure.Repositories.An
{
    public class SqlPointRepository : IPointRepository
    {
        private readonly string _connStr;

        public SqlPointRepository()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connStr = config.GetConnectionString("DefaultConnection");
        }


        public StudentInfo GetStudentInfo(string studentCode)
        {
            using var conn = new SqlConnection(_connStr);
            string sql = @"SELECT u.Id, u.FullName, u.ClassId,
                                  c.ClassName, m.MajorName, s.SpecializationName
                           FROM Users u
                           LEFT JOIN Class c ON u.ClassId = c.Id
                           LEFT JOIN Major m ON u.MajorId = m.Id
                           LEFT JOIN Specialization s ON u.SpecializationId = s.Id
                           WHERE u.StudentCode = @MaSV";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", studentCode);
            conn.Open();
            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return null;
            return new StudentInfo
            {
                Id = Guid.Parse(rd["Id"].ToString()),

                FullName = rd["FullName"].ToString(),
                ClassId = rd["ClassId"].ToString(),
                ClassName = rd["ClassName"].ToString(),
                MajorName = rd["MajorName"].ToString(),
                SpecializationName = rd["SpecializationName"].ToString()
            };
        }

        //public List<ListItem> GetSubjectsByClass(string classId)
        //{
        //    var list = new List<ListItem>();
        //    using var conn = new SqlConnection(_connStr);
        //    string sql = @"SELECT DISTINCT s.Id AS SubjectId, s.SubjectName
        //                   FROM Schedule sch
        //                   JOIN Subject s ON sch.SubjectId = s.Id
        //                   WHERE sch.ClassId = @ClassId";
        //    using var cmd = new SqlCommand(sql, conn);
        //    cmd.Parameters.AddWithValue("@ClassId", new Guid(classId));
        //    conn.Open();
        //    using var rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        list.Add(new ListItem
        //        {
        //            Text = rd["SubjectName"].ToString(),
        //            Value = rd["SubjectId"].ToString()
        //        });
        //    }
        //    return list;
        //}

        //public string GetSemester(string classId, string subjectId)
        //{
        //    using var conn = new SqlConnection(_connStr);
        //    string sql = @"SELECT sem.SemesterName
        //                   FROM Schedule sch
        //                   JOIN Semester sem ON sch.SemesterId = sem.Id
        //                   WHERE sch.SubjectId = @SubjectId";
        //    using var cmd = new SqlCommand(sql, conn);
        //    cmd.Parameters.AddWithValue("@SubjectId", new Guid(subjectId));
        //    conn.Open();
        //    return cmd.ExecuteScalar()?.ToString();
        //}

        public StudyResult GetStudyResult(Guid userId, string subjectId)
        {
            using var conn = new SqlConnection(_connStr);
            string sql = @"SELECT Midterm, Other, Final
                           FROM StudyResult
                           WHERE UserId = @UserId AND SubjectId = @SubjectId";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@SubjectId", new Guid(subjectId));
            conn.Open();
            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return null;
            return new StudyResult
            {
                Midterm = rd["Midterm"] == DBNull.Value ? null : Convert.ToDouble(rd["Midterm"]),
                Final = rd["Final"] == DBNull.Value ? null : Convert.ToDouble(rd["Final"]),
                Other = rd["Other"] == DBNull.Value ? null : Convert.ToDouble(rd["Other"]),

            };
        }

        public void SaveResult(StudyResult result)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();

            // Kiểm tra UserId
            var cmdCheckUser = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Id=@UserId", conn);
            cmdCheckUser.Parameters.AddWithValue("@UserId", result.UserId);
            if ((int)cmdCheckUser.ExecuteScalar() == 0)
                throw new Exception($"UserId {result.UserId} chưa tồn tại trong Users!");

            // Kiểm tra SubjectId
            var cmdCheckSubj = new SqlCommand("SELECT COUNT(*) FROM Subject WHERE Id=@SubjectId", conn);
            cmdCheckSubj.Parameters.AddWithValue("@SubjectId", result.SubjectId);
            if ((int)cmdCheckSubj.ExecuteScalar() == 0)
                throw new Exception($"SubjectId {result.SubjectId} chưa tồn tại trong Subject!");

            // Tính điểm trước khi lưu
            result.ComputeGrades();

            // Insert / Update SQL
            string sql = @"
            IF EXISTS(SELECT 1 FROM StudyResult WHERE UserId=@UserId AND SubjectId=@SubjectId)
                UPDATE StudyResult
                SET Midterm=@d1, Other=@d2, Final=@d3,
                    FinalNumeric=@d4, LetterGrade=@d5, Passed=@d6,
                    UpdatedAtUtc=SYSDATETIME()
                WHERE UserId=@UserId AND SubjectId=@SubjectId
            ELSE
                INSERT INTO StudyResult(Id, UserId, SubjectId, Midterm, Other, Final,
                                        FinalNumeric, LetterGrade, Passed, UpdatedAtUtc)
                VALUES(NEWID(), @UserId, @SubjectId, @d1, @d2, @d3, @d4, @d5, @d6, SYSDATETIME())";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", result.UserId);
            cmd.Parameters.AddWithValue("@SubjectId", result.SubjectId);
            cmd.Parameters.AddWithValue("@d1", result.Midterm ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@d2", result.Other ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@d3", result.Final ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@d4", result.FinalNumeric ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@d5", (object?)result.LetterGrade ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d6", result.Passed ?? (object)DBNull.Value);

            cmd.ExecuteNonQuery();
        }


        //public List<ListItem> GetSemestersByClass(string classId)
        //{
        //    var result = new List<ListItem>();
        //    using var conn = new SqlConnection(_connStr);
        //    conn.Open();
        //    var cmd = new SqlCommand(@"
        //    SELECT DISTINCT s.Id, s.SemesterName
        //    FROM Semester s
        //    INNER JOIN Schedule sch ON sch.SemesterId = s.Id
        //    WHERE sch.ClassId = @ClassId
        //    ORDER BY s.SemesterName", conn);
        //    cmd.Parameters.AddWithValue("@ClassId", new Guid(classId));

        //    using var rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //        result.Add(new ListItem
        //        {
        //            Text = rd["SemesterName"].ToString(),
        //            Value = rd["Id"].ToString()
        //        });
        //    return result;
        //}


        //public List<ListItem> GetSubjectsBySemester(string classId, string semesterId)
        //{
        //    var result = new List<ListItem>();
        //    using var conn = new SqlConnection(_connStr);
        //    conn.Open();
        //    var cmd = new SqlCommand(@"
        //SELECT subj.Id, subj.SubjectName
        //FROM Subject subj
        //INNER JOIN Schedule sch ON sch.SubjectId = subj.Id
        //WHERE sch.ClassId = @ClassId AND sch.SemesterId = @SemesterId", conn);
        //    cmd.Parameters.AddWithValue("@ClassId", new Guid(classId));
        //    cmd.Parameters.AddWithValue("@SemesterId", new Guid(semesterId));

        //    using var rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //        result.Add(new ListItem
        //        {
        //            Text = rd["SubjectName"].ToString(),
        //            Value = rd["Id"].ToString()
        //        });
        //    return result;
        //}

        //public List<String> GetSemesterByCohortYear(int cohortYeah)
        //{
        //   String sql = "Select SemesterCode"
        //}
        public List<string> GetSemestersForStudent(int cohortYear)
        {
            var list = new List<string>();

            string sql = @"
        SELECT SemesterCode
        FROM Semester
        WHERE 
            CAST(LEFT(AcademicYear, 4) AS INT) >= @CohortYear
            AND CAST(LEFT(AcademicYear, 4) AS INT) <= YEAR(GETDATE())
        ORDER BY AcademicYear, SemesterCode;
    ";

            using (SqlConnection conn = new SqlConnection(_connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@CohortYear", SqlDbType.Int).Value = cohortYear;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(reader.GetOrdinal("SemesterCode")));
                    }
                }
            }

            return list; 
        }

        public int GetCohortYearFromUser(Guid userId)
        {
            int cohortYear = 0;
            string sql = "SELECT CohortYear FROM Users WHERE Id = @UserId";

            using (SqlConnection conn = new SqlConnection(_connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                    cohortYear = Convert.ToInt32(result);
            }

            return cohortYear;
        }

        public List<ResultSubjectDto> GetSubjectsForSemester(Guid specializationId, string semesterCode, string studentCode)
        {
            var list = new List<ResultSubjectDto>();

            string sql = @"
SELECT 
    sb.Id AS SubjectId,
    sb.SubjectName,
    sb.Credit,
    cl.Id AS ClassId,
    cl.ClassCode AS ClassName
FROM Curriculum cu
JOIN Subject sb ON sb.Id = cu.SubjectId
JOIN Users u ON u.StudentCode = @StudentCode
JOIN Class cl ON cl.Id = u.ClassId
WHERE cu.Semester = @SemesterCode
  AND cu.SpecializationId = @SpecializationId
ORDER BY sb.SubjectName

";

            using (SqlConnection conn = new SqlConnection(_connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@StudentCode", SqlDbType.NVarChar, 50).Value = studentCode;
                cmd.Parameters.Add("@SemesterCode", SqlDbType.NVarChar, 50).Value = semesterCode;
                cmd.Parameters.Add("@SpecializationId", SqlDbType.UniqueIdentifier).Value = specializationId;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dto = new ResultSubjectDto
                        {
                            SubjectId = reader.GetGuid(reader.GetOrdinal("SubjectId")),
                            SubjectName = reader["SubjectName"].ToString(),
                            Credits = Convert.ToInt32(reader["Credit"]),
                            ClassId = reader.GetGuid(reader.GetOrdinal("ClassId")),
                            ClassName = reader["ClassName"].ToString()
                        };
                        list.Add(dto);
                    }
                }
            }

            return list;
        }


    }
}
