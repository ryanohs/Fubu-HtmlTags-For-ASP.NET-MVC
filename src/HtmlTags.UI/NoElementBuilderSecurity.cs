namespace HtmlTags.UI
{
	using Builders;
	using FubuMVC.UI.Configuration;

	public class NoElementBuilderSecurity : IElementBuilderSecurity
	{
		public HtmlTag ApplySecurity(ElementRequest request)
		{
			return null;
		}
	}
}