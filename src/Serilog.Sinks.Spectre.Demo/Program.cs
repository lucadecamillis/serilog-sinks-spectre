using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System.IO;

namespace Serilog.Sinks.Spectre.Demo;

internal class Program
{
    private static Microsoft.Extensions.Logging.ILogger logger;

    private static void Main(string[] args)
    {
        var inner = ConfigureLogger();
        ILoggerFactory loggerFactory = new LoggerFactory();
        loggerFactory.AddSerilog(inner, true);
        logger = loggerFactory.CreateLogger("Program");
        var library = new SpaceLibrary(logger);
        logger.LogInformation("Start space library");
        library.Run().Wait();
        logger.LogInformation("Done with the space library");
    }

    private static Logger ConfigureLogger()
    {
        var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
        return new LoggerConfiguration()
               .ReadFrom
               .Configuration(configuration)
               .CreateLogger();
        /*return new LoggerConfiguration()
            .WriteTo
            .Spectre()
            .MinimumLevel.Verbose()
            .CreateLogger();*/
    }
}