using System;
using System.Threading.Tasks;   


namespace R5T.D0003
{
    public static class IProcessStartTimeProviderExtensions
    {
        public static async Task<DateTime> GetProcessStartTimeUtcAsync(this IProcessStartTimeProvider processStartTimeProvider)
        {
            var processStartTime = await processStartTimeProvider.GetProcessStartTimeAsync();

            var processStartTimeUtc = processStartTime.ToUniversalTime();
            return processStartTimeUtc;
        }
    }
}
