namespace HtmlTags.UI.Builders
{
	using System;
	using FubuMVC.UI.Configuration;
	using Helpers;
	using HtmlTags;
	using HtmlTags.Extensions;

	public class DatePickerBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return def.Accessor.PropertyType.In(typeof (DateTime), typeof (DateTime?));
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			var date = request.ValueIsEmpty() ? (DateTime?) null : request.Value<DateTime>();
			return new CalendarTextBox(request.ElementId, date);
		}
	}
}