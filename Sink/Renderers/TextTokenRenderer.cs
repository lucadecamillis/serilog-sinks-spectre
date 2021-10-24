using System.IO;
using Serilog.Events;
using Spectre.Console;

namespace sconsole.Sink.Renderers
{
	public class TextTokenRenderer : ITemplateTokenRenderer
	{
        readonly string text;

        public TextTokenRenderer(string text)
        {
            this.text = text;
        }

		public void Render(LogEvent logEvent, TextWriter output, IAnsiConsole ansiConsole)
		{
            output.Write(this.text);
		}
	}
}