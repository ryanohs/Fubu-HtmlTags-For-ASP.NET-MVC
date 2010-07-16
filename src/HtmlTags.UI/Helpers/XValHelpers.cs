namespace HtmlTags.UI.Helpers
{
	using System;
	using System.Linq.Expressions;
	using System.Web.Mvc;
	using FubuCore.Reflection;
	using xVal.Html;

	public static class XValHelpers
	{
		public static ValidationInfo ClientSideValidation<T>(this HtmlHelper<T> helper) where T : class
		{
			return helper.ClientSideValidation(typeof (T));
		}

		/// <summary>
		/// This is to generate validation of a list of data, it won't work for double nested lists but we can modify it for that if we ever need it.
		/// Index is typically the count or position in the list.
		/// This will generate xVal client validation with an element prefix of listName_index_
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="helper"></param>
		/// <param name="listSelector">This is assumed to be IEnumerable generically typed.</param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static ValidationInfo ClientSideValidationOfList<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> listSelector, object index) where T : class
		{
			var listProperty = ReflectionHelper.GetProperty(listSelector);
			var elementIdPrefix = string.Format("{0}_{1}_", listProperty.Name, index);
			return helper.ClientSideValidation(elementIdPrefix, listProperty.PropertyType.GetGenericArguments()[0]);
		}
	}
}