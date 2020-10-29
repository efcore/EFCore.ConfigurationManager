using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFrameworkCore.ConfigurationManager
{
    /// <summary>
    /// Contains extension methods on <see cref="DbContextOptionsBuilder"/> for the EntityFrameworkCore.ConfigurationManager library.
    /// </summary>
    public static class ConfigurationManagerDbContextOptionsBuilder
    {
        /// <summary>
        /// Extends Entity Framework Core to resolve connection strings from App.config.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        /// <returns>The same builder instance so that multiple calls can be chained.</returns>
        public static DbContextOptionsBuilder UseConfigurationManager(this DbContextOptionsBuilder optionsBuilder)
        {
            var extension = optionsBuilder.Options.FindExtension<ConfigurationManagerDbContextOptionsExtension>()
                ?? new ConfigurationManagerDbContextOptionsExtension();

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

            return optionsBuilder;
        }

        /// <summary>
        /// Extends Entity Framework Core to resolve connection strings from App.config.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        /// <returns>The same builder instance so that multiple calls can be chained.</returns>
        public static DbContextOptionsBuilder<TContext> UseConfigurationManager<TContext>(this DbContextOptionsBuilder<TContext> optionsBuilder)
            where TContext : DbContext
            => (DbContextOptionsBuilder<TContext>)UseConfigurationManager((DbContextOptionsBuilder)optionsBuilder);
    }
}
