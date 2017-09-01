using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Node<TNode> : IComparable<Node<TNode>>
        where TNode : IComparable<TNode>
    {
        public Node(TNode value)
        {
            Value = value;
        }

        public Node<TNode> LeftNode { get; set; }

        public Node<TNode> RightNode { get; set; }

        public TNode Value { get; set; }

        public int CompareTo(Node<TNode> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
