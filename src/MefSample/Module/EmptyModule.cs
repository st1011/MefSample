using MefSample.Common;
using System;
using System.ComponentModel.Composition;

namespace MefSample.Module
{
    [Export(typeof(IModule))]
    internal class EmptyModule : IModule
    {
        /// <inheritdoc/>
        void IModule.Run()
        {

        }
    }
}
