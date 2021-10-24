using System.IO;
using sconsole.Sink.Extensions;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;

namespace sconsole.Sink.Renderers
{
	public class MessageTemplateOutputTokenRenderer : ITemplateTokenRenderer
	{
		readonly PropertyToken token;

		public MessageTemplateOutputTokenRenderer(PropertyToken token)
		{
			this.token = token;
		}

		public void Render(LogEvent logEvent, TextWriter output, IAnsiConsole ansiConsole)
		{
			foreach (MessageTemplateToken token in logEvent.MessageTemplate.Tokens)
			{
				if (token is TextToken t)
				{
					// Render text
					output.Write(t.Text);
				}

				if (token is PropertyToken p)
				{
					RenderProperty(logEvent, p, ansiConsole);
				}
			}
		}

		private void RenderProperty(LogEvent logEvent, PropertyToken token, IAnsiConsole ansiConsole)
		{
			if (logEvent.Properties.ContainsKey(token.PropertyName))
			{
				string propValue = logEvent.Properties[token.PropertyName]
					.ToString()
					.Exec(Markup.Escape)
					.Exec(Style.DefaultStyle.HighlightProp);

				ansiConsole.Markup(propValue);
			}
		}
	}
}