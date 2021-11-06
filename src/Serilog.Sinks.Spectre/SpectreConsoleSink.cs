using System.Collections.Generic;
using System.Linq;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Parsing;
using Serilog.Sinks.Spectre.Extensions;
using Serilog.Sinks.Spectre.Renderers;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre
{
	public class SpectreConsoleSink : ILogEventSink
	{
		readonly ITemplateTokenRenderer[] renderers;

		public SpectreConsoleSink(string outputTemplate)
		{
			this.renderers = InitializeRenders(outputTemplate).ToArray();
		}

		public void Emit(LogEvent logEvent)
		{
			// Create renderable objects for each
			// defined token
			IRenderable[] items = this.renderers
				.SelectMany(r => r.Render(logEvent))
				.ToArray();

			// Join all renderable objects
			RenderableCollection collection = new RenderableCollection(items);

			// Write them to the console
			global::Spectre.Console.AnsiConsole.Write(collection);
		}

		private static IEnumerable<ITemplateTokenRenderer> InitializeRenders(string outputTemplate)
		{
			var template = new MessageTemplateParser().Parse(outputTemplate);

			foreach (MessageTemplateToken token in template.Tokens)
			{
				ITemplateTokenRenderer renderer;
				if (TryInitializeRender(token, out renderer))
				{
					yield return renderer;
				}
			}
		}

		private static bool TryInitializeRender(
			MessageTemplateToken token,
			out ITemplateTokenRenderer renderer)
		{
			if (token is TextToken tt)
			{
				renderer = new TextTokenRenderer(tt.Text);
				return true;
			}

			if (token is PropertyToken pt)
			{
				return TryInitializePropertyRender(pt, out renderer);
			}

			renderer = null;
			return false;
		}

		private static bool TryInitializePropertyRender(
			PropertyToken propertyToken,
			out ITemplateTokenRenderer renderer)
		{
			renderer = propertyToken.PropertyName switch
			{
				OutputProperties.LevelPropertyName =>
					new LevelTokenRenderer(propertyToken),
				OutputProperties.NewLinePropertyName =>
					new NewLineTokenRenderer(),
				OutputProperties.ExceptionPropertyName =>
					new ExceptionTokenRenderer(),
				OutputProperties.MessagePropertyName =>
					new MessageTemplateOutputTokenRenderer(propertyToken),
				OutputProperties.TimestampPropertyName =>
					new TimestampTokenRenderer(propertyToken),
				_ =>
					new PropertyTemplateRenderer(propertyToken)
			};

			return renderer != null;
		}
	}
}