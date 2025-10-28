// Application/Auth/OtpVerificationService.cs

using StudentCourseManagement.Infrastructure.Security.Crypto;

namespace StudentCourseManagement.Applications.Auth
{
    public sealed class OtpVerificationService
    {
        private const int MAX_ATTEMPTS_PER_OTP = 5;

        private readonly IOtpPinsReader _otpR;
        private readonly IOtpPinsWriter _otpW;
        private readonly IUsersWriter _usersW;
        private readonly IPrivilegesReader _privR;
        private readonly IPrivilegesWriter _privW;
        private readonly IAuditLogsWriter _audit;
        private readonly IClock _clock;

        public OtpVerificationService(
            IOtpPinsReader otpR,
            IOtpPinsWriter otpW,
            IUsersWriter usersW,
            IPrivilegesReader privR,
            IPrivilegesWriter privW,
            IAuditLogsWriter audit,
            IClock clock)
        {
            _otpR = otpR;
            _otpW = otpW;
            _usersW = usersW;
            _privR = privR;
            _privW = privW;
            _audit = audit;
            _clock = clock;
        }

        public async Task<bool> VerifyOtpAsync(Guid userId, string purpose, string otp, CancellationToken ct = default)
        {
            var tuple = await _otpR.GetLastActiveAsync(userId, purpose, ct);
            if (tuple is null)
            {
                await LogAsync(userId, "otp_failed", $"purpose:{purpose};reason:none_active", ct);
                return false;
            }

            var (id, codeHash, salt, expiresAtUtc, attemptCount) = tuple.Value;

            var now = _clock.UtcNow();
            if (now > expiresAtUtc)
            {
                await LogAsync(userId, "otp_failed", $"purpose:{purpose};reason:expired", ct);
                return false;
            }

            if (attemptCount >= MAX_ATTEMPTS_PER_OTP)
            {
                await LogAsync(userId, "otp_failed", $"purpose:{purpose};reason:max_attempts", ct);
                return false;
            }

            var ok = OtpHasher.VerifyOtp(otp, salt, codeHash);
            if (!ok)
            {
                await _otpW.IncrementAttemptAsync(id, ct);
                await LogAsync(userId, "otp_failed", $"purpose:{purpose};reason:mismatch", ct);
                return false;
            }

            await _otpW.ConsumeAsync(id,ct);

            if (purpose.Equals("signup", StringComparison.OrdinalIgnoreCase))
            {
                await _usersW.MarkEmailVerifiedAsync(userId, now, ct);
            }

            await LogAsync(userId, "otp_success", $"purpose:{purpose}", ct);
            return true;
        }

        private Task LogAsync(Guid userId, string action, string detail, CancellationToken ct)
            => _audit.WriteAsync(new AuditLogEntry
            {
                UserId = userId,
                Action = action,
                Detail = detail,
                CreatedAtUtc = _clock.UtcNow()
            }, ct);
    }
}
