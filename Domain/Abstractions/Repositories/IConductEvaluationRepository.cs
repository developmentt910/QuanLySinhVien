using System;
using System.Data;
using System.Collections.Generic;
using StudentCourseManagement.Domain.Entities;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IConductEvaluationRepository
    {
        DataRow GetStudentInfoByCode(string studentCode);

        List<TrainingEvaluation> GetEvaluations(Guid userId);

        void AddEvaluation(TrainingEvaluation eval);

        void UpdateEvaluation(TrainingEvaluation eval);

        void DeleteEvaluation(Guid evaluationId);

        DataTable GetSemestersForEvaluation(Guid userId); 
    }
}
