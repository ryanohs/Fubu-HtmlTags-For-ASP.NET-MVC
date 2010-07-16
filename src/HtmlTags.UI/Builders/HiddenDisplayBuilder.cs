namespace HtmlTags.UI.Builders
{
	using Attributes;
	using Extensions;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;

	public class HiddenDisplayBuilder : ElementBuilder
	{
		protected override bool matches(AccessorDef accessorDefinition)
		{
			return accessorDefinition.Accessor.HasAttribute<HiddenAttribute>();
		}

		public override HtmlTag Build(ElementRequest request)
		{
			return Tags.NoTag;
		}
	}
}