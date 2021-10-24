using System;
using Serilog;
using Serilog.Configuration;

namespace sconsole.Sink
{
    public static class SpectreConsoleSinkExtensions
    {
        const string DefaultConsoleOutputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";

        public static LoggerConfiguration StealthConsoleSink(
            this LoggerSinkConfiguration loggerConfiguration,
            string outputTemplate = DefaultConsoleOutputTemplate)
        {
            return loggerConfiguration.Sink(new SpectreConsoleSink(outputTemplate));
        }
    }
}