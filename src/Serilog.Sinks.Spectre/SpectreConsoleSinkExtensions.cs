using System;
using Serilog;
using Serilog.Configuration;

namespace Serilog.Sinks.Spectre
{
	public static class SpectreConsoleSinkExtensions
	{
		const string DefaultConsoleOutputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";

		public static LoggerConfiguration Spectre(
			this LoggerSinkConfiguration loggerConfiguration,
			string outputTemplate = DefaultConsoleOutputTemplate)
		{
			return loggerConfiguration.Sink(new SpectreConsoleSink(outputTemplate));
		}
	}
}