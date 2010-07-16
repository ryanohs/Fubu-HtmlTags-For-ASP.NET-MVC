namespace HtmlTags.UI.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using FubuCore.Reflection;
	using HtmlTags;
	using UI;

	public static class ViewListHelpers
	{
		public static HtmlTag ListIndex<T, V>(this T model, Expression<Func<T, IEnumerable<V>>> list, int count)
		{
			var tag = new HiddenTag();
			var property = ReflectionHelper.GetProperty(list);
			tag.Id(property.Name + ".Index");
			tag.Attr("value", count);
			return tag;
		}

		public static HtmlTag ListHiddenValue<T, V>(this T model, Expression<Func<T, IEnumerable<V>>> listSelector, V listItem,
		                                            Expression<Func<V, object>> propertySelector, int count)
			where T : class
		{
			var tag = new HiddenTag();
			var listProperty = ReflectionHelper.GetProperty(listSelector);
			var propertyProperty = ReflectionUtilities.GetMemberExpression(propertySelector);
			var name = string.Format("{0}[{1}].{2}", listProperty.Name, count, propertyProperty.Member.Name);
			tag.Attr("name", name);
			tag.Id(name);
			var value = propertySelector.Compile().DynamicInvoke(listItem);
			tag.Attr("value", value);
			return tag;
		}

		public static HtmlTag ListInputFor<T, V>(this T model, Expression<Func<T, IEnumerable<V>>> listSelector, V listItem,
		                                         Expression<Func<V, object>> propertySelector, int count)
			where T : class
			where V : class
		{
			var tag = ViewConventionExtensions.InputFor(listItem, propertySelector);
			var listProperty = ReflectionHelper.GetProperty(listSelector);
			var propertyProperty = ReflectionUtilities.GetMemberExpression(propertySelector);
			var name = string.Format("{0}[{1}].{2}", listProperty.Name, count, propertyProperty.Member.Name);
			tag.Attr("name", name);
			var id = string.Format("{0}_{1}__{2}", listProperty.Name, count, propertyProperty.Member.Name);
			tag.Id(id);
			return tag;
		}
	}
}