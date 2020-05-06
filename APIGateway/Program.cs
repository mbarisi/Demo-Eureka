using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;

namespace APIGateway
{
  public class Program
  {
    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
               .UseUrls("http://*:9000")
           .ConfigureAppConfiguration((hostingContext, config) =>
            {
              config
                      .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                      .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                      .AddEnvironmentVariables();
            })
           .ConfigureServices(s =>
            {
              s.AddOcelot()
                .AddConsul().AddPolly();
            })
            .Configure(a =>
            {
              a.UseOcelot().Wait();
            })
            .Build();
  }
}
