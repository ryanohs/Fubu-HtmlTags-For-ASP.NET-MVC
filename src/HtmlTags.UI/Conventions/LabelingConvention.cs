namespace HtmlTags.UI.Conventions
{
	using FubuCore.Reflection;

	public static class LabelingConvention
	{
		public static ILabelingConvention Convention { get; set; }

		public static string GetLabelText(Accessor accessor)
		{
			return Convention.GetLabelText(accessor);
		}

		public static string GetLabelText(string text)
		{
			return Convention.GetLabelText(text);
		}
	}
}