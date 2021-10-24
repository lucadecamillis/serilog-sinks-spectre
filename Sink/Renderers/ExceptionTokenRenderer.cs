using System.IO;
using Serilog.Events;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace sconsole.Sink.Renderers
{
	public class ExceptionTokenRenderer : ITemplateTokenRenderer
	{
		public void Render(LogEvent logEvent, TextWriter output, IAnsiConsole ansiConsole)
		{
			if (logEvent.Exception != null)
			{
				ansiConsole.WriteException(logEvent.Exception);
			}
		}
	}
}