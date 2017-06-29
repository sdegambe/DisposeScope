using System;
using Autofac;

namespace DisposeScope.Containers
{
    class AutofacScope
    {
        public void AutofacScopeTest()
        {
            Console.WriteLine("AutofacScopeTest" + Environment.NewLine);
            var builder = new ContainerBuilder();
            builder.RegisterType<FileReader>().As<IReader>();
            builder.RegisterType<FileWriter>().As<IWriter>();
            //builder.RegisterType<Service>();
            //builder.RegisterType<Service>().AsSelf().InstancePerDependency();
            //builder.RegisterType<Service>().AsSelf().SingleInstance();
            //builder.RegisterType<Service>().AsSelf().ExternallyOwned();
            builder.RegisterType<Service>().AsSelf().InstancePerLifetimeScope();
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
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
