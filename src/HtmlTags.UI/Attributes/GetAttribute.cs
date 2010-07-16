namespace HtmlTags.UI.Attributes
{
	using System.Web.Mvc;

	public class GetAttribute : UnsealedAcceptVerbsAttribute
	{
		public GetAttribute()
			: base(HttpVerbs.Get)
		{
		}
	}
}