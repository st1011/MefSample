using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MefSample
{
    internal class MefManager
    {
        public CompositionContainer Container { get; }

        public static MefManager Instance { get; }

        public T GetExportedValue<T>(string constractName = null)
        {
            return Container.GetExportedValue<T>(constractName);
        }

        public void ComposeParts(params object[] parts)
        {
            Container.ComposeParts(parts);
        }

        public void SatisfyImports(object target)
        {
            _ = Container.SatisfyImportsOnce(target);
        }

        private MefManager()
        {
            Container = CreateDefaultContainer();
        }

        static MefManager()
        {
            Instance = new MefManager();
        }

        private static CompositionContainer CreateDefaultContainer()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            return new CompositionContainer(catalog);
        }
    }
}
