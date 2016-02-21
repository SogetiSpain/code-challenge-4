using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EmployeeWebService;
using IServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IoC.Installer
{
    public class WindsorWebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IServiceInvoker>()
                                .ImplementedBy<ServiceInvoker>().LifestyleSingleton());
            container.Register(Component.For<IDataService>()
                                .ImplementedBy<DataService>().LifestylePerThread());
            container.Register(Component.For<IEmployeeService>()
                                .ImplementedBy<EmployeeService>().LifestylePerThread());
        }
    }
}
