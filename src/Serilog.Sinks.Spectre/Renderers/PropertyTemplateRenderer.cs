using Serilog.Events;
using Serilog.Parsing;
using Serilog.Sinks.Spectre.Extensions;
using Serilog.Sinks.Spectre.Style;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers;

public class PropertyTemplateRenderer(PropertyToken token) : ITemplateTokenRenderer
{
    public IEnumerable<IRenderable> Render(LogEvent logEvent)
    {
        var value = new StructureValue(logEvent.Properties.Select(p => new LogEventProperty(p.Key, p.Value)));
        var propValue = value.ToString(token.Format, null).Exec(Markup.Escape).Exec(DefaultStyle.HighlightMuted);
        yield return new Markup(propValue);
    }
}