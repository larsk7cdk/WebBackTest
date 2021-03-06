using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using WebBackTest.web;
using Xunit;

namespace WebBackTest.IntegrationTest
{
    public class UrlTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        public UrlTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        private readonly WebApplicationFactory<Startup> _factory;

        [Theory]
        [InlineData("/")]
        [InlineData("/ToDo")]
        [InlineData("/ToDo/Index")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}