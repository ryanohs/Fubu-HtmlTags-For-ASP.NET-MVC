namespace HtmlTags.UI.Builders
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Attributes;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;
	using HtmlTags;
	using Extensions;

	public class CheckBoxListBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			return def.Accessor.HasAttribute<CheckBoxListAttribute>();
		}

		protected override HtmlTag BuildTag(ElementRequest req)
		{
			var attrib = GetCheckBoxListAttribute(req);
			var optionPairs = GetOptionPairs(req, attrib);
			var checkedOptions = req.Value<IList<int>>().Cast<object>();
			var groupName = req.ElementId;

			var div = attrib.Horizontal ? Tags.Span : Tags.Div;
			foreach (var item in optionPairs)
			{
				var isChecked = checkedOptions.Contains(item.Value);
				var label = Tags.Label.For(groupName).Text(item.Text);
				var checkBox = Tags.Checkbox(isChecked).Name(groupName).Value(item.Value);

				div.Nest(
					Tags.Div.Nest(
						Tags.Span
							.AddClass("option")
							.AddClass(attrib.Horizontal ? "horizontalOption" : "")
							.Nest(
								label,
								checkBox
							)));
			}
			return div.AddClass("checkboxes");
		}

		protected virtual Options GetOptionPairs(ElementRequest req, CheckBoxListAttribute attrib)
		{
			var optionsProperty = req.Accessor.DeclaringType.GetProperties().FirstOrDefault(p => p.Name == attrib.OptionsFrom);
			if (optionsProperty == null)
			{
				throw new Exception(string.Format("Could not find options source property '{0}' on type '{1}'",
				                                  attrib.OptionsFrom, req.Accessor.DeclaringType.Name));
			}
			return optionsProperty.GetGetMethod().Invoke(req.Model, null) as Options;
		}

		protected virtual CheckBoxListAttribute GetCheckBoxListAttribute(ElementRequest req)
		{
			var attribType = typeof (CheckBoxListAttribute);
			var attrib = req.Accessor.GetAttribute<CheckBoxListAttribute>();
			if (attrib == null)
			{
				throw new Exception(string.Format("Expected property '{0}' to have attribute: {1}.",
				                                  req.ElementId, attribType.Name));
			}
			return attrib;
		}
	}
}