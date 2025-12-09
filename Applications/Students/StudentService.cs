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

                    ClassId = s.ClassId,
                    MajorId = s.MajorId,
                    SpecializationId = s.SpecializationId,

                    Gender = s.Gender,
                    Phone = s.Phone,
                    CCCD = s.CCCD,
                    Email = s.Email,
                    Address = s.Address,

                    Status = s.Status,
                    Year = s.Year,
                    Password = s.PasswordHash,
                    ProfileImage = s.ProfileImage
                });
            }

            return list;
        }

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

                ClassId = s.ClassId,                     // ✅ BỔ SUNG
                MajorId = s.MajorId,                     // ✅ BỔ SUNG
                SpecializationId = s.SpecializationId,   // ✅ BỔ SUNG

                Gender = s.Gender,
                Phone = s.Phone,
                CCCD = s.CCCD,
                Address = s.Address,

                Status = s.Status,
                Year = s.Year,

                Password = s.PasswordHash,

                ProfileImage = s.ProfileImage            // ✅✅✅ QUAN TRỌNG NHẤT
            };
        }


        public bool AddStudent(StudentDto dto)
        {
            var repo = (_repository as StudentRepository)!;

            // ✅ CHẶN TRÙNG MÃ SV
            if (repo.IsStudentCodeExists(dto.StudentId))
                throw new Exception("Mã sinh viên đã tồn tại!");

            // ✅✅✅ CHẶN TRÙNG CCCD
            if (repo.IsCccdExists(dto.CCCD))
                throw new Exception("CCCD đã tồn tại, không thể thêm!");

            var entity = MapToEntity(dto);
            _repository.Add(entity);
            return true;
        }



        public bool UpdateStudent(StudentDto dto, string oldCode)
        {
            var repo = (_repository as StudentRepository)!;

            // ✅ CHẶN TRÙNG MÃ SV
            if (repo.IsStudentCodeExistsForUpdate(dto.StudentId, oldCode))
                throw new Exception("Mã sinh viên đã tồn tại!");

            // ✅✅✅ CHẶN TRÙNG CCCD (TRỪ CHÍNH NÓ)
            if (repo.IsCccdExistsForUpdate(dto.CCCD, oldCode))
                throw new Exception("CCCD đã tồn tại, không thể cập nhật!");

            var entity = MapToEntity(dto);
            _repository.Update(entity, oldCode);
            return true;
        }



        public bool DeleteStudent(string studentId)
        {
            _repository.Delete(studentId);
            return true;
        }

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

                // ✅✅✅ THÊM DÒNG QUAN TRỌNG NHẤT
                FacultyId = dto.FacultyId,

                ClassId = dto.ClassId,
                MajorId = dto.MajorId,
                SpecializationId = dto.SpecializationId,

                Gender = dto.Gender,
                Phone = dto.Phone,
                CCCD = dto.CCCD,
                Address = dto.Address,

                Status = dto.Status,
                Year = dto.Year,

                PasswordHash = dto.Password,
                ProfileImage = dto.ProfileImage
            };
        }




        public Dictionary<Guid, string> GetFaculties() =>
            (_repository as StudentRepository)!.GetFaculties();

        public Dictionary<Guid, string> GetMajorsByFaculty(Guid facultyId) =>
            (_repository as StudentRepository)!.GetMajorsByFaculty(facultyId);

        public Dictionary<Guid, string> GetSpecializationsByMajor(Guid majorId) =>
            (_repository as StudentRepository)!.GetSpecializationsByMajor(majorId);
        public Dictionary<Guid, string> GetClassesBySpecialization(Guid specializationId)
        {
            return (_repository as StudentRepository)!.GetClassesBySpecialization(specializationId);
        }

    }
}
