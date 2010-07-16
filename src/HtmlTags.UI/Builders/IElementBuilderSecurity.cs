namespace HtmlTags.UI.Builders
{
	using FubuMVC.UI.Configuration;

	public interface IElementBuilderSecurity
	{
		HtmlTag ApplySecurity(ElementRequest request);
	}
}