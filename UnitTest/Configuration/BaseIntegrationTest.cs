using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Configuration
{
    [Collection("Base Collection")]

    public abstract class BaseIntegrationTest
    {
        protected readonly TestServer Server;

        protected readonly HttpClient Cliente;

        protected readonly DataContext TestDataContext;

        protected BaseTestFixture Fixture { get; set; }

        protected BaseIntegrationTest(BaseTestFixture fixture)
        {
            Fixture = fixture;

            TestDataContext = fixture.TestDataContext;
            Server = fixture.Server;
            Cliente = fixture.Cliente;

            ClearDb().Wait();
        }

        private async Task ClearDb()
        {
            var commands = new[]
            {
                "EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'",
                "EXEC SP_MSForEachTable 'DELTE FROM ? '",
                "EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'"
            };

            await TestDbConext.Database.OpenConnectionAsync();

            foreach (var command in commands)
            {
                await TestDbContext.Database.ExecuteSqlCommandAsync(command);
            }

            TestDbContext.Database.CloseConnection();
        }
    }
}
