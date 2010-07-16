namespace HtmlTags.UI.Builders
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Attributes;
	using FubuCore;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;
	using Extensions;

	public class SelectBuilder
	{
		public static SelectTag Build(ElementRequest req)
		{
			return new SelectTag(BuildOptions(req)).Id(req.ElementId) as SelectTag;
		}

		public static HtmlTag AjaxBuild(ElementRequest req)
		{
			return new HtmlTag("span").AddChildren(new[]
			                                       	{
			                                       		new SelectTag().Id(req.ElementId).Attr("name", req.ElementId),
			                                       		new ScriptTag("var default{0} = {1};".ToFormat(req.ElementId, req.RawValue))
			                                       	});
		}

		private static Action<SelectTag> BuildOptions(ElementRequest req)
		{
			var fromAttrib = GetOptionsFromAttribute(req);
			var optionPairs = GetOptionPairs(req, fromAttrib);
			var hasBlankOption = req.Accessor.HasAttribute<WithBlankOption>();

			return tag =>
			       	{
			       		if (hasBlankOption)
			       		{
			       			tag.Option("", "");
			       		}
			       		foreach (var item in optionPairs)
			       		{
			       			tag.Option(item.Text, item.Value);
			       		}
			       		if (req.RawValue != null)
			       		{
			       			tag.SelectByValue(req.RawValue.ToString());
			       		}
			       	};
		}

		private static Options GetOptionPairs(ElementRequest req, OptionsFromAttribute fromAttrib)
		{
			var fromProperty = req.Accessor.DeclaringType.GetProperties().FirstOrDefault(p => p.Name == fromAttrib.PropertyName);
			if (fromProperty == null)
			{
				throw new Exception(string.Format("Could not find options source property '{0}' on type '{1}'",
				                                  fromAttrib.PropertyName, req.Accessor.DeclaringType.Name));
			}
			return fromProperty.GetGetMethod().Invoke(req.Model, null) as Options;
		}

		private static OptionsFromAttribute GetOptionsFromAttribute(ElementRequest req)
		{
			var fromAttribType = typeof (OptionsFromAttribute);
			var fromAttrib = req.Accessor.GetAttribute<OptionsFromAttribute>();
			if (fromAttrib == null)
			{
				throw new Exception(string.Format("Expected property '{0}' to have decorator: {1}.",
				                                  req.ElementId, fromAttribType.Name));
			}
			return fromAttrib;
		}
	}
}