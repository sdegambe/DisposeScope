using System;
using Ninject;

namespace DisposeScope.Containers
{
    class NinjectScope
    {
        public void NinjectScopeTest()
        {
            Console.WriteLine("NinjectScopeTest" + Environment.NewLine);
            var kernel = new StandardKernel();
            kernel.Bind<IReader>().To<FileReader>();
            kernel.Bind<IWriter>().To<FileWriter>();
            //kernel.Bind<Service>().ToSelf().InThreadScope();
            //kernel.Bind<Service>().ToSelf().InSingletonScope();
            //kernel.Bind<Service>().ToSelf().InTransientScope();
            using (var scope = kernel.BeginBlock())
            {
                Console.WriteLine("In using" + Environment.NewLine);
                var service = scope.Get<Service>();
                service.Counter += 1;
                Console.WriteLine($"Counter = {service.Counter}" + Environment.NewLine);
                var service2 = scope.Get<Service>();
                service2.Counter += 1;
                Console.WriteLine($"Counter = {service2.Counter}" + Environment.NewLine);
            }

            Console.WriteLine("After using" + Environment.NewLine);

            var service3 = kernel.Get<Service>();
            service3.Counter += 1;
            Console.WriteLine($"Counter = {service3.Counter}" + Environment.NewLine);
            var service4 = kernel.Get<Service>();
            service4.Counter += 1;
            Console.WriteLine($"Counter = {service4.Counter}" + Environment.NewLine);
        }
    }
}
