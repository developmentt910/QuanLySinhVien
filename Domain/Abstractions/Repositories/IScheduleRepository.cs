using System.Data;
using System;

public interface IScheduleRepository
{
    DataTable GetFaculties();
    DataTable GetMajorsByFaculty(string facultyId);
    DataTable GetSpecializationsByMajor(string majorId);
    DataTable GetClassesBySpecialization(string specializationId);
    DataTable GetSemesters();
    DataTable GetSchedules(string classId, string semesterId);
    DataTable GetAvailableSubjects(string classId, string semesterId);
    DataTable GetSubjects();
    void AddSchedule(string classId, string subjectId, string teacherName,
                     string room, string semesterId, DateTime lessonDate,
                     int startPeriod, int endPeriod);
    void RemoveSchedule(string scheduleId);
    void UpdateSchedule(string scheduleId, string subjectId, string teacherName,
                    string room, DateTime lessonDate, int startPeriod, int endPeriod);
}