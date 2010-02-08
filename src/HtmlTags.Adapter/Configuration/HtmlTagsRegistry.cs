using System;
using Castle.MicroKernel.Registration;
using FubuMVC.UI;
using FubuMVC.UI.Configuration;
using FubuMVC.UI.Tags;

namespace HtmlTags.Adapter.Configuration
{
	public class HtmlTagsRegistry : RegistryBase
	{
		public HtmlTagsRegistry()
		{
			_(Component.For<IElementNamingConvention>().ImplementedBy<DefaultElementNamingConvention>());
			_(Component.For<Stringifier>().ImplementedBy<Stringifier>());
			_(Component.For(typeof(ITagGenerator<>)).ImplementedBy(typeof(TagGenerator<>)));

			SetupTagProfileLibrary();
		}

		private void SetupTagProfileLibrary()
		{
			var library = new TagProfileLibrary();
			library.ImportRegistry(new DefaultHtmlConventions());
			_(Component.For<TagProfileLibrary>().Instance(library));
		}
	}
}