namespace HtmlTags.Extensions
{
	using System;
	using HtmlTags;

	public class DateAndTimeTextBoxTag : HtmlTag
	{
		public DateAndTimeTextBoxTag(string id, DateTime? date) : base(HtmlTagConstants.Span)
		{
			Child(new TextboxTag()
			      	.Id(id)
			      	.Attr(HtmlAttributeConstants.Name, id)
					.Attr(HtmlAttributeConstants.Value, date.HasValue ? date.Value.ToString("MM/dd/yyyy HH:mm:ss") : string.Empty));
			Child(new ScriptTag(string.Format("$(function() {{$('#{0}').datetime({{ americanMode: false, changeMonth:true, changeYear:true}});}})", id)));
		}
	}
}