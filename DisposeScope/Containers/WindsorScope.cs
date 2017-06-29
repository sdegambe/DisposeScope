using System;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace DisposeScope.Containers
{
    class WindsorScope
    {
        public  void WindsorScopeTest()
        {
            Console.WriteLine("WindsorScopeTest" + Environment.NewLine);
            var container = new WindsorContainer();
            container.Register(Component.For<IReader>().ImplementedBy<FileReader>());
            container.Register(Component.For<IWriter>().ImplementedBy<FileWriter>());
            //container.Register(Component.For<Service>());
            //container.Register(Component.For<Service>().LifestyleSingleton());
            //container.Register(Component.For<Service>().LifestyleTransient());
            //container.Register(Component.For<Service>().LifestylePerThread());
            container.Register(Component.For<Service>().LifestyleScoped());
            using (container.BeginScope())
            {
                Console.WriteLine("In using" + Environment.NewLine);
                var service = container.Resolve<Service>();
                service.Counter += 1;
                Console.WriteLine($"Counter = {service.Counter}" + Environment.NewLine);
                var service2 = container.Resolve<Service>();
                service2.Counter += 1;
                Console.WriteLine($"Counter = {service2.Counter}" + Environment.NewLine);
            }

            Console.WriteLine("After Using" + Environment.NewLine);
            var service3 = container.Resolve<Service>();
            service3.Counter += 1;
            Console.WriteLine($"Counter = {service3.Counter}" + Environment.NewLine);
            var service4 = container.Resolve<Service>();
            service4.Counter += 1;
            Console.WriteLine($"Counter = {service4.Counter}" + Environment.NewLine);
        }
    }
}
