using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console.Rendering;
using System.Collections.Generic;

namespace Serilog.Sinks.Spectre.Renderers;

public class EventPropertyTokenRenderer(PropertyToken token) : ITemplateTokenRenderer
{
    public IEnumerable<IRenderable> Render(LogEvent logEvent) => RendersCommon.RenderProperty(logEvent, token);
}