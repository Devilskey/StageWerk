using Serilog;

namespace AlertDefinitions.Api;

static class Program
{
    /// <summary>
    /// Task Main
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static async Task Main(string[] args)
    {
        IHost run = CreateHostBuilder(args)
            .UseSerilog()
            .Build();
        await run.RunAsync();
    }

    /// <summary>
    /// Creates the hostBuilder
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                config
                     .AddJsonFile("appsettings.json", false)
                     .AddJsonFile($"appsettings.{environmentName}.json", true)
                     .AddJsonFile("serilog.json", false)
                     .AddJsonFile($"serilog.{environmentName}.json", true)
                     .AddEnvironmentVariables();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            webBuilder
                .UseStartup<Startup>());
    }
}