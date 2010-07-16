namespace HtmlTags.UI.Conventions
{
	using FubuCore.Reflection;

	public interface ILabelingConvention
	{
		string GetLabelText(Accessor accessor);
		string GetLabelText(string text);
	}
}