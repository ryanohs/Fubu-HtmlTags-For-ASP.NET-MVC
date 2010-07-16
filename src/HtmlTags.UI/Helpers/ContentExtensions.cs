namespace HtmlTags.UI.Helpers
{
	using System;
	using System.IO;
	using System.Web;
	using System.Web.Mvc;
	using HtmlTags;
	using HtmlTags.Extensions;

	public static class HtmlContentExtensions
	{
		public static string DefaultScriptLocation = "~/Content";
		public static string DefaultStyleSheetLocation = "~/Content";

		public static HtmlTag Stylesheet(this HtmlHelper html, string location)
		{
			var path = GetPath(DefaultStyleSheetLocation, location);
			return Tags.CssLink(path);
		}

		public static HtmlTag ScriptInclude(this HtmlHelper html, string location)
		{
			var path = GetPath(DefaultScriptLocation, location);
			return Tags.ScriptInclude(path);
		}

		private static string GetPath(string defaultRoot, string location)
		{
			if(location.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase)
				|| location.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
			{
				return location;
			}
			if(VirtualPathUtility.IsAppRelative(location))
			{
				return VirtualPathUtility.ToAbsolute(location);
			}
			if(VirtualPathUtility.IsAbsolute(location))
			{
				return location;
			}
			return VirtualPathUtility.ToAbsolute(Path.Combine(defaultRoot, location));
		}

		public static string GetPath(string location)
		{
			return GetPath("~/", location);
		}
	}
}