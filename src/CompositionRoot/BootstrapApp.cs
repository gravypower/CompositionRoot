using CompositionRoot.Kernel;
using SimpleInjector;

namespace CompositionRoot
{
    public class BootstrapApp: IBootstrap
    {
        public void Bootstrap(Container container)
        {
            container.Register<IPerson, AaronJob>();
        }
    }
}
