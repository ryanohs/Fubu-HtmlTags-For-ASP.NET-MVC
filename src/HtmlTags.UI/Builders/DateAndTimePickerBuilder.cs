namespace HtmlTags.UI.Builders
{
	using System;
	using Attributes;
	using Extensions;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;
	using Helpers;

	public class DateAndTimePickerBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return def.Accessor.PropertyType.In(typeof (DateTime), typeof (DateTime?))
			       && def.Accessor.HasAttribute<DateAndTimeAttribute>();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			var date = request.ValueIsEmpty() ? (DateTime?) null : request.Value<DateTime>();
			return new DateAndTimeTextBoxTag(request.ElementId, date);
		}
	}
}