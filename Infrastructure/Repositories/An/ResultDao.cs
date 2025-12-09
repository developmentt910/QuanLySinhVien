using StudentCourseManagement.Applications.Dtos.Dtos;
using StudentCourseManagement.Applications.Curriculum;
using StudentCourseManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentCourseManagement.Infrastructure.Repositories.An
{
    public class ResultDao
    {
        private readonly SqlConnectionFactory _conn;

        public ResultDao(SqlConnectionFactory conn)
        {
            _conn = conn;
        }

        private SqlConnection CreateConnection()
            => _conn.Create();

        public List<CurriculumSubjectDto> GetSubjectsForSemester(
    Guid specializationId,
    string semesterCode)
        {
            var list = new List<CurriculumSubjectDto>();

            using (SqlConnection con = CreateConnection())
            {
                con.Open();

                string query = @"
            SELECT 
                s.Id AS SubjectId,
                s.SubjectName,
                s.Credit
            FROM Curriculum cs
            JOIN Subject s ON cs.SubjectId = s.Id
            WHERE cs.SpecializationId = @spec
              AND cs.Semester = @sem";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@spec", specializationId);
                cmd.Parameters.AddWithValue("@sem", semesterCode);

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new CurriculumSubjectDto
                        {
                            SubjectId = rd.GetGuid(rd.GetOrdinal("SubjectId")),
                            SubjectName = rd["SubjectName"].ToString(),
                            ClassName = "",        // Không tồn tại trong DB
                            Credits = Convert.ToInt32(rd["Credit"])
                        });
                    }
                }
            }

            return list;
        }


        // =============== FIND STUDENT ====================
        public StudentDtos FindByMSV(string msv)
        {
            using (SqlConnection con = CreateConnection())
            {
                con.Open();

                string query = @"
    SELECT 
    u.Id,
    u.StudentCode,
    u.FullName,
    u.Gender,
    u.Address,
    u.CohortYear,

    c.ClassName,
    m.MajorName,
    sp.SpecializationName,
    f.FacultyName,

    u.ClassId,
    u.MajorId,
    u.SpecializationId,
    u.FacultyId
FROM Users u
LEFT JOIN Class c ON u.ClassId = c.Id
LEFT JOIN Major m ON u.MajorId = m.Id
LEFT JOIN Specialization sp ON u.SpecializationId = sp.Id
LEFT JOIN Faculty f ON u.FacultyId = f.Id
WHERE u.StudentCode = @msv;
";


                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@msv", msv);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read()) return null;

                        return new StudentDtos
                        {
                            Id = rd.GetGuid(rd.GetOrdinal("Id")),
                            StudentCode = rd["StudentCode"]?.ToString(),
                            FullName = rd["FullName"]?.ToString(),
                            Gender = rd["Gender"]?.ToString(),
                            Address = rd["Address"]?.ToString(),

                            CohortYear = rd.IsDBNull(rd.GetOrdinal("CohortYear"))
                    ? null
                    : rd.GetInt32(rd.GetOrdinal("CohortYear")),

                            ClassName = rd.IsDBNull(rd.GetOrdinal("ClassName"))
                    ? null
                    : rd["ClassName"].ToString(),

                            MajorName = rd.IsDBNull(rd.GetOrdinal("MajorName"))
                    ? null
                    : rd["MajorName"].ToString(),

                            SpecializationName = rd.IsDBNull(rd.GetOrdinal("SpecializationName"))
                    ? null
                    : rd["SpecializationName"].ToString(),

                            FacultyName = rd.IsDBNull(rd.GetOrdinal("FacultyName"))
                    ? null
                    : rd["FacultyName"].ToString(),

                            ClassId = rd.IsDBNull(rd.GetOrdinal("ClassId"))
                    ? Guid.Empty
                    : rd.GetGuid(rd.GetOrdinal("ClassId")),

                            MajorId = rd.IsDBNull(rd.GetOrdinal("MajorId"))
                    ? Guid.Empty
                    : rd.GetGuid(rd.GetOrdinal("MajorId")),

                            SpecializationId = rd.IsDBNull(rd.GetOrdinal("SpecializationId"))
                    ? Guid.Empty
                    : rd.GetGuid(rd.GetOrdinal("SpecializationId")),

                            FacultyId = rd.IsDBNull(rd.GetOrdinal("FacultyId"))
                    ? Guid.Empty
                    : rd.GetGuid(rd.GetOrdinal("FacultyId")),
                        };

                    }
                }
            }
        }


        // =============== GET SEMESTERS ====================
        public List<string> GetSemestersForStudent(int? cohortYear)
        {
            var list = new List<string>();

            if (cohortYear == null)
                return list;

            using (SqlConnection con = CreateConnection())
            {
                con.Open();

                string query = @"
            SELECT SemesterCode
            FROM Semester
            WHERE LEFT(AcademicYear, 4) >= @startYear 
              AND LEFT(AcademicYear, 4) <= @endYear
            ORDER BY SemesterCode";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@startYear", cohortYear.Value);
                cmd.Parameters.AddWithValue("@endYear", DateTime.Now.Year);

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(rd["SemesterCode"].ToString());
                }
            }

            return list;
        }


        // =============== GET SUBJECTS ====================
        public List<CurriculumSubjectDto> GetSubjectsForStudent(Guid specializationId)
        {
            var list = new List<CurriculumSubjectDto>();

            using (SqlConnection con = CreateConnection())
            {
                con.Open();

                string query = @"
                    SELECT s.Id AS SubjectId, s.SubjectName, cs.ClassName, s.Credits
                    FROM Curriculum cs
                    JOIN Subject s ON cs.SubjectId = s.Id
                    WHERE cs.SpecializationId = @specId";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@specId", specializationId);

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new CurriculumSubjectDto
                        {
                            SubjectId = rd.GetGuid(rd.GetOrdinal("SubjectId")),
                            SubjectName = rd["SubjectName"].ToString(),
                            ClassName = rd["ClassName"].ToString(),
                            Credits = Convert.ToInt32(rd["Credits"])
                        });
                    }
                }
            }

            return list;
        }

        // =============== GET SAVED SCORES ====================
        public List<ResultSubjectDto> GetSavedScores(Guid userId)
        {
            var list = new List<ResultSubjectDto>();

            using (SqlConnection con = CreateConnection())
            {
                con.Open();

                string query = @"
                    SELECT *
                    FROM StudyResult
                    WHERE UserId = @uid
                    ORDER BY UpdatedAtUtc DESC";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uid", userId);

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new ResultSubjectDto
                        {
                            Id = rd.GetGuid(rd.GetOrdinal("Id")),
                            UserId = userId,
                            SubjectId = rd.GetGuid(rd.GetOrdinal("SubjectId")),

                            Midterm = rd.IsDBNull(rd.GetOrdinal("Midterm"))
                                ? null : (float?)Convert.ToSingle(rd["Midterm"]),

                            Other = rd.IsDBNull(rd.GetOrdinal("Other"))
                                ? null : (float?)Convert.ToSingle(rd["Other"]),

                            Final = rd.IsDBNull(rd.GetOrdinal("Final"))
                                ? null : (float?)Convert.ToSingle(rd["Final"]),

                            FinalNumeric = rd.IsDBNull(rd.GetOrdinal("FinalNumeric"))
                                ? null : (float?)Convert.ToSingle(rd["FinalNumeric"]),

                            LetterGrade = rd.IsDBNull(rd.GetOrdinal("LetterGrade"))
                                ? null : rd["LetterGrade"].ToString(),

                            Passed = rd.IsDBNull(rd.GetOrdinal("Passed"))
                                ? null : (bool?)rd.GetBoolean(rd.GetOrdinal("Passed")),

                            UpdatedAtUtc = rd["UpdatedAtUtc"] as DateTime?
                        });
                    }

            }
            }

            return list;
        }

        // =============== FIND SUBJECT ID ====================
        public Guid FindSubjectIdByName(string subjectName)
        {
            using (SqlConnection con = CreateConnection())
            {
                con.Open();

                string query = @"SELECT TOP 1 Id FROM Subject WHERE SubjectName = @name";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", subjectName);

                object result = cmd.ExecuteScalar();
                return result == null ? Guid.Empty : (Guid)result;
            }
        }

        // =============== SAVE SCORE ====================
        public void SaveScore(ResultSubjectDto dto)
        {
            using (SqlConnection con = CreateConnection())
            {
                con.Open();

                string query = @"
                    MERGE StudyResult AS t
                    USING (SELECT @uid AS UserId, @sub AS SubjectId) AS s
                    ON t.UserId = s.UserId AND t.SubjectId = s.SubjectId

                    WHEN MATCHED THEN 
                        UPDATE SET 
                            Midterm = @mid,
                            Final = @final,
                            Other = @other,
                            FinalNumeric = @numeric,
                            LetterGrade = @letter,
                            Passed = @pass,
                            UpdatedAtUtc = GETUTCDATE()

                    WHEN NOT MATCHED THEN
                        INSERT (Id, UserId, SubjectId, Midterm, Final, Other, FinalNumeric, LetterGrade, Passed, UpdatedAtUtc)
                        VALUES (NEWID(), @uid, @sub, @mid, @final, @other, @numeric, @letter, @pass, GETUTCDATE());
                ";

                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@uid", dto.UserId);
                cmd.Parameters.AddWithValue("@sub", dto.SubjectId);
                cmd.Parameters.AddWithValue("@mid", (object)dto.Midterm ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@final", (object)dto.Final ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@other", (object)dto.Other ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@numeric", (object)dto.FinalNumeric ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@letter", (object)dto.LetterGrade ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pass", (object)dto.Passed ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteScore(Guid userId, Guid subjectId)
        {
            using (SqlConnection con = CreateConnection())
            {
                con.Open();

                string sql = @"
            DELETE FROM StudyResult
            WHERE UserId = @uid AND SubjectId = @sub
        ";

                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@uid", userId);
                cmd.Parameters.AddWithValue("@sub", subjectId);

                cmd.ExecuteNonQuery();
            }
        }


    }
}
