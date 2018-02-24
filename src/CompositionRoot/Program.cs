using System;
using CompositionRoot.Kernel;

namespace CompositionRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var plugin in Bootstrapper.Container.GetAllInstances<IPlugin>())
            {
                Console.WriteLine(plugin.SayHello());
            }

            Console.ReadLine();
        }
    }
}
