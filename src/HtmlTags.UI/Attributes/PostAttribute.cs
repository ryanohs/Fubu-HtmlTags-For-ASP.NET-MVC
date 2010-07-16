namespace HtmlTags.UI.Attributes
{
	using System.Web.Mvc;

	public class PostAttribute : UnsealedAcceptVerbsAttribute
	{
		public PostAttribute() : base(HttpVerbs.Post)
		{
		}
	}
}