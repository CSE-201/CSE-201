using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Xunit;

namespace ScholarlySoftwareSearchTests {
    public class IndexPageTests :
    IClassFixture<CustomWebApplicationFactory<ScholarlySoftwareSearch.Startup>> {

        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<ScholarlySoftwareSearch.Startup>
            _factory;

        /// <summary>
        /// Constructs an instance of IndexPageTests. An integration test class. Run using xUnit.
        /// </summary>
        /// <param name="factory"></param>
        public IndexPageTests(CustomWebApplicationFactory<ScholarlySoftwareSearch.Startup> factory) {
            // Default client option values are shown
            var clientOptions = new WebApplicationFactoryClientOptions();
            clientOptions.AllowAutoRedirect = true;
            clientOptions.BaseAddress = new Uri("http://localhost");
            clientOptions.HandleCookies = true;
            clientOptions.MaxAutomaticRedirections = 7;


            _factory = factory;
            _client = _factory.CreateClient(clientOptions);
        }

    }
}
