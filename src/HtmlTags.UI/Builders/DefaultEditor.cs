namespace HtmlTags.UI.Builders
{
	using System;
	using FubuMVC.UI.Configuration;
	using FubuMVC.UI.Tags;
	using HtmlTags;

	public class DefaultEditor : BaseElementBuilder
	{
		public static TagBuilder Default
		{
			get
			{
				var builder = new DefaultEditor();
				return builder.Build;
			}
		}

		protected override bool matches(AccessorDef def)
		{
			throw new NotSupportedException();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			return TagActionExpression.BuildTextbox(request).Attr("Id", request.ElementId);
		}
	}
}