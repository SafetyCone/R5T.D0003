using System;
using System.Diagnostics;
using System.Threading.Tasks;using R5T.T0064;


namespace R5T.D0003.Default
{[ServiceImplementationMarker]
    public class ProcessStartTimeProvider : IProcessStartTimeProvider,IServiceImplementation
    {
        public Task<DateTime> GetProcessStartTimeAsync()
        {
            var currentProcess = Process.GetCurrentProcess();

            var currentProcessStartTime = currentProcess.StartTime;

            return Task.FromResult(currentProcessStartTime);
        }
    }
}
