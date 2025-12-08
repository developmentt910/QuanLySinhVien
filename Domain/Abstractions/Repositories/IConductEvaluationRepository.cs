using System;
using System.Data;
using StudentCourseManagement.Domain.Entities;
using System.Collections.Generic;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IConductEvaluationRepository
    {
        DataRow GetStudentInfoByCode(string studentCode);
        List<TrainingEvaluation> GetEvaluations(Guid rosterId);
        void AddEvaluation(TrainingEvaluation eval);
        void UpdateEvaluation(TrainingEvaluation eval);
        void DeleteEvaluation(Guid evaluationId);

        // [THÊM HÀM MỚI]
        DataTable GetSemestersForEvaluation();
    }
}