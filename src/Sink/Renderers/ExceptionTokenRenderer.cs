using System.Collections.Generic;
using System.IO;
using Serilog.Events;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace sconsole.Sink.Renderers
{
	public class ExceptionTokenRenderer : ITemplateTokenRenderer
	{
		public IEnumerable<IRenderable> Render(LogEvent logEvent)
		{
			if (logEvent.Exception != null)
			{
				yield return logEvent.Exception.GetRenderable(ExceptionFormats.Default);
			}
		}
	}
}