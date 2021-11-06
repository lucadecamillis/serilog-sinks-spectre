namespace Serilog.Sinks.Spectre.Style
{
	static class DefaultStyle
	{
		internal static string HighlightProp(string text)
		{
			return $"[lime]{text}[/]";
		}

		internal static string HighlightMuted(string text)
		{
			return $"[grey]{text}[/]";
		}

		internal static string HighlightVerbose(string text)
		{
			return HighlightMuted(text);
		}

		internal static string HighlightDebug(string text)
		{
			return $"[silver]{text}[/]";
		}

		internal static string HighlightInfo(string text)
		{
			return $"[deepskyblue1]{text}[/]";
		}

		internal static string HighlightWarning(string text)
		{
			return $"[yellow]{text}[/]";
		}

		internal static string HighlightError(string text)
		{
			return $"[red]{text}[/]";
		}

		internal static string HighlightFatal(string text)
		{
			return $"[maroon]{text}[/]";
		}
	}
}