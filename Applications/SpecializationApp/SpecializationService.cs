using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Results;

namespace StudentCourseManagement.Applications.SpecializationApp
{
    public sealed class SpecializationService
    {
      private readonly ISpecializationReader _specReader;
        private readonly ISpecializationWriter _specWriter;
 private readonly IMajorReader _majorReader;

        public SpecializationService(
        ISpecializationReader specReader,
     ISpecializationWriter specWriter,
       IMajorReader majorReader)
        {
 _specReader = specReader;
   _specWriter = specWriter;
 _majorReader = majorReader;
      }

        public async Task<Result<Guid>> CreateSpecializationAsync(
       string name,
   Guid majorId,
  CancellationToken ct = default)
 {
         if (string.IsNullOrWhiteSpace(name))
    return Result<Guid>.Fail("Tên chuyên ngành không ???c ?? tr?ng");

  var major = await _majorReader.FindByIdAsync(majorId, ct);
   if (major is null)
   return Result<Guid>.Fail("Ngành không t?n t?i");

var exists = await _specReader.SpecializationNameExistsAsync(name, majorId, ct);
       if (exists)
                return Result<Guid>.Fail("Tên chuyên ngành ?ã t?n t?i cho ngành này");

            var spec = new Domain.Entities.Specialization
    {
          Id = Guid.NewGuid(),
          SpecializationName = name.Trim(),
  MajorId = majorId
   };

  var id = await _specWriter.CreateAsync(spec, ct);
   return Result<Guid>.Success(id);
        }

        public async Task<Result> UpdateSpecializationAsync(
      Guid id,
      string name,
     Guid majorId,
CancellationToken ct = default)
  {
if (string.IsNullOrWhiteSpace(name))
      return Result.Fail("Tên chuyên ngành không ???c ?? tr?ng");

            var spec = await _specReader.FindByIdAsync(id, ct);
  if (spec is null)
         return Result.Fail("Chuyên ngành không t?n t?i");

  var major = await _majorReader.FindByIdAsync(majorId, ct);
      if (major is null)
       return Result.Fail("Ngành không t?n t?i");

            var exists = await _specReader.SpecializationNameExistsExcludingIdAsync(name, majorId, id, ct);
if (exists)
      return Result.Fail("Tên chuyên ngành ?ã t?n t?i cho ngành này");

spec.SpecializationName = name.Trim();
     spec.MajorId = majorId;

   await _specWriter.UpdateAsync(spec, ct);
         return Result.Success();
        }

   public async Task<Result> DeleteSpecializationAsync(Guid id, CancellationToken ct = default)
        {
            var spec = await _specReader.FindByIdAsync(id, ct);
if (spec is null)
       return Result.Fail("Chuyên ngành không t?n t?i");

   await _specWriter.DeleteAsync(id, ct);
return Result.Success();
     }

  public async Task<Domain.Entities.Specialization?> GetByIdAsync(Guid id, CancellationToken ct = default)
  {
       return await _specReader.FindByIdAsync(id, ct);
        }

  public async Task<IEnumerable<Domain.Entities.Specialization>> GetAllAsync(CancellationToken ct = default)
        {
     return await _specReader.GetAllAsync(ct);
        }

public async Task<IEnumerable<Domain.Entities.Specialization>> GetByMajorAsync(Guid majorId, CancellationToken ct = default)
        {
       return await _specReader.GetByMajorIdAsync(majorId, ct);
        }
    }
}
