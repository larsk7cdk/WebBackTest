using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace WebBackTest.IntegrationTest.Controllers
{
    public class TodoControllerTest : IClassFixture<CustomWebApplicationFactory<web.Startup>>
    {
        private readonly CustomWebApplicationFactory<web.Startup> _factory;
        private readonly HttpClient _client;

        public TodoControllerTest(CustomWebApplicationFactory<web.Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_IndexToDo_Schould_ReturnIndexWithSuccess()
        {
            // Arrange
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            //Act
            

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}