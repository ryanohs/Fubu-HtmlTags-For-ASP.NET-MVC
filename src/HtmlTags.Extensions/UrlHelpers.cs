namespace HtmlTags.Extensions
{
	using System;
	using System.Linq.Expressions;
	using System.Reflection;
	using System.Web.Mvc;
	using FubuCore.Reflection;

	public static class UrlHelpers
	{
		public static string GetUrl<TController>(this UrlHelper helper, Expression<Action<TController>> action)
		{
			var actionMethod = helper.GetActionMethod(action);
			var actionName = actionMethod.Name;
			var controllerName = helper.GetControllerName<TController>();
			return helper.Action(actionName, controllerName);
		}

		public static string GetControllerName<TController>(this UrlHelper helper)
		{
			return typeof (TController).Name.Replace("Controller", string.Empty);
		}

		public static MethodInfo GetActionMethod<TController>(this UrlHelper helper, Expression<Action<TController>> action)
		{
			return new FindMethodVisitor(action).Method;
		}
	}
}