using System.Collections.Generic;
using sconsole.Sink.Extensions;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace sconsole.Sink.Renderers
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
					yield return new Text(t.Text, Spectre.Console.Style.Plain);
				}

				if (token is PropertyToken p)
				{
					foreach(IRenderable pr in RenderProperty(logEvent, p))
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