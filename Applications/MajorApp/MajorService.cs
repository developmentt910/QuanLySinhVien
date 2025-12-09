using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Results;

namespace StudentCourseManagement.Applications.MajorApp
{
    public sealed class MajorService
  {
        private readonly IMajorReader _majorReader;
private readonly IMajorWriter _majorWriter;
   private readonly IFacultyReader _facultyReader;

        public MajorService(
        IMajorReader majorReader,
     IMajorWriter majorWriter,
   IFacultyReader facultyReader)
  {
    _majorReader = majorReader;
            _majorWriter = majorWriter;
    _facultyReader = facultyReader;
        }

        public async Task<Result<Guid>> CreateMajorAsync(
    string majorName,
     Guid facultyId,
    CancellationToken ct = default)
        {
      // Validate inputs
      if (string.IsNullOrWhiteSpace(majorName))
        return Result<Guid>.Fail("Tên ngành không ???c ?? tr?ng");

            // Check if faculty exists
   var faculty = await _facultyReader.FindByIdAsync(facultyId, ct);
        if (faculty is null)
    return Result<Guid>.Fail("Khoa không t?n t?i");

       // Check if major name already exists for this faculty
   var exists = await _majorReader.MajorNameExistsAsync(majorName, facultyId, ct);
            if (exists)
     return Result<Guid>.Fail("Tên ngành ?ã t?n t?i cho khoa này");

   var major = new Domain.Entities.Major
        {
 Id = Guid.NewGuid(),
     MajorName = majorName.Trim(),
     FacultyId = facultyId
       };

            var id = await _majorWriter.CreateAsync(major, ct);
      return Result<Guid>.Success(id);
        }

        public async Task<Result> UpdateMajorAsync(
   Guid id,
            string majorName,
    Guid facultyId,
          CancellationToken ct = default)
        {
      // Validate inputs
   if (string.IsNullOrWhiteSpace(majorName))
     return Result.Fail("Tên ngành không ???c ?? tr?ng");

// Check if major exists
 var major = await _majorReader.FindByIdAsync(id, ct);
   if (major is null)
          return Result.Fail("Ngành không t?n t?i");

    // Check if faculty exists
       var faculty = await _facultyReader.FindByIdAsync(facultyId, ct);
   if (faculty is null)
  return Result.Fail("Khoa không t?n t?i");

            // Check if major name already exists for this faculty (excluding current id)
            var exists = await _majorReader.MajorNameExistsExcludingIdAsync(majorName, facultyId, id, ct);
  if (exists)
        return Result.Fail("Tên ngành ?ã t?n t?i cho khoa này");

      major.MajorName = majorName.Trim();
            major.FacultyId = facultyId;

  await _majorWriter.UpdateAsync(major, ct);
  return Result.Success();
        }

        public async Task<Result> DeleteMajorAsync(Guid id, CancellationToken ct = default)
        {
  var major = await _majorReader.FindByIdAsync(id, ct);
            if (major is null)
     return Result.Fail("Ngành không t?n t?i");

   // TODO: Check if major has related data (students, semesters, etc.)
     // before allowing deletion

  await _majorWriter.DeleteAsync(id, ct);
    return Result.Success();
   }

        public async Task<Domain.Entities.Major?> GetMajorByIdAsync(Guid id, CancellationToken ct = default)
        {
       return await _majorReader.FindByIdAsync(id, ct);
        }

  public async Task<IEnumerable<Domain.Entities.Major>> GetAllMajorsAsync(CancellationToken ct = default)
        {
       return await _majorReader.GetAllAsync(ct);
  }

        public async Task<IEnumerable<Domain.Entities.Major>> GetMajorsByFacultyAsync(Guid facultyId, CancellationToken ct = default)
        {
      return await _majorReader.GetByFacultyIdAsync(facultyId, ct);
        }
    }
}
