using System.Threading;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Sinks.Spectre.Demo
{
	class ThreadIdEnricher : ILogEventEnricher
	{
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
				"ThreadId",
				Thread.CurrentThread.ManagedThreadId));
		}
	}
}