namespace HtmlTags.Extensions
{
	using HtmlTags;

	public static class TableTagExtensions
	{
		public static TableRowTag AddCell(this TableRowTag row, string text)
		{
			row.Cell().Text(text);
			return row;
		}

		public static HtmlTag AlignRight(this HtmlTag tag)
		{
			tag.Style(HtmlStyleConstants.TextAlign, TextAlignConstants.Right);
			return tag;
		}

		public static HtmlTag ColumnSpan(this HtmlTag tag, int columns)
		{
			tag.Attr(HtmlAttributeConstants.Colspan, columns);
			return tag;
		}
	}
}