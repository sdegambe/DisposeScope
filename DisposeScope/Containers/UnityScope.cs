using System;
using Microsoft.Practices.Unity;

namespace DisposeScope.Containers
{
    class UnityScope
    {
        public void UnityScopeTest()
        {
            Console.WriteLine("UnityScopeTest" + Environment.NewLine);
            var container = new UnityContainer();
            container.RegisterType<IWriter, FileWriter>();
            container.RegisterType<IReader, FileReader>();
            container.RegisterType<Service>(new TransientLifetimeManager());
            //container.RegisterType<Service>(new ContainerControlledLifetimeManager());
            //container.RegisterType<Service>(new HierarchicalLifetimeManager());
            //container.RegisterType<Service>(new PerThreadLifetimeManager());
            using (var scope = container)
            {
                Console.WriteLine("In using" + Environment.NewLine);
                var service = scope.Resolve<Service>();
                service.Counter += 1;
                Console.WriteLine($"Counter = {service.Counter}" + Environment.NewLine);
                var service2 = scope.Resolve<Service>();
                service2.Counter += 1;
                Console.WriteLine($"Counter = {service2.Counter}" + Environment.NewLine);
            }

            Console.WriteLine("After using" + Environment.NewLine);
            var service3 = container.Resolve<Service>();
            service3.Counter += 1;
            Console.WriteLine($"Counter = {service3.Counter}" + Environment.NewLine);
            var service4 = container.Resolve<Service>();
            service4.Counter += 1;
            Console.WriteLine($"Counter = {service4.Counter}" + Environment.NewLine);
        }
    }
}
