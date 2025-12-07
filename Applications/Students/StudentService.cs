using System;
using System.Collections.Generic;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Applications.Students.Dtos;
using StudentCourseManagement.Infrastructure.Repositories.SqlServer;

namespace StudentCourseManagement.Applications.Students
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        // =========================
        // ✅ LẤY DANH SÁCH SINH VIÊN
        // =========================
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

                    Faculty = s.Faculty,
                    Major = s.Major,
                    Specialization = s.Specialization,
                    ClassName = s.ClassName,

                    Gender = s.Gender,

                    // ✅ CHỐT DÙNG Phone – Email
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

        // =========================
        // ✅ LẤY 1 SINH VIÊN
        // =========================
        public StudentDto? GetStudentById(string studentId)
        {
            var s = _repository.GetById(studentId);
            if (s == null) return null;

            return new StudentDto
            {
                StudentId = s.StudentId,
                FullName = s.FullName,

                Faculty = s.Faculty,
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

        // =========================
        // ✅ THÊM SINH VIÊN
        // =========================
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

        // =========================
        // ✅ CẬP NHẬT SINH VIÊN
        // =========================
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

        // =========================
        // ✅ XÓA SINH VIÊN
        // =========================
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

        // =========================
        // ✅ MAP DTO → ENTITY (CHUẨN)
        // =========================
        private Student MapToEntity(StudentDto dto)
        {
            return new Student
            {
                StudentId = dto.StudentId,
                FullName = dto.FullName,

                Faculty = dto.Faculty,
                Major = dto.Major,
                Specialization = dto.Specialization,
                ClassName = dto.ClassName,

                Gender = dto.Gender,

                Phone = dto.Phone,
                CCCD = dto.CCCD,
                Email = dto.Email,
                Address = dto.Address,

                Status = dto.Status,
                Year = dto.Year,

                // ✅ MẬT KHẨU BĂM
                PasswordHash = string.IsNullOrWhiteSpace(dto.Password)
                    ? null
                    : StudentRepository.HashPassword(dto.Password)
            };
        }
    }
}
