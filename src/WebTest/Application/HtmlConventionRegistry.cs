using Castle.MicroKernel.Registration;
using FubuMVC.UI;
using HtmlTags.Adapter.Configuration;

namespace WebTest.Application
{
	public class LocalHtmlConventionRegistry : RegistryBase
	{
		public LocalHtmlConventionRegistry()
		{
			_(Component.For<HtmlConventionRegistry>().ImplementedBy<CustomHtmlConventions>());
			_(Component.For<HtmlConventionRegistry>().ImplementedBy<DefaultHtmlConventions>());
		}
	}
}