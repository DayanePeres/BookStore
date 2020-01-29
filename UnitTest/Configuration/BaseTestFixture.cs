using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Configuration
{
    public class BaseTestFixture : IDisposable
    { //classe que o xunit vai compartilhar as propriedades em todos os testes
        //teste de integração quando testa ponta a ponta a API.
        // link do vídeo aula: https://www.youtube.com/watch?v=KfpiWFNZzFI - 1h06m

        public readonly TestServer Server;

        public readonly HttpClient Cliente;

        public readonly DataContext TestDataContext; 

        public readonly IConfigurationRoot Configuration;

        public BaseTestFixture()
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //Em cenários do get, precisa fazer comunicação com o banco para poder testar
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{envName}.json", optional: true)
                .AddEnronmentVariables();

            Configuration = builder.Builder();

            var opts = new DbContextOptionsBuilder<MyContext>();
            opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            TestDataContext = new MyContext(opts.Options);
            SetupDataBase();

            Server = new TestServer(new WebHostBuilder().UserStartup<Startup>());
            Cliente = testServer.CreateClient();
        }

        private void SetupDataBase()
        {
            try
            {
                TestDataContext.Database.EnsureCreated();
                TestDataContext.Database.Migrate();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            TestDataContext.Dispose();
            Cliente.Dispose();
            Server.Dispose();
        }
    }
}
