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
					// Render text
					yield return new Text(t.Text, global::Spectre.Console.Style.Plain);
				}

				if (token is PropertyToken p)
				{
					foreach (IRenderable pr in RenderProperty(logEvent, p))
					{
						yield return pr;
					}
				}
			}
		}

		private IEnumerable<IRenderable> RenderProperty(LogEvent logEvent, PropertyToken token)
		{
			if (logEvent.Properties.ContainsKey(token.PropertyName))
			{
				string propValue = logEvent.Properties[token.PropertyName]
					.ToString()
					.Exec(Markup.Escape)
					.Exec(Style.DefaultStyle.HighlightProp);

				yield return new Markup(propValue);
			}
		}
	}
}