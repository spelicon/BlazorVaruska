using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace XUnitIntegrationTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var hostBuilder = new HostBuilder().ConfigureWebHost(webHost =>
            {
                // Add TestServer
                webHost.UseTestServer();

                // Specify the environment
                webHost.UseEnvironment("Test");

                webHost.Configure(app => app.Run(async ctx => await ctx.Response.WriteAsync("Hello World!")));
            });

            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            //responseString.Should().Be("Hello World!");
        }
    }
}
