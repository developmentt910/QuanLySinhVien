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
    WHERE u.StudentCode = @msv";


                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@msv", msv);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read()) return null;

                        return new StudentDtos
                        {
                            Id = rd.GetGuid(rd.GetOrdinal("Id")),
                            StudentCode = rd["StudentCode"].ToString(),
                            FullName = rd["FullName"].ToString(),
                            Gender = rd["Gender"].ToString(),
                            Address = rd["Address"].ToString(),
                            CohortYear = rd["CohortYear"] as int?,

                            ClassName = rd["ClassName"]?.ToString(),
                            MajorName = rd["MajorName"]?.ToString(),
                            SpecializationName = rd["SpecializationName"]?.ToString(),
                            FacultyName = rd["FacultyName"]?.ToString(),

                            ClassId = rd.GetGuid(rd.GetOrdinal("ClassId")),
                            MajorId = rd.GetGuid(rd.GetOrdinal("MajorId")),
                            SpecializationId = rd.GetGuid(rd.GetOrdinal("SpecializationId")),
                            FacultyId = rd.GetGuid(rd.GetOrdinal("FacultyId"))
                        };
                    }
                }
            }
        }


        // =============== GET SEMESTERS ====================
        public List<string> GetSemestersForStudent(int? cohortYear)
        {
            var list = new List<string>();

            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                string query = @"
                    SELECT SemesterCode
                    FROM Semesters
                    WHERE CohortYear = @year
                    ORDER BY SemesterCode";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@year", cohortYear);

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
                    JOIN Subjects s ON cs.SubjectId = s.Id
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
                            Midterm = rd["Midterm"] as float?,
                            Final = rd["Final"] as float?,
                            Other = rd["Other"] as float?,
                            FinalNumeric = rd["FinalNumeric"] as float?,
                            LetterGrade = rd["LetterGrade"]?.ToString(),
                            Passed = rd["Passed"] as bool?,
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

                string query = @"SELECT TOP 1 Id FROM Subjects WHERE SubjectName = @name";

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
    }
}
