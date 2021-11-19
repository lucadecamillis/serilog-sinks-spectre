using System;
using System.Collections.Generic;
using Serilog.Events;
using Serilog.Parsing;
using Serilog.Sinks.Spectre.Extensions;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers
{
	internal static class RendersCommon
	{
		internal static IEnumerable<IRenderable> RenderProperty(
			LogEvent logEvent,
			PropertyToken token,
			IFormatProvider formatProvider = null)
		{
			if (logEvent.Properties.ContainsKey(token.PropertyName))
			{
				string propValue = logEvent.Properties[token.PropertyName]
					.ToString(token.Format, formatProvider)
					.Exec(Markup.Escape)
					.Exec(Style.DefaultStyle.HighlightProp);

				yield return new Markup(propValue);
			}
		}
	}
}