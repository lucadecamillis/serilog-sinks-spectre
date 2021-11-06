using Serilog;
using Serilog.Core;
using Microsoft.Extensions.Logging;
using sconsole.Sink;
using sconsole.Lib;

namespace sconsole
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
			return new LoggerConfiguration()
				.WriteTo
				.StealthConsoleSink()
				.MinimumLevel.Verbose()
				.CreateLogger();
		}
	}
}