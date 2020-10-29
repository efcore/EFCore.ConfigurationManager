using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable EF1001

namespace EntityFrameworkCore.ConfigurationManager
{
    /// <summary>
    /// Contains extension methods on <see cref="IServiceCollection"/> for the EntityFrameworkCore.ConfigurationManager library.
    /// </summary>
    public static class ConfigurationManagerServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the services provided by the EntityFrameworkCore.ConfigurationManager library.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>The same service collection instance so that multiple calls can be chained.</returns>
        public static IServiceCollection AddEntityFrameworkConfigurationManager(this IServiceCollection serviceCollection)
        {
            new EntityFrameworkRelationalServicesBuilder(serviceCollection)
                .TryAddProviderSpecificServices(
                    x => x.TryAddScoped<INamedConnectionStringResolver, ConfigrationManagerConnectionStringResolver>());

            return serviceCollection;
        }
    }
}
