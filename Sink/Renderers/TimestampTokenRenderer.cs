using System.IO;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;

namespace sconsole.Sink.Renderers
{
	public class TimestampTokenRenderer : ITemplateTokenRenderer
	{
		readonly PropertyToken token;

		public TimestampTokenRenderer(PropertyToken token)
		{
			this.token = token;
		}

		public void Render(LogEvent logEvent, TextWriter output, IAnsiConsole ansiConsole)
		{
			var sv = new ScalarValue(logEvent.Timestamp);
			sv.Render(output, this.token.Format);
		}
	}
}