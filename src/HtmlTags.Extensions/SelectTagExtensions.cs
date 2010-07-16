namespace HtmlTags.Extensions
{
	using System.Collections;
	using System.Linq;

	public static class SelectTagExtensions
	{
		public static SelectTag AllowMultiple(this SelectTag tag)
		{
			tag.Attr(HtmlAttributeConstants.Multiple, HtmlAttributeConstants.Multiple);
			return tag;
		}

		public static SelectTag Rows(this SelectTag tag, int rows)
		{
			tag.Attr(HtmlAttributeConstants.Size, rows);
			return tag;
		}

		public static SelectTag SelectValues(this SelectTag tag, IEnumerable selected)
		{
			foreach (var value in selected)
			{
				// TODO Is there a better way to do this? Generics? It also impacts the CheckBoxBuilder.
				var stringValue = value.ToString(); // default to just writing string value of object
				ExceptionHelpers.IgnoreExceptions(() => stringValue = ((int) value).ToString()); // trys to cast value as an int.
				var optionTag = tag.Children.FirstOrDefault(x => x.Attr(HtmlAttributeConstants.Value).Equals(stringValue));
				if (optionTag != null)
				{
					optionTag.Attr(HtmlAttributeConstants.Selected, HtmlAttributeConstants.Selected);
				}
			}
			return tag;
		}
	}
}