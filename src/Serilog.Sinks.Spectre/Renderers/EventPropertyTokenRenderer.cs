using System.Collections.Generic;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers
{
	public class EventPropertyTokenRenderer : ITemplateTokenRenderer
	{
		readonly PropertyToken token;

		public EventPropertyTokenRenderer(PropertyToken token)
		{
			this.token = token;
		}

		public IEnumerable<IRenderable> Render(LogEvent logEvent)
		{
			return RendersCommon.RenderProperty(logEvent, this.token);
		}
	}
}