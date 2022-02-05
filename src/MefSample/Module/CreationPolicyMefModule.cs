using MefSample.Common;
using System;
using System.ComponentModel.Composition;

namespace MefSample.Module
{
    [Export(typeof(IModule))]
    internal class CreationPolicyMefModule : IModule
    {
        [Import]
        private UserNonShared NonShared1 { get; set; }

        [Import]
        private UserNonShared NonShared2 { get; set; }

        [Import]
        private UserShared Shared1 { get; set; }

        [Import]
        private UserShared Shared2 { get; set; }

        /// <inheritdoc/>
        void IModule.Run()
        {
            Console.WriteLine($"{nameof(NonShared1)}.Id: {NonShared1.Id}");
            Console.WriteLine($"{nameof(NonShared2)}.Id: {NonShared2.Id}");

            Console.WriteLine($"{nameof(Shared1)}.Id: {Shared1.Id}");
            Console.WriteLine($"{nameof(Shared2)}.Id: {Shared2.Id}");
        }
    }
}
