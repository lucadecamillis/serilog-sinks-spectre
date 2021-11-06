using System.Collections.Generic;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers
{
	public class TimestampTokenRenderer : ITemplateTokenRenderer
	{
		readonly PropertyToken token;

		public TimestampTokenRenderer(PropertyToken token)
		{
			this.token = token;
		}

		public IEnumerable<IRenderable> Render(LogEvent logEvent)
		{
			yield return new Text(
				logEvent.Timestamp.ToString(this.token.Format),
				global::Spectre.Console.Style.Plain);
		}
	}
}