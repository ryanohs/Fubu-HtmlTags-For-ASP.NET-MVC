namespace HtmlTags.UI.Helpers
{
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Web.Mvc;
	using HtmlTags;
	using HtmlTags.Extensions;

	public static class TemplateHelpers
	{
		public static HtmlTag EditTemplateFor<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> fieldSelector,
		                                         params Expression<Func<T, object>>[] relatedFieldSelectors) where T : class
		{
			var tag = Tags.Div
				.AddClass("fields")
				.Nest(helper.LabelFor(fieldSelector)
				      	.AddClass("label")
						);

			var fields = relatedFieldSelectors.ToList();
			fields.Insert(0, fieldSelector);
			fields.ForEach(f => tag.Nest(
									Tags.Div
										.AddClass("field")
										.Nest(helper.InputFor(f))));
			return tag;
		}

		public static HtmlTag DisplayTemplateFor<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> fieldSelector,
												 params Expression<Func<T, object>>[] relatedFieldSelectors) where T : class
		{
			var tag = Tags.Div
				.AddClass("fields")
				.Nest(helper.LabelFor(fieldSelector)
						.AddClass("label")
						);

			var fields = relatedFieldSelectors.ToList();
			fields.Insert(0, fieldSelector);
			fields.ForEach(f => tag.Nest(
									Tags.Div
										.AddClass("field")
										.Nest(helper.DisplayFor(f))));
			return tag;
		}
	}
}