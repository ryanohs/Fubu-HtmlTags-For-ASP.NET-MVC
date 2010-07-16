namespace HtmlTags.Extensions
{
	using System;
	using HtmlTags;

	public class ListItemTag : HtmlTag
	{
		public ListItemTag() : base(HtmlTagConstants.Li)
		{
		}

		public ListItemTag(Action<HtmlTag> configure)
			: base(HtmlTagConstants.Li, configure)
		{
		}

		public ListItemTag Selected()
		{
			AddClass(HtmlAttributeConstants.Selected);
			return this;
		}
	}
}