namespace HtmlTags.UI.Builders
{
	using Attributes;
	using Extensions;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;

	public class YesOrNoBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return def.Accessor.HasAttribute<YesOrNoAttribute>();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			return Tags.Span.Text((bool) request.RawValue ? "Yes" : "No");
		}
	}
}