using System.Collections.Generic;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers
{
	public class LevelTokenRenderer : ITemplateTokenRenderer
	{
		readonly PropertyToken token;

		public LevelTokenRenderer(PropertyToken token)
		{
			this.token = token;
		}

		public IEnumerable<IRenderable> Render(LogEvent logEvent)
		{
			string formatMoniker = GetFormatMoniker(logEvent);

			yield return new Markup(formatMoniker);
		}

		private string GetFormatMoniker(LogEvent logEvent)
		{
			string levelMoniker = Style.LevelOutputFormat.GetLevelMoniker(
				logEvent.Level,
				format: this.token.Format);

			switch (logEvent.Level)
			{
				case LogEventLevel.Verbose:
					return Style.DefaultStyle.HighlightVerbose(levelMoniker);
				case LogEventLevel.Debug:
					return Style.DefaultStyle.HighlightDebug(levelMoniker);
				case LogEventLevel.Information:
					return Style.DefaultStyle.HighlightInfo(levelMoniker);
				case LogEventLevel.Warning:
					return Style.DefaultStyle.HighlightWarning(levelMoniker);
				case LogEventLevel.Error:
					return Style.DefaultStyle.HighlightError(levelMoniker);
				case LogEventLevel.Fatal:
					return Style.DefaultStyle.HighlightFatal(levelMoniker);
				default:
					return levelMoniker;
			}
		}
	}
}