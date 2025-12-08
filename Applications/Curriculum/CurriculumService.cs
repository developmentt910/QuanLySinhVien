using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Abstractions.Services;
using System;
using System.Data;

namespace StudentCourseManagement.Applications.Curriculum 
{
    public class CurriculumService : ICurriculumService
    {
        private readonly ICurriculumRepository _curriculumRepository;

        public CurriculumService(ICurriculumRepository curriculumRepository)
        {
            _curriculumRepository = curriculumRepository;
        }

        public DataTable GetCurriculumDetails(Guid specializationId, string semester)
        {
            return _curriculumRepository.GetCurriculumDetails(specializationId, semester);
        }

        public void AddSubjectToCurriculum(Guid specializationId, Guid subjectId, string semester)
        {
            _curriculumRepository.AddSubjectToCurriculum(specializationId, subjectId, semester);
        }

        public void RemoveSubjectFromCurriculum(Guid curriculumId)
        {
            _curriculumRepository.RemoveSubjectFromCurriculum(curriculumId);
        }
    }
}