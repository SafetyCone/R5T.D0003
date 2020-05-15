using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.D0003.Default
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Adds the <see cref="ProcessStartTimeProvider"/> implementation of <see cref="IProcessStartTimeProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDefaultProcessStartTimeProvider(this IServiceCollection services)
        {
            services.AddSingleton<IProcessStartTimeProvider, ProcessStartTimeProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ProcessStartTimeProvider"/> implementation of <see cref="IProcessStartTimeProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IProcessStartTimeProvider> AddDefaultProcessStartTimeProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction<IProcessStartTimeProvider>.New(() => services.AddDefaultProcessStartTimeProvider());
            return serviceAction;
        }
    }
}
