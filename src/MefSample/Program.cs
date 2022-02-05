using MefSample.Common;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace MefSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompositionContainer container = MefManager.Instance.Container;
            var executables = container.GetExportedValues<IModule>();
            foreach (var executable in executables)
            {
                string moduleName = executable.GetType().Name;

                Console.WriteLine($"===== '{moduleName}' begin =====");
                executable.Run();
                Console.WriteLine($"===== '{moduleName}' end =====");
                Console.WriteLine();
            }

            Console.WriteLine($"All modules done.");
        }
    }
}
