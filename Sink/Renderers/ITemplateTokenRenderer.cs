using System.IO;
using Serilog.Events;
using Spectre.Console;

namespace sconsole.Sink.Renderers
{
	public interface ITemplateTokenRenderer
	{
		void Render(LogEvent logEvent, TextWriter output, IAnsiConsole ansiConsole);
	}
}