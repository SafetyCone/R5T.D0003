using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace R5T.D0003.Default
{
    public class OffsetProcessStartTimeProvider : IProcessStartTimeProvider
    {
        #region Static

        public static OffsetProcessStartTimeProvider NewFromOffset(TimeSpan offset)
        {
            var offsetProcessStartTimeProvider = new OffsetProcessStartTimeProvider(offset);
            return offsetProcessStartTimeProvider;
        }

        public static OffsetProcessStartTimeProvider New(TimeSpan offset)
        {
            var offsetProcessStartTimeProvider = OffsetProcessStartTimeProvider.NewFromOffset(offset);
            return offsetProcessStartTimeProvider;
        }

        public static OffsetProcessStartTimeProvider NewFromDesiredUtcNow(DateTime desiredUtcNow)
        {
            var offset = DateTime.UtcNow - desiredUtcNow;

            var offsetProcessStartTimeProvider = OffsetProcessStartTimeProvider.NewFromOffset(offset);
            return offsetProcessStartTimeProvider;
        }

        public static OffsetProcessStartTimeProvider NewFromDesiredLocalNow(DateTime desiredLocalNow)
        {
            var offset = DateTime.Now - desiredLocalNow;

            var offsetProcessStartTimeProvider = OffsetProcessStartTimeProvider.NewFromOffset(offset);
            return offsetProcessStartTimeProvider;
        }

        #endregion


        private TimeSpan Offset { get; }


        public OffsetProcessStartTimeProvider(TimeSpan offset)
        {
            this.Offset = offset;
        }

        public Task<DateTime> GetProcessStartTimeAsync()
        {
            var currentProcess = Process.GetCurrentProcess();

            var currentProcessStartTime = currentProcess.StartTime;

            var offsetCurrentProcessStartTime = currentProcessStartTime + this.Offset;
            return Task.FromResult(offsetCurrentProcessStartTime);
        }
    }
}
