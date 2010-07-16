namespace HtmlTags.UI.Builders
{
	using FubuMVC.UI.Configuration;
	using Helpers;
	using HtmlTags;
	using HtmlTags.Extensions;

	public class CheckBoxBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return def.Accessor.PropertyType.In(typeof (bool));
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			return Tags.Checkbox(request.Value<bool>()).Value("true").Id(request.ElementId);
		}
	}
}