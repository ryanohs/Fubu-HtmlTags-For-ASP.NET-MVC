namespace HtmlTags.Extensions
{
	using HtmlTags;

	public class TextAreaTag : HtmlTag
	{
		public TextAreaTag() : base(HtmlTagConstants.TextArea)
		{
			Cols(80);
			Rows(6);
		}

		public TextAreaTag Value(string value)
		{
			Attr(HtmlAttributeConstants.Value, value);
			return this;
		}

		public TextAreaTag Cols(int cols)
		{
			Attr(HtmlAttributeConstants.Cols, cols);
			return this;
		}

		public TextAreaTag Rows(int rows)
		{
			Attr(HtmlAttributeConstants.Rows, rows);
			return this;
		}
	}
}