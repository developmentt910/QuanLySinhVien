
using StudentCourseManagement.Infrastructure.Security.Crypto;

namespace StudentCourseManagement.Applications.Auth
{
    public sealed class OtpVerificationService
    {
        private const int MAX_ATTEMPTS_PER_OTP = 5;

        private readonly IOtpPinsReader _otpR;
        private readonly IOtpPinsWriter _otpW;
        private readonly IUsersWriter _usersW;
        private readonly IClock _clock;

        public OtpVerificationService(
            IOtpPinsReader otpR,
            IOtpPinsWriter otpW,
            IUsersWriter usersW,
            IClock clock)
        {
            _otpR = otpR;
            _otpW = otpW;
            _usersW = usersW;
            _clock = clock;
        }

        public async Task<bool> VerifyOtpAsync(Guid userId, string purpose, string otp, CancellationToken ct = default)
        {
            var tuple = await _otpR.GetLastActiveAsync(userId, purpose, ct);
            if (tuple is null) return false;

            var (id, codeHash, salt, expiresAtUtc, attemptCount) = tuple.Value;

            var now = _clock.UtcNow();
            if (now > expiresAtUtc) return false;

            if (attemptCount >= MAX_ATTEMPTS_PER_OTP) return false;

            var ok = OtpHasher.VerifyOtp(otp, salt, codeHash);
            if (!ok)
            {
                await _otpW.IncrementAttemptAsync(id, ct);
                return false;
            }

            await _otpW.ConsumeAsync(id, ct);

            if (purpose.Equals("signup", StringComparison.OrdinalIgnoreCase))
            {
                await _usersW.MarkEmailVerifiedAsync(userId, now, ct);
            }

            return true;
        }
    }
}
