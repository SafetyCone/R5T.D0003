using System;
using System.Threading.Tasks;using R5T.T0064;


namespace R5T.D0003.Default
{[ServiceImplementationMarker]
    public class StaticValueProcessStartTimeProvider : IProcessStartTimeProvider,IServiceImplementation
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
