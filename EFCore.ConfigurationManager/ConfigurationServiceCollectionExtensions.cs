using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.ConfigurationManager
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkConfigurationManager(this IServiceCollection serviceCollection)
        {
            new EntityFrameworkRelationalServicesBuilder(serviceCollection)
                .TryAddProviderSpecificServices(
                    x => x.TryAddScoped<INamedConnectionStringResolver, ConfigrationManagerConnectionStringResolver>());

            return serviceCollection;
        }
    }
}
