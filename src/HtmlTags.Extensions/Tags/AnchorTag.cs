namespace HtmlTags.Extensions
{
	using System;
	using HtmlTags;

	public class AnchorTag : HtmlTag
	{
		public AnchorTag() : base(HtmlTagConstants.A)
		{
		}

		public AnchorTag(Action<HtmlTag> configure)
			: base(HtmlTagConstants.A, configure)
		{
		}

		public AnchorTag Href(string address)
		{
			Attr(HtmlAttributeConstants.Href, address);
			return this;
		}

		public AnchorTag OnClick(string javascript)
		{
			Attr(JavascriptEventConstants.OnClick, javascript);
			return this;
		}
	}
}