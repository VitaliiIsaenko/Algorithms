using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public interface IBinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        void Add(T value);
        bool Contains(T value);
        bool Remove(T node);
        void PreOrderTraversal(Action<T> action);
        void PostOrderTraversal(Action<T> action);
        void InOrderTraversal(Action<T> action);
        IEnumerator<T> InOrderTraversal();
        void Clear();
        int Count { get; }
    }
}