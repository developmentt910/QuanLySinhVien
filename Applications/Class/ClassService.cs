using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Abstractions.Services;
using System;
using System.Data;

namespace StudentCourseManagement.Applications.Class
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public DataTable GetAllClasses()
        {
            return _classRepository.GetAllClasses();
        }

        public void AddClass(string classCode, string className, int studentCount, string advisorName, Guid majorId, Guid specializationId)
        {
            _classRepository.AddClass(classCode, className, studentCount, advisorName, majorId, specializationId);
        }

        public void UpdateClass(Guid classId, string classCode, string className, int studentCount, string advisorName, Guid majorId, Guid specializationId)
        {
            _classRepository.UpdateClass(classId, classCode, className, studentCount, advisorName, majorId, specializationId);
        }

        public void RemoveClass(Guid classId)
        {
            _classRepository.RemoveClass(classId);
        }

        public bool CheckClassCodeExists(string classCode, Guid? currentId = null)
        {
            return _classRepository.CheckClassCodeExists(classCode, currentId);
        }
        public DataTable GetFilteredClasses(Guid? facultyId, Guid? majorId, Guid? specializationId)
        {
            return _classRepository.GetFilteredClasses(facultyId, majorId, specializationId);
        }
        public bool CheckClassNameExists(string className, Guid? currentId = null)
        {
            return _classRepository.CheckClassNameExists(className, currentId);
        }

    }
}