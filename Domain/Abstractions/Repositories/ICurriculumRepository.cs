using System;
using System.Data;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface ICurriculumRepository
    {
        DataTable GetCurriculumDetails(Guid specializationId, string semester);
        void AddSubjectToCurriculum(Guid specializationId, Guid subjectId, string semester);
        void RemoveSubjectFromCurriculum(Guid curriculumId);
    }
}