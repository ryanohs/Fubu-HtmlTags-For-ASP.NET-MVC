namespace HtmlTags.Adapter
{
	using System;
	using System.Linq.Expressions;
	using System.Web.Mvc;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;
	using FubuMVC.UI.Tags;
	using Microsoft.Practices.ServiceLocation;

	public static class DynamicInputExtensions
	{
		private static ITagGenerator<T> GetGenerator<T>(HtmlHelper<T> helper) where T : class
		{
			var generator = ServiceLocator.Current.GetInstance<ITagGenerator<T>>() as TagGenerator<T>;
			generator.Model = helper.ViewData.Model;
			return generator;
		}

		public static string InputFor<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> expression) where T : class
		{
			var generator = GetGenerator<T>(helper);
			return generator.InputFor(expression).ToString();
		}

		public static string LabelFor<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> expression) where T : class
		{
			var generator = GetGenerator<T>(helper);
			return generator.LabelFor(expression).ToString();
		}

		public static string DisplayFor<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> expression) where T : class
		{
			var generator = GetGenerator<T>(helper);
			return generator.DisplayFor(expression).ToString();
		}

		public static string ElementNameFor<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> expression)
			where T : class
		{
			var convention = ServiceLocator.Current.GetInstance<IElementNamingConvention>();
			return convention.GetName(typeof (T), expression.ToAccessor());
		}
	}
}