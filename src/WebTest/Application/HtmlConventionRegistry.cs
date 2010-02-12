using Castle.MicroKernel.Registration;
using FubuMVC.UI;
using HtmlTags.Adapter.Configuration;

namespace WebTest.Application
{
	public class HtmlConventionRegistry : RegistryBase
	{
		public HtmlConventionRegistry()
		{
			_(Component.For<HtmlConventions>().ImplementedBy<CustomHtmlConventions>());
			_(Component.For<HtmlConventions>().ImplementedBy<DefaultHtmlConventions>());
		}
	}
}