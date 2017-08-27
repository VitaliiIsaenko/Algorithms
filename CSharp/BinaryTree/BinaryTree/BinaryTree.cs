using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private Node<T> head;
        private int count;

        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value);
            }
            else
            {
                AddTo(head, value);
            }

            count++;
        }

        private void AddTo(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new Node<T>(value);
                }
                else
                {
                    AddTo(node.LeftNode, value);
                }
            }
            else
            {
                if (node.RightNode == null)
                {
                    node.RightNode = new Node<T>(value);
                }
                else
                {
                    AddTo(node.RightNode, value);
                }
            }
        }

        public bool Contains(T value)
        {
            Node<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        private Node<T> FindWithParent(T value, out Node<T> parent)
        {
            Node<T> current = head;
            parent = null;

            while (current != null)
            {
                int result = current.Value.CompareTo(value);

                if (result < 0)
                {
                    parent = current;
                    current = current.RightNode;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.LeftNode;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        public bool Remove(T node)
        {
            Node<T> parent;
            Node<T> nodeToRemove = FindWithParent(node, out parent);

            if (nodeToRemove == null)
            {
                return false;
            }
            count--;
            
            //Case 1: Current has no right child, so current's left child (node) replaces current
            if (nodeToRemove.RightNode == null)
            {
                if (parent == null)
                {
                    head = nodeToRemove.LeftNode;
                }
                else
                {
                    if (parent.CompareTo(nodeToRemove) <= 0)
                    {
                        parent.RightNode = nodeToRemove.LeftNode;
                    }
                    else
                    {
                        parent.LeftNode = nodeToRemove.LeftNode;
                    }
                }
            }
            
            //Case 2: Current's right child has no left, so current's right replaces current
            else if (nodeToRemove.RightNode.LeftNode == null)
            {

                if (parent == null)
                {
                    
                }
            }


            if (nodeToRemove.LeftNode == null && nodeToRemove.RightNode == null)
            {

                if (parent == null)
                {
                    
                }
                if (parent.CompareTo(nodeToRemove) <= 0)
                {
                    parent.RightNode = null;
                }
                else
                {
                    parent.LeftNode = null;
                }
                return true;
            }

            if (nodeToRemove.LeftNode == null)
            {

            }
        }
    }
}