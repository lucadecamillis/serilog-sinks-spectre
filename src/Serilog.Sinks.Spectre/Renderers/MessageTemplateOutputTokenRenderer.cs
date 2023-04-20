using System.Collections.Generic;
using Serilog.Events;
using Serilog.Parsing;
using Serilog.Sinks.Spectre.Extensions;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers
{
	public class MessageTemplateOutputTokenRenderer : ITemplateTokenRenderer
	{
		readonly PropertyToken token;

		public MessageTemplateOutputTokenRenderer(PropertyToken token)
		{
			this.token = token;
		}

		public IEnumerable<IRenderable> Render(LogEvent logEvent)
		{
			foreach (MessageTemplateToken token in logEvent.MessageTemplate.Tokens)
			{
				if (token is TextToken t)
				{
					// Render message as markup
					yield return new Markup(t.Text);
				}

				if (token is PropertyToken p)
				{
					foreach (IRenderable pr in RendersCommon.RenderProperty(logEvent, p))
					{
						yield return pr;
					}
				}
			}
		}
	}
}