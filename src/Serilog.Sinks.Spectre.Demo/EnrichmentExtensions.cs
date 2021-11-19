using System;
using Serilog.Configuration;

namespace Serilog.Sinks.Spectre.Demo
{
	public static class EnrichmentExtensions
	{
		/// <summary>
		/// Enrich log events with a ThreadId property containing the <see cref="Environment.CurrentManagedThreadId"/>.
		/// </summary>
		/// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
		/// <returns>Configuration object allowing method chaining.</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="enrichmentConfiguration"/> is null.</exception>
		public static LoggerConfiguration WithThreadId(
			this LoggerEnrichmentConfiguration enrichmentConfiguration)
		{
			if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
			return enrichmentConfiguration.With<ThreadIdEnricher>();
		}
	}
}