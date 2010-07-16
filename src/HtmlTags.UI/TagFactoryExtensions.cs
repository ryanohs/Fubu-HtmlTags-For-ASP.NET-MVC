namespace HtmlTags.UI
{
	using System;
	using System.ComponentModel;
	using FubuCore.Reflection;
	using FubuMVC.UI.Tags;

	public static class TagFactoryExtensions
	{
		public static TagActionExpression IfPropertyTypeIsEnum(this TagFactoryExpression expression)
		{
			return expression.IfPropertyTypeIs(t => t.IsEnum);
		}

		public static TagActionExpression IfPropertyTypeIsNullableEnum(this TagFactoryExpression expression)
		{
			return expression.If(f =>
			                     	{
			                     		var propertyType = f.Accessor.InnerProperty.PropertyType;
			                     		return propertyType.IsGenericType
			                     		       && propertyType.GetGenericTypeDefinition() == typeof (Nullable<>)
			                     		       && new NullableConverter(propertyType).UnderlyingType.IsEnum;
			                     	});
		}

		public static TagActionExpression IfPropertyHasAttribute<T>(this TagFactoryExpression expression) where T : Attribute
		{
			return expression.If(req => req.Accessor.HasAttribute<T>());
		}

		public static TagActionExpression IfPropertyIs<T1, T2>(this TagFactoryExpression expression)
		{
			return expression.If(req => req.Accessor.PropertyType == typeof (T1) || req.Accessor.PropertyType == typeof (T2));
		}

		public static TagActionExpression IfIsAccountId(this TagFactoryExpression expression) 
		{
			return expression.If(req => req.Accessor.FieldName =="AccountId");
		}
	}
}