using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;

namespace HtmlTags.Adapter.Configuration
{
	public class RegistryBase
	{
		public RegistryBase()
		{
			Registrations = new List<IRegistration>();
		}
	
		public IList<IRegistration> Registrations { get; set; }

		public void Register(IServiceLocator locator)
		{
			var container = locator.GetInstance<IWindsorContainer>();
			AddRegistrationsToContainer(container);
		}

		public virtual void AddRegistrationsToContainer(IWindsorContainer container)
		{
			container.Kernel.Register(Registrations.ToArray());
		}

		public void _(IRegistration registration)
		{
			Registrations.Add(registration);
		}
	}
}