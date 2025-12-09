using StudentCourseManagement.Applications.Dtos.Dtos;
using StudentCourseManagement.Infrastructure.Repositories.An;

public class ResultService
{
    private readonly ResultDao dao;

    public ResultService(ResultDao dao)
    {
        this.dao = dao;
    }

    public List<CurriculumSubjectDto> GetSubjectsForSemester(
    Guid specializationId,
    string semesterCode)
    {
        return dao.GetSubjectsForSemester(specializationId, semesterCode);
    }


    public StudentDtos FindByMSV(string msv) => dao.FindByMSV(msv);
    public List<string> GetSemestersForStudent(int? cohortYear) => dao.GetSemestersForStudent(cohortYear);
    public List<CurriculumSubjectDto> GetSubjectsForSemester(Guid specializationId) => dao.GetSubjectsForStudent(specializationId);
    public List<ResultSubjectDto> GetSavedScores(Guid userId) => dao.GetSavedScores(userId);
    public Guid FindSubjectIdByName(string name) => dao.FindSubjectIdByName(name);
    public void SaveScore(ResultSubjectDto dto) => dao.SaveScore(dto);


}
