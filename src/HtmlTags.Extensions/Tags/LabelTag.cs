namespace HtmlTags.Extensions
{
	using System;
	using HtmlTags;

	public class LabelTag : HtmlTag
	{
		public LabelTag()
			: base(HtmlTagConstants.Label)
		{
		}

		public LabelTag(Action<HtmlTag> configure)
			: base(HtmlTagConstants.Label, configure)
		{
		}

		public LabelTag For(string id)
		{
			Attr(HtmlAttributeConstants.For, id);
			return this;
		}
	}
}