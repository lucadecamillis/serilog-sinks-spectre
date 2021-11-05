using System.Collections.Generic;
using System.IO;
using Serilog.Events;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace sconsole.Sink.Renderers
{
	/// <summary>
	/// Abstract the rendering of the single log token
	/// </summary>
	public interface ITemplateTokenRenderer
	{
		IEnumerable<IRenderable> Render(LogEvent logEvent);
	}
}