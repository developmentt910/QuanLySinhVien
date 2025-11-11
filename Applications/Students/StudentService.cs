using System;
using System.Collections.Generic;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Applications.Students.Dtos;

namespace StudentCourseManagement.Applications.Students
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ sinh viên
    /// </summary>
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sinh viên
        /// </summary>
        public List<StudentDto> GetAllStudents()
        {
            var entities = _repository.GetAll();
            var list = new List<StudentDto>();

            foreach (var s in entities)
            {
                list.Add(new StudentDto
                {
                    StudentId = s.StudentId,
                    FullName = s.FullName,
                    Major = s.Major,
                    Specialization = s.Specialization,
                    ClassName = s.ClassName,
                    Gender = s.Gender,
                    Phone = s.Phone,
                    CCCD = s.CCCD,
                    Email = s.Email,
                    Address = s.Address,
                    Status = s.Status,
                    Year = s.Year
                });
            }

            return list;
        }

        /// <summary>
        /// Lấy thông tin 1 sinh viên theo mã
        /// </summary>
        public StudentDto? GetStudentById(string studentId)
        {
            var s = _repository.GetById(studentId);
            if (s == null) return null;

            return new StudentDto
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Major = s.Major,
                Specialization = s.Specialization,
                ClassName = s.ClassName,
                Gender = s.Gender,
                Phone = s.Phone,
                CCCD = s.CCCD,
                Email = s.Email,
                Address = s.Address,
                Status = s.Status,
                Year = s.Year
            };
        }

        /// <summary>
        /// Thêm sinh viên mới
        /// </summary>
        public bool AddStudent(StudentDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.StudentId))
                throw new ArgumentException("Dữ liệu không hợp lệ");

            var existing = _repository.GetById(dto.StudentId);
            if (existing != null)
                throw new InvalidOperationException("Mã sinh viên đã tồn tại");

            var entity = MapToEntity(dto);
            _repository.Add(entity);
            return true;
        }

        /// <summary>
        /// Cập nhật thông tin sinh viên
        /// </summary>
        public bool UpdateStudent(StudentDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.StudentId))
                throw new ArgumentException("Dữ liệu không hợp lệ");

            var existing = _repository.GetById(dto.StudentId);
            if (existing == null)
                throw new InvalidOperationException("Không tìm thấy sinh viên để cập nhật");

            var entity = MapToEntity(dto);
            _repository.Update(entity);
            return true;
        }

        /// <summary>
        /// Xóa sinh viên
        /// </summary>
        public bool DeleteStudent(string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId))
                throw new ArgumentException("Mã sinh viên không hợp lệ");

            var existing = _repository.GetById(studentId);
            if (existing == null)
                throw new InvalidOperationException("Không tìm thấy sinh viên để xóa");

            _repository.Delete(studentId);
            return true;
        }

        /// <summary>
        /// Chuyển từ DTO sang Entity
        /// </summary>
        private Student MapToEntity(StudentDto dto)
        {
            return new Student
            {
                StudentId = dto.StudentId,
                FullName = dto.FullName,
                Major = dto.Major,
                Specialization = dto.Specialization,
                ClassName = dto.ClassName,
                Gender = dto.Gender,
                Phone = dto.Phone,
                CCCD = dto.CCCD,
                Email = dto.Email,
                Address = dto.Address,
                Status = dto.Status,
                Year = dto.Year
            };
        }
    }
}
