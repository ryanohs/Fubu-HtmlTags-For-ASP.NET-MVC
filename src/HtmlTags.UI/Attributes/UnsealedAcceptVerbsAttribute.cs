namespace HtmlTags.UI.Attributes
{
	using System.Reflection;
	using System.Web.Mvc;

	public class UnsealedAcceptVerbsAttribute : ActionMethodSelectorAttribute
	{
		private AcceptVerbsAttribute _Verbs;

		public UnsealedAcceptVerbsAttribute(HttpVerbs verbs)
		{
			_Verbs = new AcceptVerbsAttribute(verbs);
		}

		public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
		{
			return _Verbs.IsValidForRequest(controllerContext, methodInfo);
		}
	}
}