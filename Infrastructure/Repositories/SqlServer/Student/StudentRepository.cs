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
        // ✅ MAP DB → ENTITY (FIX ĐẦY ĐỦ)
        // =========================
        private static Student Map(IDataRecord r)
        {
            return new Student
            {
                StudentId = r["StudentId"]?.ToString(),
                FullName = r["FullName"]?.ToString(),

                Faculty = r["Faculty"]?.ToString(),
                Major = r["Major"]?.ToString(),

                Specialization = r["Specialization"] == DBNull.Value ? "" : r["Specialization"].ToString(),
                ClassName = r["ClassName"] == DBNull.Value ? "" : r["ClassName"].ToString(),

                // ✅ BẮT BUỘC PHẢI MAP ID
                ClassId = r["ClassId"] == DBNull.Value ? null : r.GetGuid(r.GetOrdinal("ClassId")),
                MajorId = r["MajorId"] == DBNull.Value ? null : r.GetGuid(r.GetOrdinal("MajorId")),
                SpecializationId = r["SpecializationId"] == DBNull.Value ? null : r.GetGuid(r.GetOrdinal("SpecializationId")),

                Gender = r["Gender"]?.ToString(),
                Phone = r["Phone164"]?.ToString(),
                CCCD = r["CCCD"]?.ToString(),
                Email = r["EmailSchool"]?.ToString(),
                Address = r["Address"]?.ToString(),
                Status = r["Status"]?.ToString(),
                Year = r["CohortYear"]?.ToString(),
                ProfileImage = r["ProfileImage"] == DBNull.Value ? null : (byte[])r["ProfileImage"],

                PasswordHash = r["PasswordHash"]?.ToString()
            };
        }


        // =========================
        // ✅ SELECT DANH SÁCH (JOIN ĐẦY ĐỦ LỚP + CHUYÊN NGÀNH)
        // =========================
        private const string SelectListSql = @"
SELECT 
    u.StudentCode AS StudentId,
    u.FullName,
    f.FacultyName AS Faculty,
    u.ClassId,           
    u.MajorId,
    u.SpecializationId,

    m.MajorName AS Major,
    sp.SpecializationName AS Specialization,
    c.ClassCode AS ClassName,

    u.Gender,
    u.Phone164,
    u.CCCD,
    u.EmailSchool,
    u.[Address],
    u.PasswordHash,
    u.CohortYear,

    u.ProfileImage,   -- ✅ BẮT BUỘC PHẢI CÓ DÒNG NÀY

    CASE 
        WHEN u.Role = 'ALUMNI' THEN N'Đã tốt nghiệp'
        WHEN u.Role = 'PAUSED' THEN N'Bảo lưu'
        ELSE N'Đang học'
    END AS Status
FROM dbo.Users u
LEFT JOIN dbo.Class c ON c.Id = u.ClassId
LEFT JOIN dbo.Major m ON m.Id = u.MajorId
LEFT JOIN dbo.Specialization sp ON sp.Id = u.SpecializationId
LEFT JOIN dbo.Faculty f ON f.Id = m.FacultyId
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
    u.StudentCode AS StudentId,
    u.FullName,
    f.FacultyName AS Faculty,
    u.ClassId,           
    u.MajorId,
    u.SpecializationId,

    m.MajorName AS Major,
    sp.SpecializationName AS Specialization,
    c.ClassCode AS ClassName,

    u.Gender,
    u.Phone164,
    u.CCCD,
    u.EmailSchool,
    u.[Address],
    u.PasswordHash,
    u.CohortYear,
    u.ProfileImage,

    CASE 
        WHEN u.Role = 'ALUMNI' THEN N'Đã tốt nghiệp'
        WHEN u.Role = 'PAUSED' THEN N'Bảo lưu'
        ELSE N'Đang học'
    END AS Status
