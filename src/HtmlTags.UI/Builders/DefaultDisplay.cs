namespace HtmlTags.UI.Builders
{
	using System;
	using FubuMVC.UI.Configuration;
	using HtmlTags;
	using HtmlTags.Extensions;

	public class DefaultDisplay : BaseElementBuilder
	{
		public static TagBuilder Builder
		{
			get
			{
				var builder = new DefaultDisplay();
				return builder.Build;
			}
		}

		protected override bool matches(AccessorDef def)
		{
			throw new NotSupportedException();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			return Tags.Span.Text(GetValue(request));
		}

		protected virtual string GetValue(ElementRequest request)
		{
			return request.ValueIsEmpty() ? string.Empty : request.StringValue();
		}
	}
}