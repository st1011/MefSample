using MefSample.Common;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MefSample.Module
{
    [Export(typeof(IModule))]
    internal class NamingMefModule : IModule
    {
        [Import("Bar")]
        private NamingBase m_bar;

        /// <inheritdoc/>
        void IModule.Run()
        {
            CompositionContainer container = MefManager.Instance.Container;
            var foo = container.GetExportedValue<NamingBase>("Foo");

            Console.WriteLine(foo.Name);
            Console.WriteLine(m_bar.Name);
        }

        private class NamingBase
        {
            public virtual string Name { get; }
        }

        [Export("Foo", typeof(NamingBase))]
        private class Foo : NamingBase
        {
            public override string Name => GetType().Name;
        }

        [Export("Bar", typeof(NamingBase))]
        private class Bar : NamingBase
        {
            public override string Name => GetType().Name;
        }
    }
}
