namespace HtmlTags.UI.Conventions
{
	using System.Text;
	using FubuCore.Reflection;

	public class SpaceBeforeCapitalsLabelingConvention : ILabelingConvention
	{
		public string GetLabelText(Accessor accessor)
		{
			var text = accessor.Name;
			return GetLabelText(text);
		}

		public string GetLabelText(string text)
		{
			if (string.IsNullOrEmpty(text))
				return "";
			var newText = new StringBuilder(text.Length*2);
			newText.Append(text[0]);
			bool lastWasUpper = false;
			for (var i = 1; i < text.Length; i++)
			{
				if (char.IsUpper(text[i]) && !lastWasUpper)
					newText.Append(' ');
				newText.Append(text[i]);
				lastWasUpper = char.IsUpper(text[i]);
			}
			return newText.ToString();
		}
	}
}