namespace WebTest.Application
{
	using FubuMVC.UI;
	using FubuMVC.UI.Configuration;
	using HtmlTags;
	using HtmlTags.Extensions;
	using HtmlTags.UI;
	using HtmlTags.UI.Builders;

	public class CustomHtmlConventions : HtmlConventionRegistry
	{
		public CustomHtmlConventions()
		{
			RegisterBuilders();
			RegisterDefaults();
			RegisterModifiers();
		}

		private void RegisterBuilders()
		{
			Editors.IfPropertyTypeIsEnum().BuildBy(new EnumDropDownBuilder().Build);
			Editors.IfPropertyTypeIsNullableEnum().BuildBy(new EnumDropDownBuilder().Build);
			Editors.Builder<HiddenInputBuilder>();
			Editors.Builder<AjaxSelectListBuilder>();
			Editors.Builder<SelectListBuilder>();
			Editors.Builder<CheckBoxListBuilder>();
			Editors.Builder<CheckBoxBuilder>();
			Editors.Builder<DateAndTimePickerBuilder>();
			Editors.Builder<DatePickerBuilder>();
			Editors.Builder<PasswordBuilder>();
			Editors.Builder<TextAreaBuilder>();

			Displays.Builder<HiddenDisplayBuilder>();
			Displays.Builder<DateOnlyBuilder>();
			Displays.Builder<YesOrNoBuilder>();
			Displays.Builder<FlagsEnumDisplayBuilder>();

			Labels.Builder<HiddenLabeluilder>();
		}

		private void RegisterDefaults()
		{
			Displays.Always.BuildBy(DefaultDisplay.Builder);
			Labels.Always.BuildBy(DefaultLabeler.Default);
			Editors.Always.BuildBy(DefaultEditor.Default);
		}

		private void RegisterModifiers()
		{
			Editors.Always.Modify(AddElementName);
		}

		public static void AddElementName(ElementRequest request, HtmlTag tag)
		{
			if (tag.IsInputElement())
			{
				tag.Attr(HtmlAttributeConstants.Name, request.ElementId);
			}
		}
	}
}