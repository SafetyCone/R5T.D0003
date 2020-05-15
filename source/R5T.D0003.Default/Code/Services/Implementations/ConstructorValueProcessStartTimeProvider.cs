using System;
using System.Threading.Tasks;


namespace R5T.D0003.Default
{
    public class ConstructorValueProcessStartTimeProvider : IProcessStartTimeProvider
    {
        #region Static

        public static ConstructorValueProcessStartTimeProvider NewFromLocalNow(DateTime localNow)
        {
            var constructorValueProcessStartTimeProvider = new ConstructorValueProcessStartTimeProvider(localNow);
            return constructorValueProcessStartTimeProvider;
        }

        /// <summary>
        /// Uses the <see cref="ConstructorValueProcessStartTimeProvider.NewFromLocalNow(DateTime)"/> as the default.
        /// </summary>
        public static ConstructorValueProcessStartTimeProvider New(DateTime now)
        {
            var constructorValueProcessStartTimeProvider = ConstructorValueProcessStartTimeProvider.NewFromLocalNow(now);
            return constructorValueProcessStartTimeProvider;
        }

        public static ConstructorValueProcessStartTimeProvider NewFromUtcNow(DateTime utcNow)
        {
            var localNow = utcNow.ToLocalTime();

            var constructorValueProcessStartTimeProvider = new ConstructorValueProcessStartTimeProvider(localNow);
            return constructorValueProcessStartTimeProvider;
        }

        public static ConstructorValueProcessStartTimeProvider NewFromOffset(TimeSpan offset)
        {
            var offsetNow = DateTime.Now + offset;

            var constructorValueProcessStartTimeProvider = ConstructorValueProcessStartTimeProvider.NewFromLocalNow(offsetNow);
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
