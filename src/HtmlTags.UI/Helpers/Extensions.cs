namespace HtmlTags.UI.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class Extensions
	{
		public static bool In<T>(this T value, params T[] values)
		{
			return values.ToList().Any(v => value.Equals(v));
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach(var item in source)
			{
				action(item);
			}
		}

		public static bool Has(this string source, string search, StringComparison comparison)
		{
			return source.IndexOf(search, comparison) >= 0;
		}
	}
}