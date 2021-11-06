using System;

namespace sconsole.Sink.Extensions
{
    public static class LinqExtensions
    {
        public static T Exec<T>(this T t, Func<T, T> predicate)
        {
            return predicate(t);
        }
    }
}