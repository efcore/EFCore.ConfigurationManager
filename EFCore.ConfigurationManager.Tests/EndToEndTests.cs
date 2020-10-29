using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

#pragma warning disable EF1001

namespace EntityFrameworkCore.ConfigurationManager
{
    public class EndToEndTests
    {
        [Fact]
        public void Runtime_works()
        {
            using var db = new TestContext();

            var dbConnection = db.Database.GetDbConnection();

            Assert.Equal("Test.db", dbConnection.DataSource);
        }

        [Fact]
        public void Design_time_works()
        {
            var services = new DesignTimeServicesBuilder(
                    typeof(EndToEndTests).Assembly,
                    typeof(EndToEndTests).Assembly,
                    new OperationReporter(null),
                    Array.Empty<string>())
                .Build("Microsoft.EntityFrameworkCore.Sqlite");

            var namedConnectionStringResolver = services.GetService<INamedConnectionStringResolver>();

            Assert.IsType<ConfigrationManagerConnectionStringResolver>(namedConnectionStringResolver);
        }

        class TestContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options
                    .UseConfigurationManager()
                    .UseSqlite("Name=TestConnection");
        }
    }
}
