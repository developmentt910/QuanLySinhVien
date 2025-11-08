using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Services
{
    public class AdminService
    {
        private readonly IUsersReader _userReader;
        private readonly IUsersWriter _userWriter;

        public AdminService(IUsersReader userReader, IUsersWriter userWriter)
        {
            _userReader = userReader;
            _userWriter = userWriter;
        }


        public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _userReader.FindByIdAsync(id, ct);
        }

        public async Task UpdateUserInfoAsync(User u, CancellationToken ct = default)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            await _userWriter.UpdateUserInfoAsync(u, ct);
        }




        //public async Task<User?> GetUserByPrivilegeCodeAsync(string privilegeCode, CancellationToken ct = default)
        //{
        //    return await _userReader.FindByPrivilegeCode(privilegeCode, ct);
        //}

        //public async Task<Guid> CreateUserAsync(User u, CancellationToken ct = default)
        //{
        //    if (u == null) throw new ArgumentNullException(nameof(u));

        //    if (!string.IsNullOrWhiteSpace(u.EmailNormalized))
        //        if (await _userReader.EmailExistsAsync(u.EmailNormalized, ct))
        //            throw new InvalidOperationException("Email đã tồn tại.");

        //    if (!string.IsNullOrWhiteSpace(u.CCCD))
        //        if (await _userReader.CccdExistsAsync(u.CCCD, ct))
        //            throw new InvalidOperationException("CCCD đã tồn tại.");

        //    if (!string.IsNullOrWhiteSpace(u.PrivilegeCode))
        //        if (await _userReader.PrivilegeCodeExistsAsync(u.PrivilegeCode, ct))
        //            throw new InvalidOperationException("PrivilegeCode đã tồn tại.");

        //    return await _userWriter.CreateAsync(u, ct);
        //}

        //public async Task SetUserLockedAsync(Guid userId, bool locked, CancellationToken ct = default)
        //{
        //    await _userWriter.SetLockedAsync(userId, locked, ct);
        //}

        //public async Task MarkEmailVerifiedAsync(Guid userId, DateTime verifiedAtUtc, CancellationToken ct = default)
        //{
        //    await _userWriter.MarkEmailVerifiedAsync(userId, verifiedAtUtc, ct);
        //}


        //public async Task<bool> EmailExistsAsync(string emailNormalized, CancellationToken ct = default)
        //    => await _userReader.EmailExistsAsync(emailNormalized, ct);

        //public async Task<bool> CccdExistsAsync(string cccd, CancellationToken ct = default)
        //    => await _userReader.CccdExistsAsync(cccd, ct);


        //public async Task<bool> PrivilegeCodeExistsAsync(string privilegeCode, CancellationToken ct = default)
        //    => await _userReader.PrivilegeCodeExistsAsync(privilegeCode, ct);
    }
}
