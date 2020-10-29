using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable EF1001

namespace EntityFrameworkCore.ConfigurationManager
{
    class ConfigurationManagerDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
            => serviceCollection
                .AddSingleton<INamedConnectionStringResolver, ConfigrationManagerConnectionStringResolver>();
    }
}
