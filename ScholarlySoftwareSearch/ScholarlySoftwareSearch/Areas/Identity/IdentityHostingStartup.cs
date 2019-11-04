using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ScholarlySoftwareSearch.Areas.Identity.IdentityHostingStartup))]
namespace ScholarlySoftwareSearch.Areas.Identity {
    public class IdentityHostingStartup : IHostingStartup {
        public void Configure(IWebHostBuilder builder) {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}