using System;

namespace DisposeScope
{
    class FileWriter : IWriter
    {
        public void Write()
        {
            Console.WriteLine("write");
        }
    }
}
