using Serilog.Events;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers;

/// <summary>
/// Abstract the rendering of the single log token
/// </summary>
public interface ITemplateTokenRenderer
{
    IEnumerable<IRenderable> Render(LogEvent logEvent);
}