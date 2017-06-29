using System;

namespace DisposeScope
{
    class FileReader : IReader
    {
        public void Read()
        {
            Console.WriteLine("read");
        }
    }
}
