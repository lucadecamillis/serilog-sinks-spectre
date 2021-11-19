using System.Collections.Generic;
using System.Linq;
using Serilog.Events;
using Serilog.Parsing;
using Serilog.Sinks.Spectre.Extensions;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers
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

			string propValue = value.ToString(token.Format, null)
				.Exec(Markup.Escape)
				.Exec(Style.DefaultStyle.HighlightMuted);

			yield return new Markup(propValue);
		}
	}
}