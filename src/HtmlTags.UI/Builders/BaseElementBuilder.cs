namespace HtmlTags.UI.Builders
{
	using System;
	using System.ComponentModel;
	using Extensions;
	using FubuMVC.UI.Configuration;

	public abstract class BaseElementBuilder : ElementBuilder
	{
		public static IElementBuilderSecurity Security { get; set; }

		public override HtmlTag Build(ElementRequest request)
		{
			return Security.ApplySecurity(request)
			       ?? BuildTag(request);
		}

		protected abstract HtmlTag BuildTag(ElementRequest request);

		protected Type RemoveNullableIfNecessary(Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
			{
				return new NullableConverter(type).UnderlyingType;
			}
			return type;
		}

		public static HtmlTag EmptyTag
		{
			get { return Tags.Span; }
		}
	}
}