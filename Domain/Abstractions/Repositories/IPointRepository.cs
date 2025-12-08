using System.Collections.Generic;
using StudentCourseManagement.Domain.Entities;

namespace StudentCourseManagement.Domain.Repositories
{
    public interface IPointRepository
    {
        StudentInfo GetStudentInfo(string studentCode);
        //List<ListItem> GetSubjectsByClass(string classId);
        //string GetSemester(string classId, string subjectId);
        StudyResult GetStudyResult(Guid userId, string subjectId);
        void SaveResult(StudyResult result);

        List<String> GetSemestersForStudent(int cohortYear);

        int GetCohortYearFromUser(Guid userId);
        List<ResultSubjectDto> GetSubjectsForSemester(Guid specializationId, string semesterCode, string studentCode);
        //List<ListItem> GetSemestersByClass(string classId);
        //List<ListItem> GetSubjectsBySemester(string classId, string semesterId);

    }
}
