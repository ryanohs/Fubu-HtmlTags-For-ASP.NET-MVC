namespace HtmlTags.UI
{
	using System;
	using System.Collections.Generic;
	using Helpers;

	public class OptionItem
	{
		public OptionItem(object value, string text)
		{
			Value = value;
			Text = text;
		}

		public object Value { get; set; }
		public string Text { get; set; }
	}

	public class Options : List<OptionItem>
	{
		public void Add(object value, string text)
		{
			Add(new OptionItem(value, text));
		}
	}

	public static class OptionExtensions
	{
		public static Options ToOptions<TSource, TKey, TElement>(this IEnumerable<TSource> source,
		                                                         Func<TSource, TKey> keySelector,
		                                                         Func<TSource, TElement> elementSelector)
		{
			var options = new Options();
			source.ForEach(i => options.Add(keySelector(i), elementSelector(i).ToString()));
			return options;
		}
	}
}