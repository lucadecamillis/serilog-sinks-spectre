using System.Collections.Generic;
using Serilog.Events;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace sconsole.Sink.Renderers
{
	public class NewLineTokenRenderer : ITemplateTokenRenderer
	{
		public IEnumerable<IRenderable> Render(LogEvent logEvent)
		{
			yield return Text.NewLine;
		}
	}
}