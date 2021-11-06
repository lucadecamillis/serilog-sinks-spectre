using System.Collections.Generic;
using System.IO;
using Serilog.Events;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers
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

		public IEnumerable<IRenderable> Render(LogEvent logEvent)
		{
			yield return new Text(this.text, global::Spectre.Console.Style.Plain);
		}
	}
}