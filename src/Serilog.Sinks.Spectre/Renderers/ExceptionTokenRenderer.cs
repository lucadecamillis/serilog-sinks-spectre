using Serilog.Events;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers;

public class ExceptionTokenRenderer : ITemplateTokenRenderer
{
    public IEnumerable<IRenderable> Render(LogEvent logEvent)
    {
        if (logEvent.Exception is not null)
        {
            yield return logEvent.Exception.GetRenderable();
        }
    }
}