using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Results;

namespace StudentCourseManagement.Applications.SemesterApp
{
    public sealed class SemesterService
    {
        private readonly ISemesterReader _semesterReader;
    private readonly ISemesterWriter _semesterWriter;
        private readonly IMajorReader _majorReader;

        public SemesterService(
     ISemesterReader semesterReader,
 ISemesterWriter semesterWriter,
  IMajorReader majorReader)
        {
            _semesterReader = semesterReader;
  _semesterWriter = semesterWriter;
         _majorReader = majorReader;
        }

        public async Task<Result<Guid>> CreateSemesterAsync(
      string semesterName,
            int year,
            int semesterNumber,
        DateTime startDate,
            DateTime endDate,
  Guid majorId,
      CancellationToken ct = default)
    {
        // Validate inputs
     if (string.IsNullOrWhiteSpace(semesterName))
    return Result<Guid>.Fail("Tên h?c k? không ???c ?? tr?ng");

            if (year < 2000 || year > 2100)
    return Result<Guid>.Fail("N?m h?c không h?p l?");

       if (semesterNumber < 1 || semesterNumber > 3)
           return Result<Guid>.Fail("H?c k? ph?i t? 1 ??n 3");

if (startDate >= endDate)
     return Result<Guid>.Fail("Ngày b?t ??u ph?i tr??c ngày k?t thúc");

   // Check if major exists
            var major = await _majorReader.FindByIdAsync(majorId, ct);
        if (major is null)
          return Result<Guid>.Fail("Ngành không t?n t?i");

        // Check if semester name already exists for this major
    var exists = await _semesterReader.SemesterNameExistsAsync(semesterName, majorId, ct);
      if (exists)
       return Result<Guid>.Fail("Tên h?c k? ?ã t?n t?i cho ngành này");

            var semester = new Domain.Entities.Semester
            {
     Id = Guid.NewGuid(),
         SemesterName = semesterName.Trim(),
        Year = year,
                SemesterNumber = semesterNumber,
      StartDate = startDate,
    EndDate = endDate,
    IsActive = true,
       MajorId = majorId
 };

          var id = await _semesterWriter.CreateAsync(semester, ct);
            return Result<Guid>.Success(id);
  }

        public async Task<Result> UpdateSemesterAsync(
            Guid id,
string semesterName,
            int year,
            int semesterNumber,
          DateTime startDate,
       DateTime endDate,
  bool isActive,
        Guid majorId,
 CancellationToken ct = default)
      {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(semesterName))
             return Result.Fail("Tên h?c k? không ???c ?? tr?ng");

          if (year < 2000 || year > 2100)
          return Result.Fail("N?m h?c không h?p l?");

     if (semesterNumber < 1 || semesterNumber > 3)
   return Result.Fail("H?c k? ph?i t? 1 ??n 3");

   if (startDate >= endDate)
        return Result.Fail("Ngày b?t ??u ph?i tr??c ngày k?t thúc");

            // Check if semester exists
  var semester = await _semesterReader.FindByIdAsync(id, ct);
            if (semester is null)
     return Result.Fail("H?c k? không t?n t?i");

    // Check if major exists
       var major = await _majorReader.FindByIdAsync(majorId, ct);
            if (major is null)
 return Result.Fail("Ngành không t?n t?i");

  // Check if semester name already exists for this major (excluding current id)
    var exists = await _semesterReader.SemesterNameExistsExcludingIdAsync(semesterName, majorId, id, ct);
    if (exists)
      return Result.Fail("Tên h?c k? ?ã t?n t?i cho ngành này");

     semester.SemesterName = semesterName.Trim();
            semester.Year = year;
      semester.SemesterNumber = semesterNumber;
            semester.StartDate = startDate;
            semester.EndDate = endDate;
      semester.IsActive = isActive;
 semester.MajorId = majorId;

      await _semesterWriter.UpdateAsync(semester, ct);
            return Result.Success();
        }

        public async Task<Result> DeleteSemesterAsync(Guid id, CancellationToken ct = default)
        {
            var semester = await _semesterReader.FindByIdAsync(id, ct);
    if (semester is null)
              return Result.Fail("H?c k? không t?n t?i");

   // TODO: Check if semester has related data (students, courses, etc.)
         // before allowing deletion

  await _semesterWriter.DeleteAsync(id, ct);
     return Result.Success();
      }

        public async Task<Domain.Entities.Semester?> GetSemesterByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _semesterReader.FindByIdAsync(id, ct);
      }

        public async Task<IEnumerable<Domain.Entities.Semester>> GetAllSemestersAsync(CancellationToken ct = default)
        {
     return await _semesterReader.GetAllAsync(ct);
        }

        public async Task<IEnumerable<Domain.Entities.Semester>> GetSemestersByMajorAsync(Guid majorId, CancellationToken ct = default)
        {
         return await _semesterReader.GetByMajorIdAsync(majorId, ct);
    }

        public async Task<IEnumerable<Domain.Entities.Semester>> GetActiveSemestersAsync(CancellationToken ct = default)
        {
            return await _semesterReader.GetActiveSemestersAsync(ct);
        }
  }
}
