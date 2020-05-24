using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using BlazorVaruska.Shared;
using System.Text.Json;
using System.Collections.Generic;

namespace XUnitIntegrationTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var hostBuilder = new HostBuilder().ConfigureWebHost(webHost =>
            {
                webHost.ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
                });
                // Add TestServer
                webHost.UseTestServer();

                webHost.UseStartup<BlazorVaruska.Server.Startup>();
                // Specify the environment
            });

            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync("/city");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            var obj = JsonSerializer.Deserialize(responseString, typeof(List<City>));
            response.EnsureSuccessStatusCode();
            //responseString.Should().Be("Hello World!");
        }
    }
}
