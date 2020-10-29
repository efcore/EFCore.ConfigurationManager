using System;
using System.Collections.Generic;
using EntityFrameworkCore.ConfigurationManager.Properties;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable EF1001

namespace EntityFrameworkCore.ConfigurationManager
{
    class ConfigurationManagerDbContextOptionsExtension : IDbContextOptionsExtension
    {
        DbContextOptionsExtensionInfo _info;
        public DbContextOptionsExtensionInfo Info
            => _info ??= new ExtensionInfo(this);

        public void ApplyServices(IServiceCollection services)
            => services.AddEntityFrameworkConfigurationManager();

        public void Validate(IDbContextOptions options)
        {
            var internalServiceProvider = options.FindExtension<CoreOptionsExtension>()?.InternalServiceProvider;
            if (internalServiceProvider != null)
            {
                using var scope = internalServiceProvider.CreateScope();
                var resolver = scope.ServiceProvider.GetService<INamedConnectionStringResolver>();

                if (!(resolver is ConfigrationManagerConnectionStringResolver))
                {
                    throw new InvalidOperationException(Resources.ServicesMissing);
                }
            }
        }

        sealed class ExtensionInfo : DbContextOptionsExtensionInfo
        {
            public ExtensionInfo(IDbContextOptionsExtension extension)
                : base(extension)
            {
            }

            public override bool IsDatabaseProvider
                => false;

            public override string LogFragment
                => "using ConfigurationManager ";

            public override long GetServiceProviderHashCode()
                => 0;

            public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
                => debugInfo["ConfigurationManager"] = "1";
        }
    }
}
