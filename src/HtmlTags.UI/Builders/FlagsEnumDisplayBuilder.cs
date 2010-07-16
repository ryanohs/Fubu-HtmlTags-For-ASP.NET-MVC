namespace HtmlTags.UI.Builders
{
	using System;
	using System.Linq;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;
	using Helpers;
	using HtmlTags;
	using HtmlTags.Extensions;
	using HtmlTags.UI;

	public class FlagsEnumDisplayBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return RemoveNullableIfNecessary(def.Accessor.PropertyType).HasAttribute<FlagsAttribute>();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			var tag = Tags.Span;
			if (request.ValueIsEmpty())
			{
				return tag;
			}

			var value = request.Value<int>();
			var type = RemoveNullableIfNecessary(request.Accessor.PropertyType);
			var options = EnumHelper.GetOptions(type);
			var values = options.Where(o => (value & (int) o.GetValue(null)) > 0).Select(o => o.Name).ToArray();
			tag.Text(String.Join(", ", values));
			return tag;
		}
	}
}