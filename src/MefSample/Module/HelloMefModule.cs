using MefSample.Common;
using System;
using System.ComponentModel.Composition;

namespace MefSample.Module
{
    [Export(typeof(IModule))]
    internal class HelloMefModule : IModule
    {
        /// <inheritdoc/>
        void IModule.Run()
        {
            Console.WriteLine("Hello MEF.");
        }
    }
}
