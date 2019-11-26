using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Xunit;

namespace ScholarlySoftwareSearchTests {
    public class EndPointTests
    : IClassFixture<WebApplicationFactory<ScholarlySoftwareSearch.Startup>> {
        private readonly WebApplicationFactory<ScholarlySoftwareSearch.Startup> _factory;

        public EndPointTests(WebApplicationFactory<ScholarlySoftwareSearch.Startup> factory) {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Index")]
        [InlineData("/About")]
        [InlineData("/Privacy")]
        [InlineData("/Contact")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url) {
            // ACreates a client from the CustomWebApplicationFactory.
            var client = _factory.CreateClient();

            // Performs a get request on the url.
            var response = await client.GetAsync(url);

            // Determines whether the get request was successful or not.
            response.EnsureSuccessStatusCode(); // Should return status Code 200-299.
            Assert.Equals("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
