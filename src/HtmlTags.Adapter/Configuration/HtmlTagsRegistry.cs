using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
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
			_(Component.For(typeof (ITagGenerator<>)).ImplementedBy(typeof (TagGenerator<>)));
			_(Component.For<TagProfileLibrary>().LifeStyle.Singleton);
		}

		public override void AddRegistrationsToContainer(IWindsorContainer container)
		{
			base.AddRegistrationsToContainer(container);

			var library = container.Resolve<TagProfileLibrary>();
			var conventions = container.ResolveAll<HtmlConventions>();
			Array.ForEach(conventions, library.ImportRegistry);
		}
	}
}