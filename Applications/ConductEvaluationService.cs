using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace StudentCourseManagement.Applications // Namespace Cũ: Applications.Auth
{
    public class ConductEvaluationService : IConductEvaluationRepository
    {
        private readonly IConductEvaluationRepository _conductRepository;

        

        public ConductEvaluationService(IConductEvaluationRepository conductRepository)
        {
            _conductRepository = conductRepository;
        }

        

        public DataRow GetStudentInfoByCode(string studentCode)
        {
            return _conductRepository.GetStudentInfoByCode(studentCode);
        }

        public List<TrainingEvaluation> GetEvaluations(Guid rosterId)
        {
            return _conductRepository.GetEvaluations(rosterId);
        }

        public void AddEvaluation(TrainingEvaluation eval)
        {
            _conductRepository.AddEvaluation(eval);
        }

        public void UpdateEvaluation(TrainingEvaluation eval)
        {
            _conductRepository.UpdateEvaluation(eval);
        }

        public void DeleteEvaluation(Guid evaluationId)
        {
            _conductRepository.DeleteEvaluation(evaluationId);
        }
        public DataTable GetSemestersForEvaluation(Guid userId)
        {
            return _conductRepository.GetSemestersForEvaluation(userId);
        }
    }
}