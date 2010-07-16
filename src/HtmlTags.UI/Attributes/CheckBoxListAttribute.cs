namespace HtmlTags.UI.Attributes
{
	using System;

	public class CheckBoxListAttribute : Attribute
	{
		public string OptionsFrom { get; set; }
        public bool Horizontal { get; set; }
	}
}