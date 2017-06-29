using System;
using Autofac.Core;

namespace DisposeScope
{
    class Service : IDisposer
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public int Counter { get; set; }

        public Service(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Dispose()
        {
            Console.WriteLine();
            Console.WriteLine("DISPOSE");
            Console.WriteLine();
        }














        public void AddInstanceForDisposal(IDisposable instance)
        {
            throw new NotImplementedException();
        }
    }
}
