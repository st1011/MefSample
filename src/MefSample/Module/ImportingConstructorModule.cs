using MefSample.Common;
using System;
using System.ComponentModel.Composition;

namespace MefSample.Module
{
    [Export(typeof(IModule))]
    internal class ImportingConstructorModule : IModule
    {
        private readonly UserNonShared m_nonShared1;
        private readonly UserNonShared m_nonShared2;
        private readonly IUser m_hasId;

        private readonly UserShared m_shared1;
        private readonly UserShared m_shared2;

        public ImportingConstructorModule()
        {
            // Not be used.
            throw new NotImplementedException();
        }

        [ImportingConstructor]
        public ImportingConstructorModule(UserNonShared nonShared1, UserNonShared nonShared2,
            UserShared sampleShared1, UserShared sampleShared2,
            [Import(typeof(UserShared))] IUser hasId)
        {
            m_nonShared1 = nonShared1;
            m_nonShared2 = nonShared2;
            m_shared1 = sampleShared1;
            m_shared2 = sampleShared2;

            m_hasId = hasId;
        }

        /// <inheritdoc/>
        void IModule.Run()
        {
            Console.WriteLine($"{nameof(m_nonShared1)}.Id: {m_nonShared1.Id}");
            Console.WriteLine($"{nameof(m_nonShared2)}.Id: {m_nonShared2.Id}");
            Console.WriteLine($"{nameof(m_shared1)}.Id: {m_shared1.Id}");
            Console.WriteLine($"{nameof(m_shared2)}.Id: {m_shared2.Id}");
            Console.WriteLine();
            Console.WriteLine($"{nameof(m_hasId)}.Id: {m_hasId.Id}");
        }
    }
}
