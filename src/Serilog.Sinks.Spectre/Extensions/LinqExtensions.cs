using System;

namespace Serilog.Sinks.Spectre.Extensions
{
	public static class LinqExtensions
	{
		public static T Exec<T>(this T t, Func<T, T> predicate)
		{
			return predicate(t);
		}
	}
}