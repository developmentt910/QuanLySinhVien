using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Faculty
{
    public class FacultyService
    {
        private readonly IFacultyReader _facultyReader;
        private readonly IFacultyWriter _facultyWriter;

        public FacultyService(IFacultyReader facultyReader, IFacultyWriter facultyWriter)
        {
            _facultyReader = facultyReader;
            _facultyWriter = facultyWriter;
        }

        public async Task<Domain.Entities.Faculty?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _facultyReader.FindByIdAsync(id, ct);
        }

        public async Task<IEnumerable<Domain.Entities.Faculty>> GetAllAsync(CancellationToken ct = default)
        {
            return await _facultyReader.GetAllAsync(ct);
        }

        public async Task<Guid> CreateAsync(Domain.Entities.Faculty faculty, CancellationToken ct = default)
        {
            if (faculty == null)
                throw new ArgumentNullException(nameof(faculty));

            if (string.IsNullOrWhiteSpace(faculty.FacultyName))
                throw new ArgumentException("Tên khoa không được để trống.", nameof(faculty.FacultyName));

            // Kiểm tra tên khoa đã tồn tại
            if (await _facultyReader.FacultyNameExistsAsync(faculty.FacultyName, ct))
                throw new InvalidOperationException($"Khoa '{faculty.FacultyName}' đã tồn tại.");

            return await _facultyWriter.CreateAsync(faculty, ct);
        }

        public async Task UpdateAsync(Domain.Entities.Faculty faculty, CancellationToken ct = default)
        {
            if (faculty == null)
                throw new ArgumentNullException(nameof(faculty));

            if (string.IsNullOrWhiteSpace(faculty.FacultyName))
                throw new ArgumentException("Tên khoa không được để trống.", nameof(faculty.FacultyName));

            // Kiểm tra tên khoa đã tồn tại (trừ khoa hiện tại)
            if (await _facultyReader.FacultyNameExistsExcludingIdAsync(faculty.FacultyName, faculty.Id, ct))
                throw new InvalidOperationException($"Khoa '{faculty.FacultyName}' đã tồn tại.");

            await _facultyWriter.UpdateAsync(faculty, ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var faculty = await _facultyReader.FindByIdAsync(id, ct);
            if (faculty == null)
                throw new InvalidOperationException("Không tìm thấy khoa cần xóa.");

            // TODO: Kiểm tra xem khoa có được sử dụng bởi ngành nào không
            // Nếu có, không cho phép xóa

            await _facultyWriter.DeleteAsync(id, ct);
        }
    }
}
