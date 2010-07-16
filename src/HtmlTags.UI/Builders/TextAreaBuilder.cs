namespace HtmlTags.UI.Builders
{
	using Attributes;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;
	using HtmlTags.Extensions;

	public class TextAreaBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return def.Accessor.HasAttribute<MultilineAttribute>();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			return Build(request);
		}

		public static HtmlTag Build(ElementRequest req)
		{
			return new TextAreaTag()
				.Rows(6)
				.Id(req.ElementId)
				.Attr("name", req.ElementId)
				.Text(req.StringValue());
		}
	}
}