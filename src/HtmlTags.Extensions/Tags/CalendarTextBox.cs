namespace HtmlTags.Extensions
{
	using System;
	using HtmlTags;

	public class CalendarTextBox : HtmlTag
	{
		public CalendarTextBox(string id, DateTime? date) : base(HtmlTagConstants.Span)
		{
			Child(new TextboxTag()
			      	.Id(id)
					.Attr(HtmlAttributeConstants.Name, id)
					.Attr(HtmlAttributeConstants.Value, date.HasValue ? date.Value.ToShortDateString() : string.Empty));
			Child(
				new ScriptTag(string.Format("$(function() {{$('#{0}').datepicker({{ changeMonth:true, changeYear:true}});}})", id)));
		}
	}
}