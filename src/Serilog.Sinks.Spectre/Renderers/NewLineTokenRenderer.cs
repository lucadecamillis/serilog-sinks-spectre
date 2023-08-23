using Serilog.Events;
using Spectre.Console;
using Spectre.Console.Rendering;
using System.Collections.Generic;

namespace Serilog.Sinks.Spectre.Renderers;

public class NewLineTokenRenderer : ITemplateTokenRenderer
{
    public IEnumerable<IRenderable> Render(LogEvent logEvent)
    {
        yield return Text.NewLine;
    }
}