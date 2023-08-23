using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;
using Spectre.Console.Rendering;
using System.Collections.Generic;

namespace Serilog.Sinks.Spectre.Renderers;

public class MessageTemplateOutputTokenRenderer : ITemplateTokenRenderer
{
    public IEnumerable<IRenderable> Render(LogEvent logEvent)
    {
        foreach (var token in logEvent.MessageTemplate.Tokens)
        {
            if (token is TextToken t)
            {
                // Render message as markup
                yield return new Markup(t.Text);
            }
            if (token is not PropertyToken p) continue;
            foreach (var pr in RendersCommon.RenderProperty(logEvent, p))
            {
                yield return pr;
            }
        }
    }
}