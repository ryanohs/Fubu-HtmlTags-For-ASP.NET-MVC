namespace HtmlTags.UI
{
	using System;
	using System.Linq.Expressions;

	public static class ReflectionUtilities
	{
		public static MemberExpression GetMemberExpression<T>(Expression<Func<T, object>> expression)
		{
			var current = expression.Body;
			return GetMemberExpression(current);
		}

		public static MemberExpression GetMemberExpression(Expression<Func<object>> expression)
		{
			var current = expression.Body;
			return GetMemberExpression(current);
		}

		private static MemberExpression GetMemberExpression(Expression current)
		{
			//Dig through unary expressions and remove them.
			while (current is UnaryExpression)
			{
				current = (current as UnaryExpression).Operand;
			}

			if (!(current is MemberExpression))
				throw new ArgumentException("expression must be a member expression");
			return current as MemberExpression;
		}
	}
}