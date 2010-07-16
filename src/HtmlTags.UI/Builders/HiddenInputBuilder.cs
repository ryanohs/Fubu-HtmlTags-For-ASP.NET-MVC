namespace HtmlTags.UI.Builders
{
	using Attributes;
	using Extensions;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;
	using FubuMVC.UI.Tags;

	public class HiddenInputBuilder : ElementBuilder
	{
		protected override bool matches(AccessorDef accessorDefinition)
		{
			return accessorDefinition.Accessor.HasAttribute<HiddenAttribute>();
		}

		public override HtmlTag Build(ElementRequest request)
		{
			return
				TagActionExpression.BuildTextbox(request)
					.Id(request.ElementId)
					.Attr(HtmlAttributeConstants.Type, InputTypeConstants.Hidden);
		}
	}
}