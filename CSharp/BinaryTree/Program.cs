using System;
using System.Linq;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>()
            {
                1,2,3,6,4,2,76,34,0,76,45,33,2222,5,42,57,653,2345,8998,776
            };
            bool f = bst.Remove(5);
            bool s = bst.Remove(8998);

            foreach (var i in bst)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(f.ToString() + s);
            Console.ReadKey();
        }
    }
}
