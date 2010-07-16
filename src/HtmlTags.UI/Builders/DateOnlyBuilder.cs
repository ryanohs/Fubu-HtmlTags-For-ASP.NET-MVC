namespace HtmlTags.UI.Builders
{
	using System;
	using Attributes;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;
	using Helpers;
	using HtmlTags;
	using HtmlTags.Extensions;

	public class DateOnlyBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return def.Accessor.PropertyType.In(typeof (DateTime), typeof (DateTime?))
			       && def.Accessor.HasAttribute<DateOnlyAttribute>();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			var tag = Tags.Span;
			if (request.ValueIsEmpty())
			{
				return tag;
			}

			var value = request.Value<DateTime>();
			tag.Text(value.ToShortDateString());
			return tag;
		}
	}
}