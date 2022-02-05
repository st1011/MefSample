using MefSample.Common;
using System;
using System.ComponentModel.Composition;

namespace MefSample.Module
{
    [Export(typeof(IModule))]
    internal class LazyImportModule : IModule
    {
        [Import]
        private Lazy<UserNonShared> m_nonShared;

        /// <inheritdoc/>
        void IModule.Run()
        {
            Console.WriteLine($"IsCreated: {m_nonShared.IsValueCreated}");
            Console.WriteLine($"Id: {m_nonShared.Value.Id}");
            Console.WriteLine($"IsCreated: {m_nonShared.IsValueCreated}");
        }
    }
}
