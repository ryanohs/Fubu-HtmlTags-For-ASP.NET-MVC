namespace HtmlTags.Extensions
{
	using System;
	using HtmlTags;

	public class InputTag : HtmlTag
	{
		public InputTag() : this(t => { })
		{
		}

		public InputTag(Action<HtmlTag> configure) : base(HtmlTagConstants.Input, configure)
		{
		}

		protected InputTag Type(string type)
		{
			Attr(HtmlAttributeConstants.Type, type);
			return this;
		}

		public InputTag Name(string name)
		{
			Attr(HtmlAttributeConstants.Name, name);
			return this;
		}

		public InputTag Value(string value)
		{
			Attr(HtmlAttributeConstants.Value, value);
			return this;
		}
	}
}