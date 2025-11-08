
namespace StudentCourseManagement.Applications.Security
{
    // gh 5l/mins
    public sealed class ThrottleService
    {
        private readonly ILoginThrottleStore _store;
        private readonly TimeSpan _window = TimeSpan.FromMinutes(10);
        private readonly int _limit = 5;

        public ThrottleService(ILoginThrottleStore store) 
        {
            _store = store;
        }

      
        public async Task<bool> AllowAsync(string scope, byte[] keyHash, DateTime nowUtc)
        {
            var windowStart = new DateTime((nowUtc.Ticks / _window.Ticks) * _window.Ticks, DateTimeKind.Utc);
            var count = await _store.IncrementAndGetAsync(scope, keyHash, windowStart);
            return count <= _limit;
        }
        public Task ResetAsync(string scope, byte[] keyHash) => _store.ResetScopeAsync(scope, keyHash);
    }

}

