namespace HtmlTags.UI
{
	using System;
	using System.Linq.Expressions;
	using HtmlTags;
	using Extensions;

	public static class TableTagConventionExtensions
	{
		public static TableRowTag DisplayCell<T>(this TableRowTag row, T model, Expression<Func<T, object>> expression)
			where T : class
		{
			var cellContents = model.DisplayFor(expression);
			row.Cell().Nest(cellContents);
			return row;
		}

		public static TableRowTag DisplayCell<T>(this TableRowTag row, T model, Expression<Func<T, object>> expression,
		                                         string prepend)
			where T : class
		{
			var cellContents = model.DisplayFor(expression);
			row.Cell().Nest(cellContents).Prepend(prepend);
			return row;
		}

		public static TableRowTag InputCell<T>(this TableRowTag row, T model, Expression<Func<T, object>> expression)
			where T : class
		{
			var cellContents = model.InputFor(expression);
			row.Cell().Nest(cellContents);
			return row;
		}

		public static TableRowTag InputCell<T>(this TableRowTag row, T model, Expression<Func<T, object>> expression,
		                                       string prepend)
			where T : class
		{
			var cellContents = model.InputFor(expression);
			row.Cell().Nest(cellContents).Prepend(prepend);
			return row;
		}
	}
}