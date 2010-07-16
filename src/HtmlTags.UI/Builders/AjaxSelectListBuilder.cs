namespace HtmlTags.UI.Builders
{
	using Attributes;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;

	public class AjaxSelectListBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return def.Accessor.HasAttribute<AjaxOptionsAttribute>();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			return SelectBuilder.AjaxBuild(request);
		}
	}
}