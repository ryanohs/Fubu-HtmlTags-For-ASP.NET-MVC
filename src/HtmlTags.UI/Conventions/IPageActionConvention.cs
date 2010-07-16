namespace HtmlTags.UI.Conventions
{
	using System;
	using System.Linq.Expressions;
	using System.Reflection;
	using System.Web.Mvc;
	using HtmlTags;

	public interface IPageActionConvention
	{
		HtmlTag ButtonsFor<TController>(HtmlHelper helper,
		                                params Expression<Action<TController>>[] expressions)
			where TController : IController;
		HtmlTag MenuItemFor<TController>(UrlHelper helper, Expression<Action<TController>> action, MethodInfo currentMethod);
		HtmlTag MenuItemFor(string url, string text, bool selected);
	}
}