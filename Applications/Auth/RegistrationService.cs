

using StudentCourseManagement.Infrastructure.Security.Crypto;

namespace StudentCourseManagement.Applications.Auth
{
    public sealed class RegistrationService
    {
        private readonly IUsersReader _userR;
        private readonly IUsersWriter _userW;
        private readonly IOtpPinsReader _otpR;
        private readonly IOtpPinsWriter _otpW;
        private readonly IEmailService _email;
        private readonly IClock _clock;
        private readonly IRosterReader _rosterR;

        public RegistrationService(
            IUsersReader userR,
            IUsersWriter userW,
            IOtpPinsReader otpR,
            IOtpPinsWriter otpW,
            IEmailService email,
            IClock clock,
            IRosterReader rosterR
        )
        {
            _userR = userR;
            _userW = userW;
            _otpR = otpR;
            _otpW = otpW;
            _email = email;
            _clock = clock;
            _rosterR = rosterR;
        }

        public async Task<Result<Guid>> RegisterAsync(
            RegisterDto dto,
            string? schoolEmailFromRoster,
            CancellationToken ct = default)
        {
            // Normalize + validate
            var fullName = Normalizers.NormalizeFullName(dto.FullName);
            if (!RegexRules.IsMatch(fullName, RegexRules.FullNameBasic))
                return Result<Guid>.Fail("Họ tên không hợp lệ");

            if (!RegexRules.IsMatch(dto.CCCD, RegexRules.Cccd))
                return Result<Guid>.Fail("CCCD phải gồm 12 chữ số");

            if (!RegexRules.IsMatch(dto.Email, RegexRules.Email))
                return Result<Guid>.Fail("Email không hợp lệ");
            if (!string.IsNullOrWhiteSpace(dto.StudentCode))
            {
                if (string.IsNullOrWhiteSpace(dto.Password))
                    return Result<Guid>.Fail("Mật khẩu không được để trống.");

                if (!RegexRules.IsMatch(dto.Password, RegexRules.PasswordStrong))
                    return Result<Guid>.Fail("Mật khẩu chưa đủ mạnh.");
            }


            if (string.IsNullOrWhiteSpace(dto.StudentCode) && string.IsNullOrWhiteSpace(dto.PrivilegeCode))
                return Result<Guid>.Fail("Phải cung cấp MSV hoặc Mã đặc quyền.");

            var phone = Normalizers.NormalizePhoneToVN(dto.Phone);
            var emailNorm = Normalizers.NormalizeEmail(dto.Email);

            // Check trùng
            if (await _userR.EmailExistsAsync(emailNorm))
                return Result<Guid>.Fail("Email đã tồn tại.");
            if (await _userR.CccdExistsAsync(dto.CCCD))
                return Result<Guid>.Fail("CCCD đã tồn tại.");
           
            
            if (!string.IsNullOrWhiteSpace(dto.StudentCode) && await _userR.StudentCodeExistsAsync(dto.StudentCode))
                return Result<Guid>.Fail("MSV này đã tồn tại.");

            if (!string.IsNullOrWhiteSpace(dto.PrivilegeCode) && await _userR.PrivilegeCodeExistsAsync(dto.PrivilegeCode))
                return Result<Guid>.Fail("Mã đặc quyền này đã tồn tại.");

            // Hash password
            var hash = dto.Password != null
                ? PasswordHasher.Hash(dto.Password)
                : null;

            User user = new User
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                EmailNormalized = emailNorm,
                PasswordHash = hash,
                Role = !string.IsNullOrWhiteSpace(dto.PrivilegeCode) ? "admin" : "user",
                StudentCode = dto.StudentCode,
                PrivilegeCode = dto.PrivilegeCode,
                CCCD = dto.CCCD,
                PhoneE164 = Normalizers.NormalizePhoneToVN(dto.Phone),
                EmailVerified = true,
                IsLocked = false,
                CreatedAtUtc = _clock.UtcNow(),
                UpdatedAtUtc = _clock.UtcNow()
            };

            // Link roster nếu là sinh viên
            if (!string.IsNullOrWhiteSpace(dto.StudentCode))
            {
                var roster = await _rosterR.FindByStudentCodeAsync(dto.StudentCode, ct);
                if (roster == null)
                    return Result<Guid>.Fail("Mã sinh viên không tồn tại trong hệ thống.");

                user.RosterId = roster.Id;
                user.ClassId = roster.ClassId;
                user.MajorId = roster.MajorId;
                user.SpecializationId = roster.SpecializationId;
                user.CohortYear = roster.CohortYear;
                user.Gender = roster.Gender;
                user.Address = roster.Address;

                await _userW.LinkRosterUsedAsync(roster.Id, ct);
            }

            // Admin
            else if (!string.IsNullOrWhiteSpace(dto.PrivilegeCode))
            {
                var roster = await _rosterR.FindByPrivilegeCodeAsync(dto.PrivilegeCode, ct);
                if (roster == null)
                    return Result<Guid>.Fail("Mã đặc quyền không tồn tại trong hệ thống.");

                user.Role = "admin";
                user.PasswordHash = null;
                user.EmailVerified = true;
                user.IsLocked = false;

                user.FullName = roster.FullName;
                user.Gender = roster.Gender;
                user.Address = roster.Address;
                user.RosterId = roster.Id;

                await _userW.LinkRosterUsedAsync(roster.Id, ct);

            }




            var userId = await _userW.CreateAsync(user);



            // Tạo OTP
            var otp = OtpHasher.GenerateOtp6();
            //var (otpHash, salt) = OtpHasher.HashOtp(otp);
            var expires = DateTime.UtcNow.AddMinutes(10);
            //await _otpW.CreateAsync(userId, "signup", otpHash, salt, expires);
            await _otpW.CreateAsync(userId, "signup", expires);


            var to = string.IsNullOrWhiteSpace(schoolEmailFromRoster) ? emailNorm : schoolEmailFromRoster;
            await _email.SendAsync(to, "Mã OTP xác minh đăng ký",
                $"Xin chào {user.FullName},\n\nMã OTP của bạn là: {otp}\nMã sẽ hết hạn sau 10 phút.", ct);

            return Result<Guid>.Success(userId);
        }
    }
}
