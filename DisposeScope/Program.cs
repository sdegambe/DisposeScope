using System;
using DisposeScope.Containers;

namespace DisposeScope
{
    class Program
    {
        static void Main(string[] args)
        {
            //new AutofacScope().AutofacScopeTest();
            //new NinjectScope().NinjectScopeTest();
            //new WindsorScope().WindsorScopeTest();
            new UnityScope().UnityScopeTest();
            Console.ReadLine();
        }

        

        

        

        
    }
}
