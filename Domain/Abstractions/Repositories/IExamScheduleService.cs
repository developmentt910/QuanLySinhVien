using System;
using System.Data;

namespace StudentCourseManagement.Domain.Abstractions.Services
{
    public interface IExamScheduleService
    {
        DataTable GetExamSchedules();
        void AddExamSchedule(Guid classId, Guid subjectId, Guid semesterId, string room, DateTime examDate, int examDuration, string examType);
        void UpdateExamSchedule(Guid examId, Guid classId, Guid subjectId, Guid semesterId, string room, DateTime examDate, int examDuration, string examType);
        void RemoveExamSchedule(Guid examId);
        bool IsRoomConflict(Guid? examId, string room, DateTime examDate, int examDuration);

    }
}