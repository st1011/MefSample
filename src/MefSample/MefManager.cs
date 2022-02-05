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

        private MefManager()
        {
            Container = CreateDefaultContainer();
        }

        static MefManager()
        {
            Instance = new MefManager();
        }

        private CompositionContainer CreateDefaultContainer()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            return new CompositionContainer(catalog);
        }
    }
}
