namespace HtmlTags.Extensions
{
	using HtmlTags;

	public static class HtmlTagExtensions
	{
		public static HtmlTag Nest(this HtmlTag tag, params HtmlTag[] children)
		{
			return tag.AddChildren(children);
		}

		public static HtmlTag Value(this HtmlTag tag, object value)
		{
			tag.Attr(HtmlAttributeConstants.Value, value);
			return tag;
		}

		public static CheckboxTag Name(this CheckboxTag tag, string name)
		{
			tag.Attr(HtmlAttributeConstants.Name, name);
			return tag;
		}

		public static HiddenTag Name(this HiddenTag tag, string name)
		{
			tag.Attr(HtmlAttributeConstants.Name, name);
			return tag;
		}

		public static InputTag Name(this InputTag tag, string name)
		{
			tag.Attr(HtmlAttributeConstants.Name, name);
			return tag;
		}
	}
}