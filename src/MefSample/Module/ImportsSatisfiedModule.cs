using MefSample.Common;
using System;
using System.ComponentModel.Composition;

namespace MefSample.Module
{
    [Export(typeof(IModule))]
    internal class ImportsSatisfiedModule : IModule
    {
        /// <inheritdoc/>
        void IModule.Run()
        {
            var container = MefManager.Instance.Container;

            var s = container.GetExportedValue<Sample1>();
            Console.WriteLine(s.SampleNonShared.Id);
        }

        [Export]
        private class Sample1: IPartImportsSatisfiedNotification
        {
            [Import]
            public UserNonShared SampleNonShared { get; set; }

            public Sample1()
            {
                Console.WriteLine("Constractor");
                Console.WriteLine($"{nameof(SampleNonShared)}.Id: {SampleNonShared?.Id}");
            }

            void IPartImportsSatisfiedNotification.OnImportsSatisfied()
            {
                Console.WriteLine(nameof(IPartImportsSatisfiedNotification.OnImportsSatisfied));
                Console.WriteLine($"{nameof(SampleNonShared)}.Id: {SampleNonShared?.Id}");
            }
        }
    }
}
