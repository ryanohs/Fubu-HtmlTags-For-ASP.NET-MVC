namespace HtmlTags.UI.Conventions
{
	using Extensions;

	public interface ISaveOrCancelConvention
	{
		HtmlTag SaveOrCancel();
	}

	public class SaveButtonOrCancelLinkConvention : ISaveOrCancelConvention
	{
		public HtmlTag SaveOrCancel()
		{
			var save = ViewConventionExtensions.SubmitButton("Save")
				.AddClass("positive");
			var or = Tags.Span.Text(" or ");
			var cancel = Tags.Anchor
				.OnClick("$.ajaxFormsExtensions.AjaxForm.Cancel();")
				.Text("cancel");

			return Tags.Div.AddClass("saveOrCancel").Nest(save, or, cancel);
		}
	}

	public class SaveOrCancelButtonsConvention : ISaveOrCancelConvention
	{
		public HtmlTag SaveOrCancel()
		{
			var save = ViewConventionExtensions.SubmitButton("Save")
				.AddClass("positive");
			var cancel = ViewConventionExtensions.Button("Cancel")
				.Attr("onclick", "$.ajaxFormsExtensions.AjaxForm.Cancel();");

			return Tags.Div.AddClass("saveOrCancel").Nest(save, cancel);
		}
	}

	public static class SaveOrCancelConvention
	{
		public static ISaveOrCancelConvention Convention { get; set; }

		public static HtmlTag SaveOrCancel()
		{
			return Convention.SaveOrCancel();
		}
	}
}