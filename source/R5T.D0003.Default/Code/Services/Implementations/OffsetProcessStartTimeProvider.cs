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

        /// <summary>
        /// Uses the <see cref="OffsetProcessStartTimeProvider.NewFromOffset(TimeSpan)"/> as the default.
        /// </summary>
        public static OffsetProcessStartTimeProvider New(TimeSpan offset)
        {
            var offsetProcessStartTimeProvider = OffsetProcessStartTimeProvider.NewFromOffset(offset);
            return offsetProcessStartTimeProvider;
        }

        public static OffsetProcessStartTimeProvider NewFromDesiredNowUtc(DateTime desiredNowUtc)
        {
            var offset = DateTime.UtcNow - desiredNowUtc;

            var offsetProcessStartTimeProvider = OffsetProcessStartTimeProvider.NewFromOffset(offset);
            return offsetProcessStartTimeProvider;
        }

        public static OffsetProcessStartTimeProvider NewFromDesiredNowLocal(DateTime desiredNowLocal)
        {
            var offset = DateTime.Now - desiredNowLocal;

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
