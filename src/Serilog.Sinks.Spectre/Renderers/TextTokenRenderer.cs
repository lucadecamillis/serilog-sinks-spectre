using Serilog.Events;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers;

public class TextTokenRenderer(string text) : ITemplateTokenRenderer
{
    public IEnumerable<IRenderable> Render(LogEvent logEvent)
    {
        yield return new Text(text, global::Spectre.Console.Style.Plain);
    }
}