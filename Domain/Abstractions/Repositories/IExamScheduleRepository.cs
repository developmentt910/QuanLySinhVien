using System;
using System.Data;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IExamScheduleRepository
    {
        DataTable GetExamSchedules();

        // Thêm lịch thi
        void AddExamSchedule(Guid classId, Guid subjectId, Guid semesterId, string room, DateTime examDate, int examDuration, string examType);

        // Cập nhật lịch thi
        void UpdateExamSchedule(Guid examId, Guid classId, Guid subjectId, Guid semesterId, string room, DateTime examDate, int examDuration, string examType);

        // Xóa lịch thi
        void RemoveExamSchedule(Guid examId);
        bool IsRoomConflict(Guid? examId, string room, DateTime examDate, int examDuration);

    }
}