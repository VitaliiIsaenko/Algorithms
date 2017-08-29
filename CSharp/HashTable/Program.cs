using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            FoldingHasher fh = new FoldingHasher();
            Console.WriteLine(fh.Hash("Hello World!"));
            Console.ReadKey();
        }
    }
}
