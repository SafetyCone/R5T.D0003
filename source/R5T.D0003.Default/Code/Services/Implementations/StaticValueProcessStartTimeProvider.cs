using System;
using System.Threading.Tasks;


namespace R5T.D0003.Default
{
    public class StaticValueProcessStartTimeProvider : IProcessStartTimeProvider
    {
        /// <summary>
        /// Note: not thread-safe.
        /// </summary>
        public static DateTime ProcessStartTime { get; set; }


        public Task<DateTime> GetProcessStartTimeAsync()
        {
            return Task.FromResult(StaticValueProcessStartTimeProvider.ProcessStartTime);
        }
    }
}
