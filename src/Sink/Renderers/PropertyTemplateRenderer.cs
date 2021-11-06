using System.Collections.Generic;
using System.Linq;
using sconsole.Sink.Extensions;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace sconsole.Sink.Renderers
{
	public class PropertyTemplateRenderer : ITemplateTokenRenderer
	{
        readonly PropertyToken token;

		public PropertyTemplateRenderer(PropertyToken token)
		{
			this.token = token;
		}

		public IEnumerable<IRenderable> Render(LogEvent logEvent)
		{
			var value = new StructureValue(logEvent.Properties
                .Select(p => new LogEventProperty(p.Key, p.Value)));

            string propValue = value.ToString()
                .Exec(Markup.Escape)
                .Exec(Style.DefaultStyle.HighlightMuted);

			yield return new Markup(propValue);
		}
	}
}