using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SimpleInjector;

namespace CompositionRoot.Kernel
{
    public static class Bootstrapper
    {
        public static Container Container;

        static Bootstrapper()
        {
            Container = new Container();

            var pluginDirectory =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            var pluginAssemblies =
                from file in new DirectoryInfo(pluginDirectory).GetFiles()
                where file.Extension.ToLower() == ".dll"
                select Assembly.LoadFrom(file.FullName);

            Container.RegisterCollection<IPlugin>(pluginAssemblies);

            foreach (var bootstrapType in GetBootstrapTypes())
            {
                var bootstrap = (IBootstrap)Activator.CreateInstance(bootstrapType);
                bootstrap.Bootstrap(Container);
            }

#if DEBUG
            Container.Verify(VerificationOption.VerifyAndDiagnose);
#else
            _container.Verify();
#endif
        }

        private static IEnumerable<Type> GetBootstrapTypes() =>
            from assembly in AppDomain.CurrentDomain.GetAssemblies()
            from type in assembly.GetExportedTypes()
            where typeof(IBootstrap).IsAssignableFrom(type) && !type.IsAbstract
            select type;
    }
}
