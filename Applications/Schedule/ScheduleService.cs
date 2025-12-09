using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Abstractions.Services;
using System;
using System.Data;

namespace StudentCourseManagement.Applications.Schedule
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public DataTable GetFaculties()
        {
            return _scheduleRepository.GetFaculties();
        }

        public DataTable GetMajorsByFaculty(string facultyId)
        {
            return _scheduleRepository.GetMajorsByFaculty(facultyId);
        }

        public DataTable GetSpecializationsByMajor(string majorId)
        {
            return _scheduleRepository.GetSpecializationsByMajor(majorId);
        }

        public DataTable GetClassesBySpecialization(string specializationId)
        {
            return _scheduleRepository.GetClassesBySpecialization(specializationId);
        }

        public DataTable GetSemesters()
        {
            return _scheduleRepository.GetSemesters();
        }

        public DataTable GetSchedules(string classId, string semesterId)
        {
            return _scheduleRepository.GetSchedules(classId, semesterId);
        }
        public DataTable GetAvailableSubjects(string classId, string semesterId, Guid majorId, Guid specializationId)
        {
            return _scheduleRepository.GetAvailableSubjects(classId, semesterId, majorId, specializationId);
        }

        public void AddSchedule(string classId, string subjectId, string teacherName, string room, string semesterId, DateTime lessonDate, int startPeriod, int endPeriod)
        {
            _scheduleRepository.AddSchedule(classId, subjectId, teacherName, room, semesterId, lessonDate, startPeriod, endPeriod);
        }

        public void RemoveSchedule(string scheduleId)
        {
            _scheduleRepository.RemoveSchedule(scheduleId);
        }

        public void UpdateSchedule(string scheduleId, string subjectId, string teacherName, string room, DateTime lessonDate, int startPeriod, int endPeriod)
        {
            _scheduleRepository.UpdateSchedule(scheduleId, subjectId, teacherName, room, lessonDate, startPeriod, endPeriod);
        }
        public DataTable GetSubjectsBySpecialization(Guid majorId, Guid specializationId)
        {
            return _scheduleRepository.GetSubjectsBySpecialization(majorId, specializationId);
        }
        public DataTable GetAllSubjectDetailsBySpecialization(Guid majorId, Guid specializationId)
        {
            return _scheduleRepository.GetAllSubjectDetailsBySpecialization(majorId, specializationId);
        }
        public bool IsTeacherBusy(string teacherName, DateTime lessonDate, int startPeriod, int endPeriod, string? ignoreScheduleId = null)
        {
            return _scheduleRepository.IsTeacherBusy(teacherName, lessonDate, startPeriod, endPeriod, ignoreScheduleId);
        }

    }
}