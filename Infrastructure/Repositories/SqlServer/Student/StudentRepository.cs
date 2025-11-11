using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Infrastructure.Data; // SqlConnectionFactory
using System.Security.Cryptography;
using System.Text;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer
{
    public sealed class StudentRepository : IStudentRepository
    {
        private readonly SqlConnectionFactory _factory;

        public StudentRepository(SqlConnectionFactory factory)
        {
            _factory = factory ;
        }

        // Map 1 dòng DataReader -> Student entity (khớp UI)
        private static Student Map(IDataRecord r)
        {
            return new Student
            {
                // UI đang dùng StudentId là “mã SV”, trong DB là StudentCode
                StudentId = r["StudentId"]?.ToString() ?? "",
                FullName = r["FullName"]?.ToString() ?? "",
                Major = r["Major"]?.ToString() ?? "",             // tên ngành
                Specialization = r["Specialization"]?.ToString() ?? "",    // tên chuyên ngành
                ClassName = r["ClassName"]?.ToString() ?? "",         // mã lớp
                Gender = r["Gender"]?.ToString() ?? "",
                Phone = r["Phone"]?.ToString() ?? "",
                CCCD = r["CCCD"]?.ToString() ?? "",
                Email = r["Email"]?.ToString() ?? "",
                Address = r["Address"]?.ToString() ?? "",
                Status = r["Status"]?.ToString() ?? "",
                Year = r["Year"]?.ToString() ?? ""
            };
        }

        // Câu SELECT phục vụ UI (không có tham số @name)
        private const string SelectListSql = @"
SELECT 
    u.StudentCode                    AS StudentId,
    u.FullName,
    m.MajorName                      AS Major,            -- sửa nếu cột khác tên
    s.SpecializationName             AS Specialization,   -- sửa nếu cột khác tên (vd: Name)
    c.ClassCode                      AS ClassName,        -- sửa nếu cột khác tên (vd: ClassName)
    u.Gender,
    u.PhoneE164                      AS Phone,
    u.CCCD,
    u.EmailNormalized                AS Email,
    u.[Address]                      AS [Address],
    CASE 
        WHEN u.Role = 'ALUMNI' THEN N'Đã tốt nghiệp'
        WHEN u.Role = 'PAUSED' THEN N'Bảo lưu'
        ELSE N'Đang học'
    END                               AS Status,
    u.CohortYear                     AS [Year]
FROM dbo.Users u
LEFT JOIN dbo.Major          m ON m.Id = u.MajorId
LEFT JOIN dbo.Specialization s ON s.Id = u.SpecializationId
LEFT JOIN dbo.Class          c ON c.Id = u.ClassId
ORDER BY u.StudentCode;";

        public List<Student> GetAll()//giai thich ve loi ich khi su dung tung cai
        {
            var result = new List<Student>();
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(SelectListSql, conn);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                result.Add(Map(rd));

            return result;
        }

        private const string SelectOneSql = @"
SELECT 
    u.StudentCode                    AS StudentId,
    u.FullName,
    m.MajorName                      AS Major,
    s.SpecializationName             AS Specialization,
    c.ClassCode                      AS ClassName,
    u.Gender,
    u.PhoneE164                      AS Phone,
    u.CCCD,
    u.EmailNormalized                AS Email,
    u.[Address]                      AS [Address],
    CASE 
        WHEN u.Role = 'ALUMNI' THEN N'Đã tốt nghiệp'
        WHEN u.Role = 'PAUSED' THEN N'Bảo lưu'
        ELSE N'Đang học'
    END                               AS Status,
    u.CohortYear                     AS [Year]
FROM dbo.Users u
LEFT JOIN dbo.Major          m ON m.Id = u.MajorId
LEFT JOIN dbo.Specialization s ON s.Id = u.SpecializationId
LEFT JOIN dbo.Class          c ON c.Id = u.ClassId
WHERE u.StudentCode = @id;";

        public Student? GetById(string studentId)
        {
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(SelectOneSql, conn);
            cmd.Parameters.AddWithValue("@id", studentId);

            using var rd = cmd.ExecuteReader();
            return rd.Read() ? Map(rd) : null;
        }

        // INSERT/UPDATE/DELETE vào dbo.Users (không dùng @name lung tung)
        private const string InsertSql = @"
INSERT INTO dbo.Users(
    Id, StudentCode, FullName, Gender, PhoneE164, CCCD, EmailNormalized, [Address],
    CohortYear, Role, PasswordHash,
    ClassId, MajorId, SpecializationId,
    CreatedAtUtc, UpdatedAtUtc
)
VALUES(
    NEWID(), @code, @fullName, @gender, @phone, @cccd, @mail, @addr,
    @year, @role, @password,
    @classId, @majorId, @specializationId,
    SYSUTCDATETIME(), SYSUTCDATETIME()
);";

        private static string HashPassword(string password)//co the ke thua 
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder();
                foreach (var b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

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
            cmd.Parameters.AddWithValue("@year", s.Year);
            string defaultPassword = HashPassword("123456");
            cmd.Parameters.AddWithValue("@role", "STUDENT");
            cmd.Parameters.AddWithValue("@password", defaultPassword);  // bạn muốn map Status -> Role thì đổi ở đây
            var classId = GetIdByNameOrThrow(conn, "Class", "ClassCode", s.ClassName);
            var majorId = GetIdByNameOrThrow(conn, "Major", "MajorName", s.Major);
            var specializationId = GetIdByNameOrThrow(conn, "Specialization", "SpecializationName", s.Specialization);

            cmd.Parameters.AddWithValue("@classId", classId);
            cmd.Parameters.AddWithValue("@majorId", majorId);
            cmd.Parameters.AddWithValue("@specializationId", specializationId);





            cmd.ExecuteNonQuery();
        }

        private const string UpdateSql = @"
UPDATE dbo.Users SET
    FullName         = @fullName,
    Gender           = @gender,
    PhoneE164        = @phone,
    CCCD             = @cccd,
    EmailNormalized  = @mail,
    [Address]        = @addr,
    CohortYear       = @year,
    ClassId          = COALESCE(@classId, ClassId),
    MajorId          = COALESCE(@majorId, MajorId),
    SpecializationId = COALESCE(@specializationId, SpecializationId),
    UpdatedAtUtc     = SYSUTCDATETIME()
WHERE StudentCode    = @code;";



        public void Update(Student s)
        {
            using var conn = _factory.Create();
            conn.Open();

            // 🔎 kiểm tra chuyên ngành – nếu sai sẽ ném InvalidOperationException
            Guid? specId = null;
            if (!string.IsNullOrWhiteSpace(s.Specialization))
            {
                specId = GetIdByNameOrThrow(
                    conn,
                    "Specialization",
                    "SpecializationName",
                    s.Specialization
                );
            }



            using var cmd = new SqlCommand(UpdateSql, conn);
            cmd.Parameters.AddWithValue("@code", s.StudentId ?? "");
            cmd.Parameters.AddWithValue("@fullName", s.FullName ?? "");
            cmd.Parameters.AddWithValue("@gender", s.Gender ?? "Nam");
            cmd.Parameters.AddWithValue("@phone", s.Phone ?? "");
            cmd.Parameters.AddWithValue("@cccd", s.CCCD ?? "");
            cmd.Parameters.AddWithValue("@mail", s.Email ?? "");
            cmd.Parameters.AddWithValue("@addr", s.Address ?? "");
            cmd.Parameters.AddWithValue("@year", s.Year ?? "");

            // Lấy GUID theo ô bạn nhập (nếu rỗng/không khớp sẽ trả DBNull.Value → COALESCE giữ nguyên DB)
            cmd.Parameters.AddWithValue("@classId",
        TryGetIdByNameOrDbNull(conn, "Class", "ClassCode", s.ClassName));
            cmd.Parameters.AddWithValue("@majorId",
                TryGetIdByNameOrDbNull(conn, "Major", "MajorName", s.Major));

            // Chuyên ngành: đã check phía trên, nếu sai thì đã throw rồi
            if (specId.HasValue)
                cmd.Parameters.AddWithValue("@specializationId", specId.Value);
            else
                cmd.Parameters.AddWithValue("@specializationId", DBNull.Value);


            cmd.ExecuteNonQuery();
        }



        private const string DeleteSql = @"DELETE FROM dbo.Users WHERE StudentCode = @code;";

        public void Delete(string studentId)
        {
            using var conn = _factory.Create();
            conn.Open();

            using var cmd = new SqlCommand(DeleteSql, conn);
            cmd.Parameters.AddWithValue("@code", studentId);
            cmd.ExecuteNonQuery();
        }
        private static Guid GetIdByNameOrThrow(SqlConnection conn, string table, string nameColumn, string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new InvalidOperationException($"Giá trị '{table}' không được để trống.");

            using var cmd = new SqlCommand(
                $"SELECT TOP 1 Id FROM dbo.{table} WHERE {nameColumn} = @name", conn);
            cmd.Parameters.AddWithValue("@name", input.Trim());

            var o = cmd.ExecuteScalar();
            if (o == null || o == DBNull.Value)
                throw new InvalidOperationException($"Không tìm thấy {table} có tên: '{input}'. Hãy chọn từ danh sách có sẵn.");
            return (Guid)o;
        }

        private static object TryGetIdByNameOrDbNull(SqlConnection conn, string table, string nameColumn, string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return DBNull.Value;

            using var cmd = new SqlCommand(
                $"SELECT TOP 1 Id FROM dbo.{table} WHERE {nameColumn} = @name", conn);
            cmd.Parameters.AddWithValue("@name", input.Trim());

            var o = cmd.ExecuteScalar();
            return (o == null || o == DBNull.Value) ? DBNull.Value : o;
        }



    }
}
