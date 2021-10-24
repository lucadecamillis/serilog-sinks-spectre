using System.IO;
using Serilog.Events;
using Spectre.Console;

namespace sconsole.Sink.Renderers
{
	public class NewLineTokenRenderer : ITemplateTokenRenderer
	{
		public void Render(LogEvent logEvent, TextWriter output, IAnsiConsole ansiConsole)
		{
            output.WriteLine();
		}
	}
}