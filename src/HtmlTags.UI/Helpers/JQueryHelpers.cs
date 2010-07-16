namespace HtmlTags.UI.Helpers
{
	using HtmlTags;

	public class JQueryHelpers
	{
		public static string WrapWithJQueryReady(string script)
		{
			var template = @"$(function(){{{0}}});";
			return string.Format(template, script);
		}

		public static HtmlTag WrapWithJQueryReadyAndScriptTag(string script)
		{
			return new HtmlTag("script").Attr("type", "text/javascript").Text(WrapWithJQueryReady(script));
		}
	}
}