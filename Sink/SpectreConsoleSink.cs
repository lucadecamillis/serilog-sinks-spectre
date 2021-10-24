using System.Collections.Generic;
using System.IO;
using System.Linq;
using sconsole.Sink.Renderers;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Parsing;
using Spectre.Console;

namespace sconsole.Sink
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
			var output = new StringWriter();

			AnsiConsoleSettings consoleSettings = new AnsiConsoleSettings
			{
				ColorSystem = ColorSystemSupport.Detect,
        		Interactive = InteractionSupport.No,
        		Out = new AnsiConsoleOutput(output)
			};

			IAnsiConsole ansiConsole = AnsiConsole.Create(consoleSettings);

			foreach (ITemplateTokenRenderer renderer in this.renderers)
			{
				renderer.Render(logEvent, output, ansiConsole);
			}

			output.Flush();
			string result = output.ToString();
			Spectre.Console.AnsiConsole.Write(result);
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