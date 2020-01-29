using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Controllers
{
    [TestClass]
    public class BookControllerIntegrationTest : BaseIntegrationTest
    {
        private const string BaseUrl = "/api/book";

        public BookControllerIntegrationTest(BaseTestFixture fixture) : base(fixture)
        {

        }

        [Fact]
        [TestMethod]
        public async Task DeveRetornaListaDeLivrosVazia()
        {
            var response = await Client.GetAsync(BaseUrl);
            response.EnsureSucessStatusCode();

            var responseString = await response.Content.ReadAsStreamAsync();
            var data = JsonConvert.DeserializeOgject<List<Book>>(responseString);

            Assert.Equal(data.count, 0);
        }
    }
}
