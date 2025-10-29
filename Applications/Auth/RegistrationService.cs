using StudentCourseManagement.Applications.Dtos;
using StudentCourseManagement.Applications.Validation;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Abstractions.Services;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Domain.Results;
using StudentCourseManagement.Infrastructure.Security.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace StudentCourseManagement.Applications.Auth
{
     public sealed class RegistrationService
    {
        private readonly IUsersReader _userR;
        private readonly IUsersWriter _userW;
        private readonly IPrivilegesReader _privR;
        private readonly IPrivilegesWriter _privW;
        private readonly IOtpPinsReader _otpR;
        private readonly IOtpPinsWriter _otpW;
        private readonly IEmailService _email;
        private readonly IClock _clock;
        private readonly IRosterReader _rosterR;

        public RegistrationService(
            IUsersReader userR,
            IUsersWriter userW,
            IPrivilegesReader privR,
            IPrivilegesWriter privW,
            IOtpPinsReader otpR,
            IOtpPinsWriter otpW,
            IEmailService email,
            IClock clock,
            IRosterReader rosterR
            )
        {
            _userR = userR;
            _userW = userW;
            _privR = privR;
            _privW = privW;
            _otpR = otpR;
            _otpW = otpW;
            _email = email;
            _clock = clock;
            _rosterR = rosterR;
        }

        // validate chuan hoa dau vao
        public async Task<Result<Guid>> RegisterStudentAsync(
                RegisterStudentDto dto,
                string? schoolEmailFromRoster,
                CancellationToken ct = default
            )
        {

            var fullName = Normalizers.NormalizeFullName(dto.FullName);
            if (!RegexRules.IsMatch(fullName, RegexRules.FullNameBasic))
                return Result<Guid>.Fail("Họ tên không hợp lệ");

            if (!RegexRules.IsMatch(dto.CCCD, RegexRules.Cccd))
                return Result<Guid>.Fail("Cccd phải gồm 12 chữ số ");

            if (!RegexRules.IsMatch(dto.Email, RegexRules.Email))
                return Result<Guid>.Fail("Email không hợp lệ");
            if (!RegexRules.IsMatch(dto.Password, RegexRules.PasswordStrong))
                return Result<Guid>.Fail("Mật khẩu chưa đủ mạnh.");

            if (string.IsNullOrWhiteSpace(dto.StudentCode))
                return Result<Guid>.Fail("MSV là bắt buộc.");

            var phone = Normalizers.NormalizePhoneToVN(dto.Phone);

            var emailNorm = Normalizers.NormalizeEmail(dto.Email);

            // check trung
            if (await _userR.EmailExistsAsync(emailNorm))
                return Result<Guid>.Fail("Email đã tồn tại ");
            if (await _userR.CccdExistsAsync(dto.CCCD))
                return Result<Guid>.Fail("Cccd đã tồn tại");
            if (await _userR.StudentCodeExistsAsync(dto.StudentCode))
                return Result<Guid>.Fail("MSV này đã tồn tại");

            // bam mk
            var hash = PasswordHasher.Hash(dto.Password);

            // tao user
            var user = new User
            {
                FullName = fullName,
                EmailNormalized = emailNorm,
                PasswordHash = hash,
                CCCD = dto.CCCD,
                PhoneE164 = phone,
                Role = "user",
                StudentCode = dto.StudentCode,
                EmailVerified = true ,
                
                IsLocked = false,
                CreatedAtUtc = _clock.UtcNow(),
                UpdatedAtUtc = _clock.UtcNow()
            };

            var roster = await _rosterR.FindByStudentCodeAsync(dto.StudentCode, ct);
            string? schoolEmail = null;

            if (roster is not null)
            {
                user.RosterId = roster.Id;
                user.ClassId = roster.ClassId;
                user.MajorId = roster.MajorId;
                user.SpecializationId = roster.SpecializationId;
                user.CohortYear = roster.CohortYear;
                user.Gender = roster.Gender;
                user.Address = roster.Address;
                schoolEmail = roster.EmailSchool;

                await _userW.LinkRosterUsedAsync(roster.Id, ct);
            }




            var userId = await _userW.CreateAsync(user);

            var otp = OtpHasher.GenerateOtp6();
            var (otpHash, salt) = OtpHasher.HashOtp(otp);
            var expires = DateTime.UtcNow.AddMinutes(10);
            await _otpW.CreateAsync(userId, "signup", otpHash, salt, expires);

            // email OTP (uu tien email truong cap)
            var to = string.IsNullOrWhiteSpace(schoolEmail) ? emailNorm : schoolEmail;
            await _email.SendAsync(
                to,
                "Mã OTP xác minh đăng ký",
                $"Xin chào {user.FullName},\n\nMã OTP của bạn là: {otp}\nMã sẽ hết hạn sau 10 phút.",
                ct);

            return Result<Guid>.Success(userId);



        }
    }
}
