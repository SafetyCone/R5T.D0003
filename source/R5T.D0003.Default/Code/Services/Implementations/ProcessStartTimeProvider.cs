using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace R5T.D0003.Default
{
    public class ProcessStartTimeProvider : IProcessStartTimeProvider
    {
        public Task<DateTime> GetProcessStartTimeAsync()
        {
            var currentProcess = Process.GetCurrentProcess();

            var currentProcessStartTime = currentProcess.StartTime;
            return Task.FromResult(currentProcessStartTime);
        }
    }
}
