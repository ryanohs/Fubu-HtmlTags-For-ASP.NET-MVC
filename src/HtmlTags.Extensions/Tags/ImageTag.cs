namespace HtmlTags.Extensions
{
	using System;

	public class ImageTag : HtmlTag
	{
		public ImageTag()
			: base(HtmlTagConstants.Img)
		{

		}

		public ImageTag Src(string source)
		{
			Attr(HtmlAttributeConstants.Src, source);
			return this;
		}

		public ImageTag Src(ImageType type, byte[] source)
		{
			Attr(HtmlAttributeConstants.Src,
			     string.Format("data:image/{0},{1}", type.ToString().ToLower(), Convert.ToBase64String(source)));
			return this;
		}

		public ImageTag Alt(string alt)
		{
			Attr(HtmlAttributeConstants.Alt, alt);
			return this;
		}

		public string Src()
		{
			return Attr(HtmlAttributeConstants.Src);
		}

		public string Alt()
		{
			return HasAttr(HtmlAttributeConstants.Alt) ? Attr(HtmlAttributeConstants.Alt) : "";
		}
	}
}