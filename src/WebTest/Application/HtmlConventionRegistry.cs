using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FubuMVC.UI;

namespace WebTest.Application
{
	public static class LocalHtmlConventionRegistry
	{
		public static void AddRegistrationsToContainer(IWindsorContainer container)
		{
			container.Register(Component.For<HtmlConventionRegistry>().ImplementedBy<CustomHtmlConventions>());
		}
	}
}