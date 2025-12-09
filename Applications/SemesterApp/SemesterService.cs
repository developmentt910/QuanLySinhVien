using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Results;

namespace StudentCourseManagement.Applications.SemesterApp
{
    public sealed class SemesterService
    {
        private readonly ISemesterReader _semesterReader;
        private readonly ISemesterWriter _semesterWriter;

        public SemesterService(
      ISemesterReader semesterReader,
    ISemesterWriter semesterWriter)
 {
            _semesterReader = semesterReader;
            _semesterWriter = semesterWriter;
        }

        public async Task<Result<Guid>> CreateSemesterAsync(
   string semesterCode,
   string semesterName,
  string academicYear,
  CancellationToken ct = default)
        {
    if (string.IsNullOrWhiteSpace(semesterCode))
       return Result<Guid>.Fail("Mã h?c k? không ???c ?? tr?ng");

if (string.IsNullOrWhiteSpace(semesterName))
     return Result<Guid>.Fail("Tên h?c k? không ???c ?? tr?ng");

            if (string.IsNullOrWhiteSpace(academicYear))
   return Result<Guid>.Fail("N?m h?c không ???c ?? tr?ng");

       var exists = await _semesterReader.SemesterCodeExistsAsync(semesterCode, ct);
if (exists)
    return Result<Guid>.Fail("Mã h?c k? ?ã t?n t?i");

      var semester = new Domain.Entities.Semester
       {
   Id = Guid.NewGuid(),
       SemesterCode = semesterCode.Trim(),
    SemesterName = semesterName.Trim(),
       AcademicYear = academicYear.Trim()
         };

     var id = await _semesterWriter.CreateAsync(semester, ct);
return Result<Guid>.Success(id);
  }

  public async Task<Result> UpdateSemesterAsync(
      Guid id,
        string semesterCode,
 string semesterName,
     string academicYear,
     CancellationToken ct = default)
    {
            if (string.IsNullOrWhiteSpace(semesterCode))
      return Result.Fail("Mã h?c k? không ???c ?? tr?ng");

 if (string.IsNullOrWhiteSpace(semesterName))
 return Result.Fail("Tên h?c k? không ???c ?? tr?ng");

  if (string.IsNullOrWhiteSpace(academicYear))
     return Result.Fail("N?m h?c không ???c ?? tr?ng");

  var semester = await _semesterReader.FindByIdAsync(id, ct);
    if (semester is null)
    return Result.Fail("H?c k? không t?n t?i");

            var exists = await _semesterReader.SemesterCodeExistsExcludingIdAsync(semesterCode, id, ct);
    if (exists)
       return Result.Fail("Mã h?c k? ?ã t?n t?i");

 semester.SemesterCode = semesterCode.Trim();
  semester.SemesterName = semesterName.Trim();
       semester.AcademicYear = academicYear.Trim();

      await _semesterWriter.UpdateAsync(semester, ct);
       return Result.Success();
 }

        public async Task<Result> DeleteSemesterAsync(Guid id, CancellationToken ct = default)
        {
            var semester = await _semesterReader.FindByIdAsync(id, ct);
   if (semester is null)
   return Result.Fail("H?c k? không t?n t?i");

       await _semesterWriter.DeleteAsync(id, ct);
   return Result.Success();
    }

        public async Task<Domain.Entities.Semester?> GetSemesterByIdAsync(Guid id, CancellationToken ct = default)
        {
     return await _semesterReader.FindByIdAsync(id, ct);
     }

      public async Task<Domain.Entities.Semester?> GetSemesterByCodeAsync(string semesterCode, CancellationToken ct = default)
   {
return await _semesterReader.FindBySemesterCodeAsync(semesterCode, ct);
        }

 public async Task<IEnumerable<Domain.Entities.Semester>> GetAllSemestersAsync(CancellationToken ct = default)
  {
       return await _semesterReader.GetAllAsync(ct);
        }
    }
}
