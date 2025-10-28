using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.StudentService
{
    public class StudentService
    {
        private readonly IUsersReader _reader;
        private readonly IUsersWriter _writer;

        public StudentService(IUsersReader reader, IUsersWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public async Task<StudentDto?> GetStudentByCodeAsync(string code, CancellationToken ct = default)
        {
            var user = await _reader.FindByStudentCode(code, ct);
            return user is null ? null : MapToDto(user);
        }

        public async Task LockStudentAsync(Guid id, bool locked, CancellationToken ct = default)
        {
            await _writer.SetLockedAsync(id, locked, ct);
        }

        public async Task UpdatePasswordAsync(Guid id, string newPasswordHash, CancellationToken ct = default)
        {
            await _writer.UpdatePasswordHashAsync(id, newPasswordHash, ct);
        }

        public async Task<IEnumerable<StudentDto>> SearchStudentsAsync(
            int? classId = null,
            int? majorId = null,
            short? cohortYear = null,
            CancellationToken ct = default)
        {
            // Giả lập: đọc tất cả và filter (thực tế nên làm query SQL lọc)
            var allStudents = new List<StudentDto>();
            // TODO: gọi repository trả về tất cả user hoặc filter từ DB
            return allStudents
                .Where(s => !classId.HasValue || s.ClassId == classId)
                .Where(s => !majorId.HasValue || s.MajorId == majorId)
                .Where(s => !cohortYear.HasValue || s.CohortYear == cohortYear);
        }

        private StudentDto MapToDto(User u) => new()
        {
            Id = u.Id,
            StudentCode = u.StudentCode ?? "",
            FullName = u.FullName,
            Email = u.EmailNormalized,
            Phone = u.PhoneE164,
            IsLocked = u.IsLocked,
            ClassId = u.ClassId,
            MajorId = u.MajorId,
            SpecializationId = u.SpecializationId,
            CohortYear = u.CohortYear
        };
    }
}
