using MefSample.Common;
using System;
using System.ComponentModel.Composition;

namespace MefSample.Module
{
    [Export(typeof(IModule))]
    internal class PropertyExportModule : IModule
    {
        /// <inheritdoc/>
        void IModule.Run()
        {
            new SampleInitializer().Initialize();

            var s1 = MefManager.Instance.GetExportedValue<SampleUser>();
            var s2 = MefManager.Instance.GetExportedValue<SampleUser>();
            Console.WriteLine(s1.Sample.Id);
            Console.WriteLine(s2.Sample.Id);

        }

        interface ISample
        {
            string Name { get; }

            Guid Id { get; }
        }

        class SampleInitializer
        {
            [Export(typeof(ISample))]
            private ISample Sample { get; set; }

            public void Initialize()
            {
                Sample = new Sample1();
                MefManager.Instance.ComposeParts(this);
            }
        }

        class Sample1 : ISample
        {
            public string Name => nameof(Sample1);

            public Guid Id { get; } = Guid.NewGuid();
        }

        [Export]
        class SampleUser
        {
            [Import]
            public ISample Sample { get; set; }
        }
    }
}
