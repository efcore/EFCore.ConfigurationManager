using System;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace EntityFrameworkCore.ConfigurationManager
{
    class ConfigrationManagerConnectionStringResolver : INamedConnectionStringResolver
    {
        public string ResolveConnectionString(string connectionString)
        {
            var parts = connectionString.Split(new[] { '=' }, 2);
            if (parts.Length != 2
                || !parts[0].Trim().Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                return connectionString;
            }

            var connectionName = parts[1].Trim();

            var element = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName];
            if (element is null)
            {
                throw new InvalidOperationException(RelationalStrings.NamedConnectionStringNotFound(connectionName));
            }

            return element.ConnectionString;
        }
    }
}
