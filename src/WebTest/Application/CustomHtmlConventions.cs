using System;
using FubuMVC.UI;

namespace WebTest.Application
{
	public class CustomHtmlConventions : HtmlConventions
	{
		public CustomHtmlConventions()
		{
			Editors.Always.Attr("class", "test");
			Editors.IfPropertyIs<DateTime>().Modify(tag => tag.AddClass("picker"));
		}
	}
}