using System.IO;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;

namespace sconsole.Sink.Renderers
{
	public class LevelTokenRenderer : ITemplateTokenRenderer
	{
		readonly PropertyToken token;

		public LevelTokenRenderer(PropertyToken token)
		{
			this.token = token;
		}

		public void Render(LogEvent logEvent, TextWriter output, IAnsiConsole ansiConsole)
		{
			string levelMoniker = Style.LevelOutputFormat.GetLevelMoniker(
				logEvent.Level,
				format: this.token.Format);

			string formatMoniker = logEvent.Level switch
			{
				LogEventLevel.Verbose => Style.DefaultStyle.HighlightVerbose(levelMoniker),
				LogEventLevel.Debug => Style.DefaultStyle.HighlightDebug(levelMoniker),
				LogEventLevel.Information => Style.DefaultStyle.HighlightInfo(levelMoniker),
				LogEventLevel.Warning => Style.DefaultStyle.HighlightWarning(levelMoniker),
				LogEventLevel.Error => Style.DefaultStyle.HighlightError(levelMoniker),
				LogEventLevel.Fatal => Style.DefaultStyle.HighlightFatal(levelMoniker),
				_ => levelMoniker
			};

			ansiConsole.Markup(formatMoniker);
		}
	}
}