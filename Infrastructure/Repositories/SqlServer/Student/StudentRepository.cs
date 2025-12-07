using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Domain.Abstractions.Repositories;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer
{
    public sealed class StudentRepository : IStudentRepository
    {
        private readonly SqlConnectionFactory _factory;

        public StudentRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        // =========================
        // ✅ MAP DB → ENTITY (KHỚP 100% dbo.Users)
        // =========================
        private static Student Map(IDataRecord r)
        {
            return new Student
            {
                StudentId = r["StudentId"]?.ToString(),
                FullName = r["FullName"]?.ToString(),
                Major = r["Major"]?.ToString(),
                Specialization = r["Specialization"]?.ToString(),
                ClassName = r["ClassName"]?.ToString(),
                Gender = r["Gender"]?.ToString(),

                Phone = r["Phone164"]?.ToString(),      // ✅ CỘT ĐÚNG
                CCCD = r["CCCD"]?.ToString(),
                Email = r["EmailSchool"]?.ToString(),   // ✅ CỘT ĐÚNG

                Address = r["Address"]?.ToString(),
                Status = r["Status"]?.ToString(),
                Year = r["CohortYear"]?.ToString()
            };
        }

        // =========================
        // ✅ SELECT DANH SÁCH SINH VIÊN (CHUẨN)
        // =========================
        private const string SelectListSql = @"
SELECT 
    u.StudentCode        AS StudentId,
    u.FullName,
    m.MajorName          AS Major,
    sp.SpecializationName AS Specialization,
    c.ClassCode          AS ClassName,
    u.Gender,
    u.Phone164,
    u.CCCD,
    u.EmailSchool,
    u.[Address],
    u.CohortYear,
    CASE 
        WHEN u.Role = 'ALUMNI' THEN N'Đã tốt nghiệp'
        WHEN u.Role = 'PAUSED' THEN N'Bảo lưu'
        ELSE N'Đang học'
    END AS Status
FROM dbo.Users u
LEFT JOIN dbo.Major           m  ON m.Id  = u.MajorId
LEFT JOIN dbo.Specialization sp ON sp.Id = u.SpecializationId
LEFT JOIN dbo.Class           c  ON c.Id  = u.ClassId
ORDER BY u.StudentCode;
";

        public List<Student> GetAll()
        {
            var list = new List<Student>();
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(SelectListSql, conn);
            using var rd = cmd.ExecuteReader();

            while (rd.Read())
                list.Add(Map(rd));

            return list;
        }

        // =========================
        // ✅ SELECT 1 SINH VIÊN
        // =========================
        private const string SelectOneSql = @"
SELECT 
    u.StudentCode        AS StudentId,
    u.FullName,
    m.MajorName          AS Major,
    sp.SpecializationName AS Specialization,
    c.ClassCode          AS ClassName,
    u.Gender,
    u.Phone164,
    u.CCCD,
    u.EmailSchool,
    u.[Address],
    u.CohortYear,
    CASE 
        WHEN u.Role = 'ALUMNI' THEN N'Đã tốt nghiệp'
        WHEN u.Role = 'PAUSED' THEN N'Bảo lưu'
        ELSE N'Đang học'
    END AS Status
FROM dbo.Users u
LEFT JOIN dbo.Major           m  ON m.Id  = u.MajorId
LEFT JOIN dbo.Specialization sp ON sp.Id = u.SpecializationId
LEFT JOIN dbo.Class           c  ON c.Id  = u.ClassId
WHERE u.StudentCode = @id;
";

        public Student? GetById(string studentId)
        {
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(SelectOneSql, conn);
            cmd.Parameters.AddWithValue("@id", studentId);

            using var rd = cmd.ExecuteReader();
            return rd.Read() ? Map(rd) : null;
        }

        // =========================
        // ✅ HASH MẬT KHẨU
        // =========================
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var sb = new StringBuilder();
            foreach (var b in bytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        // =========================
        // ✅ INSERT
        // =========================
        private const string InsertSql = @"
INSERT INTO dbo.Users(
    Id, StudentCode, FullName, Gender, Phone164, CCCD, EmailSchool, [Address],
    CohortYear, Role, PasswordHash,
    ClassId, MajorId, SpecializationId,
    CreatedAtUtc, UpdatedAtUtc, IsLocked, EmailVerified
)
VALUES(
    NEWID(), @code, @fullName, @gender, @phone, @cccd, @mail, @addr,
    @year, @role, @password,
    @classId, @majorId, @specializationId,
    SYSUTCDATETIME(), SYSUTCDATETIME(), 0, 0
);";

        public void Add(Student s)
        {
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(InsertSql, conn);
            cmd.Parameters.AddWithValue("@code", s.StudentId ?? "");
            cmd.Parameters.AddWithValue("@fullName", s.FullName ?? "");
            cmd.Parameters.AddWithValue("@gender", s.Gender ?? "Nam");
            cmd.Parameters.AddWithValue("@phone", s.Phone ?? "");
            cmd.Parameters.AddWithValue("@cccd", s.CCCD ?? "");
            cmd.Parameters.AddWithValue("@mail", s.Email ?? "");
            cmd.Parameters.AddWithValue("@addr", s.Address ?? "");
            cmd.Parameters.AddWithValue("@year", s.Year ?? "");
            cmd.Parameters.AddWithValue("@role", "STUDENT");
            cmd.Parameters.AddWithValue("@password", s.PasswordHash ?? HashPassword("123456"));

            cmd.Parameters.AddWithValue("@classId", DBNull.Value);
            cmd.Parameters.AddWithValue("@majorId", DBNull.Value);
            cmd.Parameters.AddWithValue("@specializationId", DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        // =========================
        // ✅ UPDATE
        // =========================
        private const string UpdateSql = @"
UPDATE dbo.Users SET
    FullName     = @fullName,
    Gender       = @gender,
    Phone164     = @phone,
    CCCD         = @cccd,
    EmailSchool  = @mail,
    [Address]    = @addr,
    CohortYear   = @year,
    UpdatedAtUtc = SYSUTCDATETIME()
WHERE StudentCode = @code;
";

        public void Update(Student s)
        {
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(UpdateSql, conn);
            cmd.Parameters.AddWithValue("@code", s.StudentId ?? "");
            cmd.Parameters.AddWithValue("@fullName", s.FullName ?? "");
            cmd.Parameters.AddWithValue("@gender", s.Gender ?? "Nam");
            cmd.Parameters.AddWithValue("@phone", s.Phone ?? "");
            cmd.Parameters.AddWithValue("@cccd", s.CCCD ?? "");
            cmd.Parameters.AddWithValue("@mail", s.Email ?? "");
            cmd.Parameters.AddWithValue("@addr", s.Address ?? "");
            cmd.Parameters.AddWithValue("@year", s.Year ?? "");

            cmd.ExecuteNonQuery();
        }

        // =========================
        // ✅ DELETE
        // =========================
        private const string DeleteSql = @"DELETE FROM dbo.Users WHERE StudentCode = @code;";

        public void Delete(string studentId)
        {
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(DeleteSql, conn);
            cmd.Parameters.AddWithValue("@code", studentId);
            cmd.ExecuteNonQuery();
        }
    }
}
