using SimpleInjector;

namespace CompositionRoot.Kernel
{
    public interface IBootstrap
    {
        void Bootstrap(Container container);
    }
}
