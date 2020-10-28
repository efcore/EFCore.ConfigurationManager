using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFrameworkCore.ConfigurationManager
{
    public static class ConfigurationManagerDbContextOptionsBuilder
    {
        public static DbContextOptionsBuilder UseConfigurationManager(this DbContextOptionsBuilder optionsBuilder)
        {
            var extension = optionsBuilder.Options.FindExtension<ConfigurationManagerDbContextOptionsExtension>()
                ?? new ConfigurationManagerDbContextOptionsExtension();

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

            return optionsBuilder;
        }

        public static DbContextOptionsBuilder<TContext> UseConfigurationManager<TContext>(this DbContextOptionsBuilder<TContext> optionsBuilder)
            where TContext : DbContext
            => (DbContextOptionsBuilder<TContext>)UseConfigurationManager((DbContextOptionsBuilder)optionsBuilder);
    }
}
