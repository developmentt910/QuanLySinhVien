using StudentCourseManagement.Applications.Dtos;
using StudentCourseManagement.Applications.Security;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Domain.Results;
using StudentCourseManagement.Infrastructure.Security.Crypto;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Auth
{
    public sealed class LoginService
    {
        private readonly IUsersReader _usersR;
        private readonly ThrottleService _throttle;
        private readonly CaptchaVerifier? _captcha;
        private readonly IRosterReader _rosterR;
        private readonly IUsersWriter _userW;

        public LoginService(
            IUsersReader usersR,
            ThrottleService throttle,
            IRosterReader rosterR,
            IUsersWriter userW,
            CaptchaVerifier? captcha = null)
        {
            _usersR = usersR;
            _throttle = throttle;
            _rosterR = rosterR;
            _userW = userW;
            _captcha = captcha;
        }

        public string GenerateCaptcha() => _captcha?.Generate() ?? string.Empty;

        public async Task<Result<User>> LoginAsync(LoginDto dto, CancellationToken ct = default)
        {
            if (_captcha != null && !_captcha.Verify(dto.CaptchaToken!, dto.CaptchaInput!))
                return Result<User>.Fail("Mã bảo vệ không đúng.");

            User? user = null;
            Roster? roster = null;

            if (!string.IsNullOrWhiteSpace(dto.PrivilegeCode))
            {
                string code = dto.PrivilegeCode.Trim();

                user = await _usersR.FindByPrivilegeCode(code);

                if (user == null)
                {
                    roster = await _rosterR.FindByPrivilegeCodeAsync(code, ct);
                    if (roster != null)
                    {
                        user = new User
                        {
                            Id = Guid.NewGuid(),
                            RosterId = roster.Id,
                            FullName = roster.FullName,
                            Gender = roster.Gender,
                            Address = roster.Address,
                            PrivilegeCode = roster.PrivilegeCode,
                            Role = "admin",
                            PasswordHash = PasswordHasher.Hash(dto.Password),
                            CreatedAtUtc = DateTime.UtcNow,
                            EmailNormalized = roster.EmailSchool?.ToLowerInvariant(),
                            EmailVerified = true
                        };

                        await _userW.CreateAsync(user, ct);
                        await _userW.LinkRosterUsedAsync(roster.Id, ct);
                    }
                }

                if (user == null)
                    return Result<User>.Fail("Tài khoản quản trị không tồn tại.");
            }

            else if (!string.IsNullOrWhiteSpace(dto.StudentCode))
            {
                string code = dto.StudentCode.Trim();

                user = await _usersR.FindByStudentCode(code);

                if (user == null)
                {
                    roster = await _rosterR.FindByStudentCodeAsync(code, ct);
                    if (roster != null)
                    {
                        user = new User
                        {
                            Id = Guid.NewGuid(),
                            RosterId = roster.Id,
                            FullName = roster.FullName,
                            Gender = roster.Gender,
                            Address = roster.Address,
                            StudentCode = roster.StudentCode,
                            Role = "user",
                            PasswordHash = PasswordHasher.Hash(dto.Password),
                            CreatedAtUtc = DateTime.UtcNow,
                            EmailVerified = true
                        };

                        await _userW.CreateAsync(user, ct);
                        await _userW.LinkRosterUsedAsync(roster.Id, ct);
                    }
                }

                if (user == null)
                    return Result<User>.Fail("Tài khoản sinh viên không tồn tại.");
            }

            else
            {
                return Result<User>.Fail("Vui lòng nhập mã đặc quyền hoặc mã sinh viên.");
            }

            if (user.IsLocked)
                return Result<User>.Fail("Tài khoản đang bị khóa.");

            var keyHash = KeyHasher.Sha256(Encoding.UTF8.GetBytes(user.Id.ToString()));
            if (!await _throttle.AllowAsync("password", keyHash, DateTime.UtcNow))
                return Result<User>.Fail("Thử sai quá nhiều lần, vui lòng thử lại sau.");

            if (!PasswordHasher.Verifier(dto.Password, user.PasswordHash))
                return Result<User>.Fail("Mật khẩu không đúng.");

            await _throttle.ResetAsync("password", keyHash);

            if (!string.IsNullOrWhiteSpace(dto.PrivilegeCode) && user.Role != "admin")
                return Result<User>.Fail("Tài khoản này không có quyền quản trị.");

            if (!string.IsNullOrWhiteSpace(dto.StudentCode) && user.Role != "user")
                return Result<User>.Fail("Tài khoản này không phải sinh viên.");

            return Result<User>.Success(user);
        }
    }
}
