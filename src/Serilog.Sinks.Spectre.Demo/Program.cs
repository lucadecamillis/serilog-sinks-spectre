using Serilog.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Serilog.Sinks.Spectre.Demo
{
	class Program
	{
		private static Microsoft.Extensions.Logging.ILogger logger;

		static void Main(string[] args)
		{
			Logger inner = ConfigureLogger();

			Microsoft.Extensions.Logging.ILoggerFactory loggerFactory = new Microsoft.Extensions.Logging.LoggerFactory();
			loggerFactory.AddSerilog(inner, dispose: true);

			logger = loggerFactory.CreateLogger("Program");

			SpaceLibrary library = new SpaceLibrary(logger);

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
}