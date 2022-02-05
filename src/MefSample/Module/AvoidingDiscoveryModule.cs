using MefSample.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MefSample.Module
{
    [Export(typeof(IModule))]
    internal class AvoidingDiscoveryModule : IModule
    {
        [ImportMany]
        private IEnumerable<IBase> m_bases;

        /// <inheritdoc/>
        void IModule.Run()
        {
            foreach (var b in m_bases)
            {
                Console.WriteLine(b.GetType().Name);
            }
        }

        private interface IBase { }

        [Export(typeof(IBase))]
        private class Sub1 : IBase { }

        [InheritedExport(typeof(IBase))]
        private class Sub2 : IBase { }

        // does Not discover
        [Export(typeof(IBase))]
        [PartNotDiscoverable]
        private class Sub3 : IBase { }

        // does Not discover
        [Export(typeof(IBase))]
        private abstract class Sub4 : IBase { }

        // does Not export
        private class Sub5 : Sub1 { }

        private class Sub6 : Sub2 { }

        // does Not discover
        [PartNotDiscoverable]
        private class Sub7 : Sub2 { }


    }
}
