using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Services
{
    public class UserService
    {
        private readonly IUsersReader _userReader;
        private readonly IUsersWriter _userWriter;

        public UserService(IUsersReader userReader, IUsersWriter userWriter)
        {
            _userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
            _userWriter = userWriter ?? throw new ArgumentNullException(nameof(userWriter));
        }

        public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _userReader.FindByIdAsync(id, ct);
        }

        public async Task<User?> GetUserByEmailAsync(string emailNormalized, CancellationToken ct = default)
        {
            return await _userReader.FindByEmailAsync(emailNormalized, ct);
        }

        public async Task<User?> GetUserByStudentCodeAsync(string studentCode, CancellationToken ct = default)
        {
            return await _userReader.FindByStudentCode(studentCode, ct);
        }

        public async Task<User?> GetUserByPrivilegeCodeAsync(string privilegeCode, CancellationToken ct = default)
        {
            return await _userReader.FindByPrivilegeCode(privilegeCode, ct);
        }

        public async Task<Guid> CreateUserAsync(User u, CancellationToken ct = default)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));

            if (!string.IsNullOrWhiteSpace(u.EmailNormalized))
                if (await _userReader.EmailExistsAsync(u.EmailNormalized, ct))
                    throw new InvalidOperationException("Email đã tồn tại.");

            if (!string.IsNullOrWhiteSpace(u.CCCD))
                if (await _userReader.CccdExistsAsync(u.CCCD, ct))
                    throw new InvalidOperationException("CCCD đã tồn tại.");

            if (!string.IsNullOrWhiteSpace(u.StudentCode))
                if (await _userReader.StudentCodeExistsAsync(u.StudentCode, ct))
                    throw new InvalidOperationException("StudentCode đã tồn tại.");

            if (!string.IsNullOrWhiteSpace(u.PrivilegeCode))
                if (await _userReader.PrivilegeCodeExistsAsync(u.PrivilegeCode, ct))
                    throw new InvalidOperationException("PrivilegeCode đã tồn tại.");

            return await _userWriter.CreateAsync(u, ct);
        }

        public async Task UpdateUserInfoAsync(User u, CancellationToken ct = default)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            await _userWriter.UpdateUserInfoAsync(u, ct);
        }

        public async Task UpdatePasswordHashAsync(Guid userId, string passwordHash, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("PasswordHash không được rỗng", nameof(passwordHash));

            await _userWriter.UpdatePasswordHashAsync(userId, passwordHash, ct);
        }

        public async Task SetUserLockedAsync(Guid userId, bool locked, CancellationToken ct = default)
        {
            await _userWriter.SetLockedAsync(userId, locked, ct);
        }

        public async Task MarkEmailVerifiedAsync(Guid userId, DateTime verifiedAtUtc, CancellationToken ct = default)
        {
            await _userWriter.MarkEmailVerifiedAsync(userId, verifiedAtUtc, ct);
        }

        public async Task LinkRosterUsedAsync(Guid rosterId, CancellationToken ct = default)
        {
            await _userWriter.LinkRosterUsedAsync(rosterId, ct);
        }

        public async Task<bool> EmailExistsAsync(string emailNormalized, CancellationToken ct = default)
            => await _userReader.EmailExistsAsync(emailNormalized, ct);

        public async Task<bool> CccdExistsAsync(string cccd, CancellationToken ct = default)
            => await _userReader.CccdExistsAsync(cccd, ct);

        public async Task<bool> StudentCodeExistsAsync(string studentCode, CancellationToken ct = default)
            => await _userReader.StudentCodeExistsAsync(studentCode, ct);

        public async Task<bool> PrivilegeCodeExistsAsync(string privilegeCode, CancellationToken ct = default)
            => await _userReader.PrivilegeCodeExistsAsync(privilegeCode, ct);
    }
}
