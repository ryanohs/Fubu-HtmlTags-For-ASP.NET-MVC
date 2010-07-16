namespace WebTest
{
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	using Application;
	using Castle.MicroKernel.Registration;
	using Castle.Windsor;
	using CommonServiceLocator.WindsorAdapter;
	using HtmlTags.Adapter.Configuration;
	using HtmlTags.UI;
	using HtmlTags.UI.Builders;
	using HtmlTags.UI.Conventions;
	using Microsoft.Practices.ServiceLocation;

	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new {controller = "Product", action = "Index", id = ""} // Parameter defaults
				);
		}

		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);

			var container = new WindsorContainer();
			LocalHtmlConventionRegistry.AddRegistrationsToContainer(container); // must be before HtmlTagsRegistry.
			HtmlTagsRegistry.AddRegistrationsToContainer(container);
			ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
			container.Register(Component.For<IServiceLocator>().Instance(ServiceLocator.Current).LifeStyle.Singleton);
			SetupStaticConventions();
		}

		private void SetupStaticConventions()
		{
			BaseElementBuilder.Security = new NoElementBuilderSecurity();
			LabelingConvention.Convention = new SpaceBeforeCapitalsLabelingConvention();
			SaveOrCancelConvention.Convention = new SaveOrCancelButtonsConvention();
			// Alternative style:
			// SaveOrCancelConvention.Convention = new SaveButtonOrCancelLinkConvention();
		}
	}
}