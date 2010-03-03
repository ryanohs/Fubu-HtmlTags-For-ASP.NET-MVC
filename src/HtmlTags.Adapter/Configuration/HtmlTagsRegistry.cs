using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FubuMVC.UI;
using FubuMVC.UI.Configuration;
using FubuMVC.UI.Tags;

namespace HtmlTags.Adapter.Configuration
{
	public static class HtmlTagsRegistry
	{
		public static void AddRegistrationsToContainer(IWindsorContainer container)
		{
            container.Register(Component.For<IElementNamingConvention>().ImplementedBy<DefaultElementNamingConvention>());
            container.Register(Component.For<Stringifier>().ImplementedBy<Stringifier>());
            container.Register(Component.For(typeof(ITagGenerator<>)).ImplementedBy(typeof(TagGenerator<>)));
            container.Register(Component.For<TagProfileLibrary>().LifeStyle.Singleton);

			var library = container.Resolve<TagProfileLibrary>();
			var conventions = container.Resolve<HtmlConventionRegistry>();
			library.ImportRegistry(conventions);
		}
	}
}