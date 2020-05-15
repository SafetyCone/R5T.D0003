using System;
using System.Threading.Tasks;


namespace R5T.D0003.Default
{
    public class ConstructorValueProcessStartTimeProvider : IProcessStartTimeProvider
    {
        #region Static

        public static ConstructorValueProcessStartTimeProvider NewFromNowLocal(DateTime nowLocal)
        {
            var constructorValueProcessStartTimeProvider = new ConstructorValueProcessStartTimeProvider(nowLocal);
            return constructorValueProcessStartTimeProvider;
        }

        /// <summary>
        /// Uses the <see cref="ConstructorValueProcessStartTimeProvider.NewFromNowLocal(DateTime)"/> as the default.
        /// </summary>
        public static ConstructorValueProcessStartTimeProvider New(DateTime now)
        {
            var constructorValueProcessStartTimeProvider = ConstructorValueProcessStartTimeProvider.NewFromNowLocal(now);
            return constructorValueProcessStartTimeProvider;
        }

        public static ConstructorValueProcessStartTimeProvider NewFromNowUtc(DateTime nowUtc)
        {
            var nowLocal = nowUtc.ToLocalTime();

            var constructorValueProcessStartTimeProvider = new ConstructorValueProcessStartTimeProvider(nowLocal);
            return constructorValueProcessStartTimeProvider;
        }

        public static ConstructorValueProcessStartTimeProvider NewFromOffset(TimeSpan offset)
        {
            var offsetNow = DateTime.Now + offset;

            var constructorValueProcessStartTimeProvider = ConstructorValueProcessStartTimeProvider.NewFromNowLocal(offsetNow);
            return constructorValueProcessStartTimeProvider;
        }

        #endregion


        private DateTime ProcessStartTime { get; }


        public ConstructorValueProcessStartTimeProvider(DateTime processStartTime)
        {
            this.ProcessStartTime = processStartTime;
        }

        public Task<DateTime> GetProcessStartTimeAsync()
        {
            return Task.FromResult(this.ProcessStartTime);
        }
    }
}
