using CompositionRoot.Kernel;
using SimpleInjector;

namespace CompositionRoot.Plugin.Japanese
{
    public class BootstrapPlugin: IBootstrap
    {
        public void Bootstrap(Container container)
        {
            container.Register<ILanguage, Japanese>();
        }
    }
}