FROM dbo.Users u
LEFT JOIN dbo.Class c ON c.Id = u.ClassId
LEFT JOIN dbo.Major m ON m.Id = u.MajorId
LEFT JOIN dbo.Specialization sp ON sp.Id = u.SpecializationId
LEFT JOIN dbo.Faculty f ON f.Id = m.FacultyId
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
    CreatedAtUtc, UpdatedAtUtc, IsLocked
)
VALUES(
    NEWID(),
    @code,
    @fullName,
    @gender,
    @phone,
    @cccd,
    @mail,
    @addr,
    @year,
    'STUDENT',
    @password,
    @classId,
    @majorId,
    @specializationId,
    SYSUTCDATETIME(),
    SYSUTCDATETIME(),
    0
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
            cmd.Parameters.AddWithValue("@mail",
    string.IsNullOrWhiteSpace(s.Email)
        ? s.StudentId + "@epu.edu.vn"
        : s.Email);

            cmd.Parameters.AddWithValue("@addr", s.Address ?? "");
            cmd.Parameters.AddWithValue("@year", s.Year ?? "");
            cmd.Parameters.AddWithValue("@password", s.PasswordHash ?? "");

            cmd.Parameters.AddWithValue("@classId", (object?)s.ClassId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@majorId", (object?)s.MajorId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@specializationId", (object?)s.SpecializationId ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        // =========================
        // ✅ UPDATE
        // =========================
        private const string UpdateSql = @"
UPDATE dbo.Users SET
    FullName = @fullName,
    Gender = @gender,
    Phone164 = @phone,
    CCCD = @cccd,
    [Address] = @addr,
    CohortYear = @year,

    -- ✅ UPDATE MẬT KHẨU DẠNG TEXT (KHÔNG HASH)
    PasswordHash = CASE 
        WHEN @password IS NULL THEN PasswordHash 
        ELSE @password 
    END,

    ClassId = CASE 
        WHEN @classId IS NULL THEN ClassId ELSE @classId 
    END,

    MajorId = CASE 
        WHEN @majorId IS NULL THEN MajorId ELSE @majorId 
    END,

    SpecializationId = CASE 
        WHEN @specializationId IS NULL THEN SpecializationId ELSE @specializationId 
    END,
    ProfileImage = CASE 
    WHEN @img IS NULL THEN ProfileImage 
    ELSE @img 
END,


    UpdatedAtUtc = SYSUTCDATETIME()
WHERE StudentCode = @code;
";



        public void Update(Student s)
        {
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(UpdateSql, conn);

            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = s.StudentId ?? "";
            cmd.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = s.FullName ?? "";
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = s.Gender ?? "Nam";
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = s.Phone ?? "";
            cmd.Parameters.Add("@cccd", SqlDbType.VarChar).Value = s.CCCD ?? "";
            // ❌ XÓA

            cmd.Parameters.Add("@addr", SqlDbType.NVarChar).Value = s.Address ?? "";
            cmd.Parameters.Add("@year", SqlDbType.VarChar).Value = s.Year ?? "";

            // ✅ PASSWORD TEXT
            if (s.PasswordHash == null)
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = s.PasswordHash;

            cmd.Parameters.Add("@classId", SqlDbType.UniqueIdentifier).Value =
                s.ClassId.HasValue ? s.ClassId.Value : DBNull.Value;

            cmd.Parameters.Add("@majorId", SqlDbType.UniqueIdentifier).Value =
                s.MajorId.HasValue ? s.MajorId.Value : DBNull.Value;

            cmd.Parameters.Add("@specializationId", SqlDbType.UniqueIdentifier).Value =
                s.SpecializationId.HasValue ? s.SpecializationId.Value : DBNull.Value;
            cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value =
    s.ProfileImage != null ? (object)s.ProfileImage : DBNull.Value;

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine("UPDATE rows = " + rows);
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

        // =========================
        // ✅ LOAD COMBOBOX
        // =========================
        public Dictionary<Guid, string> GetFaculties() => LoadDic("SELECT Id, FacultyName FROM Faculty");

        public Dictionary<Guid, string> GetMajorsByFaculty(Guid facultyId) =>
            LoadDic("SELECT Id, MajorName FROM Major WHERE FacultyId = @id", facultyId);

        public Dictionary<Guid, string> GetSpecializationsByMajor(Guid majorId)
        {
            var dict = new Dictionary<Guid, string>();

            using var conn = _factory.Create();
            conn.Open();

            var cmd = new SqlCommand(@"
        SELECT MIN(Id) AS Id, SpecializationName
        FROM dbo.Specialization
        WHERE MajorId = @majorId
        GROUP BY SpecializationName", conn);

            cmd.Parameters.AddWithValue("@majorId", majorId);

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                dict.Add(rd.GetGuid(0), rd.GetString(1));
            }

            return dict;
        }


        private Dictionary<Guid, string> LoadDic(string sql, Guid? id = null)
        {
            var dic = new Dictionary<Guid, string>();
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(sql, conn);
            if (id != null)
                cmd.Parameters.AddWithValue("@id", id);

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                dic.Add(rd.GetGuid(0), rd.GetString(1));

            return dic;
        }
        public Dictionary<Guid, string> GetClassesBySpecialization(Guid specializationId)
        {
            var result = new Dictionary<Guid, string>();

            using var conn = _factory.Create();   // ✅ DÙNG Create(), KHÔNG PHẢI CreateConnection
            conn.Open();

            var cmd = new SqlCommand(@"
        SELECT Id, ClassCode
        FROM dbo.Class
        WHERE SpecializationId = @sid
    ", conn);

            cmd.Parameters.AddWithValue("@sid", specializationId);

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                result.Add(rd.GetGuid(0), rd.GetString(1));
            }

            return result;
        }


    }
}
