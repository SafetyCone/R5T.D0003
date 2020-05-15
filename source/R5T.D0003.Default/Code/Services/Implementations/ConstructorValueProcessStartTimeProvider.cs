using System;
using System.Threading.Tasks;


namespace R5T.D0003.Default
{
    public class ConstructorValueProcessStartTimeProvider : IProcessStartTimeProvider
    {
        #region Static

        public static ConstructorValueProcessStartTimeProvider NewFromLocal(DateTime localTime)
        {
            var constructorValueProcessStartTimeProvider = new ConstructorValueProcessStartTimeProvider(localTime);
            return constructorValueProcessStartTimeProvider;
        }

        /// <summary>
        /// Uses the <see cref="ConstructorValueProcessStartTimeProvider.NewFromLocal(DateTime)"/> as the default.
        /// </summary>
        public static ConstructorValueProcessStartTimeProvider New(DateTime localTime)
        {
            var constructorValueProcessStartTimeProvider = ConstructorValueProcessStartTimeProvider.NewFromLocal(localTime);
            return constructorValueProcessStartTimeProvider;
        }

        public static ConstructorValueProcessStartTimeProvider NewFromUtc(DateTime utcTime)
        {
            var localTime = utcTime.ToLocalTime();

            var constructorValueProcessStartTimeProvider = new ConstructorValueProcessStartTimeProvider(localTime);
            return constructorValueProcessStartTimeProvider;
        }

        public static ConstructorValueProcessStartTimeProvider NewFromOffset(TimeSpan offset)
        {
            var offsetNow = DateTime.Now + offset;

            var constructorValueProcessStartTimeProvider = ConstructorValueProcessStartTimeProvider.NewFromLocal(offsetNow);
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
