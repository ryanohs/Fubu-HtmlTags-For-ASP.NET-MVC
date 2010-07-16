namespace HtmlTags.UI.Helpers
{
	using System;
	using System.Reflection;

	public static class EnumHelper
	{
		public static FieldInfo[] GetOptions(Type enumType)
		{
			return enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
		}
	}
}