

namespace StudentCourseManagement.Applications.Services
{
    public class AdminService
    {
        private readonly IRosterReader _userReader;
        private readonly IRosterWriter _userWriter;

        public AdminService(IRosterReader userReader, IRosterWriter userWriter)
        {
            _userReader = userReader;
            _userWriter = userWriter;
        }


        public async Task<Roster?> GetUserByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _userReader.FindByIdAsync(id, ct);
        }

        public async Task UpdateUserInfoAsync(Roster u, CancellationToken ct = default)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            await _userWriter.UpdateUserInfoAsync(u, ct);
        }
    }

}
