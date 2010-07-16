namespace HtmlTags.UI.Builders
{
	using Attributes;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;

	public class SelectListBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return def.Accessor.HasAttribute<OptionsFromAttribute>();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			return SelectBuilder.Build(request);
		}
	}
}