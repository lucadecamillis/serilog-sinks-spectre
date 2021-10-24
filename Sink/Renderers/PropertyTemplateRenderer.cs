using System.IO;
using System.Linq;
using sconsole.Sink.Extensions;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;

namespace sconsole.Sink.Renderers
{
	public class PropertyTemplateRenderer : ITemplateTokenRenderer
	{
        readonly PropertyToken token;

		public PropertyTemplateRenderer(PropertyToken token)
		{
			this.token = token;
		}

		public void Render(LogEvent logEvent, TextWriter output, IAnsiConsole ansiConsole)
		{
            var value = new StructureValue(logEvent.Properties
                .Select(p => new LogEventProperty(p.Key, p.Value)));

            string propValue = value.ToString()
                .Exec(Markup.Escape)
                .Exec(Style.DefaultStyle.HighlightMuted);

            ansiConsole.Markup(propValue);
		}
	}
}