namespace HtmlTags.Extensions
{
	using HtmlTags;

	public class ScriptTag : HtmlTag
	{
		public ScriptTag(string javascript) : base(HtmlTagConstants.Script)
		{
			Attr(HtmlAttributeConstants.Type, MimeTypeConstants.Javascript);
			Text(javascript);
		}
	}
}