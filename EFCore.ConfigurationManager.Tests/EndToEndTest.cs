using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EntityFrameworkCore.ConfigurationManager
{
    public class EndToEndTest
    {
        [Fact]
        public void Runtime_works()
        {
            using var db = new TestContext();
            
            var dbConnection = db.Database.GetDbConnection();

            Assert.Equal("Test.db", dbConnection.DataSource);
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
