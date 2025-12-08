using System;
using System.Collections.Generic;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Domain.Repositories;
using StudentCourseManagement.Infrastructure.Repositories.An;

namespace StudentCourseManagement.Application.Services
{
    public class PointManagerService
    {
        private readonly IPointRepository _repo;

        public PointManagerService()
        {
            _repo = new SqlPointRepository();
        }

        public StudentInfo GetStudentInfo(string studentCode)
            => _repo.GetStudentInfo(studentCode);

        //public List<ListItem> GetSubjectsByClass(string classId)
        //    => _repo.GetSubjectsByClass(classId);

        //public string GetSemester(string classId, string subjectId)
        //    => _repo.GetSemester(classId, subjectId);
        public StudyResult GetStudyResult(Guid userId, string subjectId)
            => _repo.GetStudyResult(userId, subjectId);

        public int GetCohortYearFromUser(Guid userId)
            => _repo.GetCohortYearFromUser(userId);



        public void SaveResult(StudyResult result)
            => _repo.SaveResult(result);
  


        public List<string> GetSemestersForStudent(int cohortYear)
        {
            
            return _repo.GetSemestersForStudent(cohortYear);
        }


        public List<ResultSubjectDto> GetSubjectsForSemester(Guid specializationId, string semesterCode, string studentCode)
        {

            return _repo.GetSubjectsForSemester(specializationId, semesterCode, studentCode);
        }
        public void SaveResultFromGrid(DataGridView dgv, string userId, ListItem selectedSubject)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new Exception("Sinh viên chưa được chọn!");

            if (selectedSubject == null)
                throw new Exception("Chọn môn học trước khi lưu!");

            if (dgv.Rows.Count == 0)
                throw new Exception("Không có dữ liệu để lưu!");

            // TÌM ĐÚNG DÒNG THEO MÔN ĐANG CHỌN
            DataGridViewRow targetRow = null;

            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.Cells[0].Value != null && r.Cells[0].Value.ToString() == selectedSubject.Text)
                {
                    targetRow = r;
                    break;
                }
            }

            if (targetRow == null)
                throw new Exception("Không tìm thấy dòng điểm tương ứng môn đã chọn!");

            // HÀM convert điểm
            double? ParseNullableDouble(object value)
            {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    return null;
                return double.TryParse(value.ToString(), out double d) ? d : null;
            }

            // TẠO OBJECT STUDYRESULT
            var result = new StudyResult
            {
                UserId = Guid.Parse(userId),
                SubjectId = Guid.Parse(selectedSubject.Value),
                Midterm = ParseNullableDouble(targetRow.Cells[1].Value),
                Other = ParseNullableDouble(targetRow.Cells[2].Value),
                Final = ParseNullableDouble(targetRow.Cells[3].Value),
                UpdatedAtUtc = DateTime.UtcNow
            };

            result.ComputeGrades();

            _repo.SaveResult(result);
        }








        public void SaveAllResultsFromGrid(DataGridView dgv, string userId, List<ListItem> subjects)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                // Lấy tên môn
                var subjectName = row.Cells[0].Value?.ToString();
                var subject = subjects.FirstOrDefault(x => x.Text == subjectName);
                if (subject == null) continue;

                var result = new StudyResult
                {
                    UserId = new Guid(userId),
                    SubjectId = new Guid(subject.Value),
                    Midterm = double.TryParse(row.Cells[1].Value?.ToString(), out var d1) ? d1 : (double?)null,
                    Other = double.TryParse(row.Cells[2].Value?.ToString(), out var d2) ? d2 : (double?)null,
                    Final = double.TryParse(row.Cells[3].Value?.ToString(), out var d3) ? d3 : (double?)null
                };

                result.ComputeGrades(); // Tính FinalNumeric, LetterGrade, Passed
                _repo.SaveResult(result);
            }
        }

       
    }
}
