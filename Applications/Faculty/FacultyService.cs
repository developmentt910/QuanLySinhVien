public sealed class FacultyService
{
    private readonly IFacultyReader _reader;
    private readonly IFacultyWriter _writer;

    public FacultyService(IFacultyReader reader, IFacultyWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public async Task<IEnumerable<Faculty>> GetAllAsync(CancellationToken ct = default)
        => await _reader.GetAllAsync(ct);

    public async Task<Faculty?> GetByCodeAsync(string code, CancellationToken ct = default)
        => await _reader.FindByCodeAsync(code, ct);

    public async Task<string> CreateAsync(Faculty faculty, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(faculty.FacultyCode))
            throw new ArgumentException("Mã khoa không được để trống.");

        if (string.IsNullOrWhiteSpace(faculty.FacultyName))
            throw new ArgumentException("Tên khoa không được để trống.");

        if (await _reader.FindByCodeAsync(faculty.FacultyCode, ct) != null)
            throw new InvalidOperationException("Mã khoa đã tồn tại.");

        if (await _reader.FacultyNameExistsAsync(faculty.FacultyName, ct))
            throw new InvalidOperationException("Tên khoa đã tồn tại.");

        return await _writer.CreateAsync(faculty, ct);
    }

    public async Task UpdateAsync(Faculty faculty, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(faculty.FacultyCode))
            throw new ArgumentException("Mã khoa không được để trống.");

        if (string.IsNullOrWhiteSpace(faculty.FacultyName))
            throw new ArgumentException("Tên khoa không được để trống.");

        if (await _reader.FacultyNameExistsExcludingCodeAsync(faculty.FacultyName, faculty.FacultyCode, ct))
            throw new InvalidOperationException("Tên khoa đã tồn tại.");

        await _writer.UpdateAsync(faculty, ct);
    }

    public async Task DeleteAsync(string facultyCode, CancellationToken ct = default)
        => await _writer.DeleteAsync(facultyCode, ct);
}
