using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0003.Default;


namespace R5T.D0003.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IProcessStartTimeProvider"/> service.
        /// </summary>
        public static IServiceCollection AddProcessStartTimeProvider(this IServiceCollection services)
        {
            services.AddDefaultProcessStartTimeProvider();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IProcessStartTimeProvider"/> service.
        /// </summary>
        public static ServiceAction<IProcessStartTimeProvider> AddProcessStartTimeProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction<IProcessStartTimeProvider>.New(() => services.AddProcessStartTimeProvider());
            return serviceAction;
        }
    }
}
