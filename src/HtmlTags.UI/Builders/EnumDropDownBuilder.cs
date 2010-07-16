namespace HtmlTags.UI.Builders
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Reflection;
	using Attributes;
	using Conventions;
	using FubuCore.Reflection;
	using FubuMVC.UI.Configuration;
	using HtmlTags;

	public class EnumDropDownBuilder : BaseElementBuilder
	{
		protected override bool matches(AccessorDef def)
		{
			throw new NotImplementedException();
		}

		protected override HtmlTag BuildTag(ElementRequest request)
		{
			return new SelectTag(BuildOptions(request)).Id(request.ElementId).Attr("name", request.ElementId);
		}

		private Action<SelectTag> BuildOptions(ElementRequest req)
		{
			var hasBlankOption = req.Accessor.HasAttribute<WithBlankOption>();
			return tag =>
			       	{
			       		var options = GetOptions(req);
			       		if (hasBlankOption)
			       		{
			       			tag.Option("", "");
			       		}
			       		foreach (var f in options)
			       		{
			       			tag.Option(GetText(f, req), f.GetRawConstantValue().ToString());
			       		}
			       		if (!req.ValueIsEmpty())
			       		{
			       			tag.SelectByValue(req.Value<int>().ToString());
			       		}
			       	};
		}

		protected virtual IEnumerable<FieldInfo> GetOptions(ElementRequest req)
		{
			var propertyType = req.Accessor.PropertyType;
			if (propertyType.IsGenericType)
			{
				propertyType = new NullableConverter(propertyType).UnderlyingType;
			}
			return propertyType.GetFields((BindingFlags.Public | BindingFlags.Static));
		}

		private string GetText(FieldInfo field, ElementRequest req)
		{
			var descriptor = field.GetAttribute<DescriptionAttribute>();
			if (descriptor != null)
			{
				return descriptor.Description;
			}
			return LabelingConvention.GetLabelText(field.Name);
		}
	}
}