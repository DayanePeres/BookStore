using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Configuration
{
    public abstract class BaseIntegrationTest
    {
        protected readonly TestServer testServer;
        protected readonly HttpClient Cliente;
        protected readonly DataContext TestDataContext;

        protected BaseTestFixture Fixture { get; set; }
    }
}
