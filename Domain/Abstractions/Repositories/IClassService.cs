using System;
using System.Data;

namespace StudentCourseManagement.Domain.Abstractions.Services
{
    public interface IClassService
    {
        DataTable GetAllClasses();
        void AddClass(string classCode, string className, int studentCount, string advisorName, Guid majorId, Guid specializationId);
        void UpdateClass(Guid classId, string classCode, string className, int studentCount, string advisorName, Guid majorId, Guid specializationId);
        void RemoveClass(Guid classId);
        bool CheckClassCodeExists(string classCode, Guid? currentId = null);
        DataTable GetFilteredClasses(Guid? facultyId, Guid? majorId, Guid? specializationId);
        bool CheckClassNameExists(string className, Guid? currentId = null);

    }
}