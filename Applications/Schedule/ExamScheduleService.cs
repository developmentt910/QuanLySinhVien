using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Abstractions.Services;
using System;
using System.Data;

namespace StudentCourseManagement.Applications.Schedule
{
    public class ExamScheduleService : IExamScheduleService
    {
        private readonly IExamScheduleRepository _examRepository;
        public ExamScheduleService(IExamScheduleRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public DataTable GetExamSchedules()
        {
            return _examRepository.GetExamSchedules();
        }

        public void AddExamSchedule(Guid classId, Guid subjectId, Guid semesterId, string room, DateTime examDate, int examDuration, string examType)
        {
            _examRepository.AddExamSchedule(classId, subjectId, semesterId, room, examDate, examDuration, examType);
        }

        public void UpdateExamSchedule(Guid examId, Guid classId, Guid subjectId, Guid semesterId, string room, DateTime examDate, int examDuration, string examType)
        {
            _examRepository.UpdateExamSchedule(examId, classId, subjectId, semesterId, room, examDate, examDuration, examType);
        }

        public void RemoveExamSchedule(Guid examId)
        {
            _examRepository.RemoveExamSchedule(examId);
        }
        public bool IsRoomConflict(Guid? examId, string room, DateTime examDate, int examDuration)
        {
            return _examRepository.IsRoomConflict(examId, room, examDate, examDuration);
        }

    }
}