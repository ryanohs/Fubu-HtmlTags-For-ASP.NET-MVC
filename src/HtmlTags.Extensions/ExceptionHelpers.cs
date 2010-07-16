namespace HtmlTags.Extensions
{
	using System;

	public static class ExceptionHelpers
	{
		public static void IgnoreExceptions(Action statement)
		{
			try
			{
				statement();
			}
			catch
			{
			}
		}
	}
}