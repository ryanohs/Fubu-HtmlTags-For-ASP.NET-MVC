namespace HtmlTags.UI.Attributes
{
	using System;

	/// <summary>
	/// Renders as a drop down list. Options come from VM dictionary property with matching name.
	/// This will not do autocompletes.
	/// </summary>
	public class OptionsFromAttribute : Attribute
	{
		public string PropertyName { get; set; }

		public OptionsFromAttribute(string propertyName)
		{
			PropertyName = propertyName;
		}
	}
}