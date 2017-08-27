using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
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

        //It is only one of possible implementations (PS - Algorithms and Data Structures Part 1)
        //On Wiki there is other with examples in python
        public bool Remove(T node)
        {
            Node<T> parent;
            Node<T> nodeToRemove = FindWithParent(node, out parent);

            if (nodeToRemove == null)
            {
                return false;
            }
            count--;

            //Case 1: Current (deleted) has no right child, so current's left child (node) replaces current
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
                nodeToRemove.RightNode.LeftNode = nodeToRemove.LeftNode;
                if (parent == null)
                {
                    head = nodeToRemove.RightNode.RightNode;
                }
                else
                {
                    if (parent.CompareTo(nodeToRemove) <= 0)
                    {
                        parent.RightNode = nodeToRemove.RightNode;
                    }
                    else
                    {
                        parent.LeftNode = nodeToRemove.RightNode;
                    }
                }
            }

            //Case 3: Current's right child has a left child, so we should find leftmost node
            //in subtree that starts from right child of removing node (as a head)
            //Again, we replace current (deleted) node with current's right child's leftmost child
            else
            {
                //Find the right's leftmost child and a parent of the child
                var leftmostChild = nodeToRemove.RightNode.LeftNode;
                var leftmostChildParent = nodeToRemove.RightNode;

                while (leftmostChild.LeftNode != null)
                {
                    leftmostChildParent = leftmostChild;
                    leftmostChild = leftmostChild.LeftNode;
                }

                //The parent's left subtree becomes the leftmost's right subtree
                leftmostChildParent.LeftNode = leftmostChild.RightNode;

                leftmostChild.RightNode = nodeToRemove.RightNode;
                leftmostChild.LeftNode = nodeToRemove.LeftNode;

                if (parent == null)
                {
                    head = leftmostChild;
                }

                if (parent.CompareTo(nodeToRemove) <= 0)
                {
                    parent.RightNode = leftmostChild;
                }
                else
                {
                    parent.LeftNode = leftmostChild;
                }
            }

            return true;
        }

        #region recursive silly implementations of traversal

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, head);
        }

        private void PreOrderTraversal(Action<T> action, Node<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.LeftNode);
                PreOrderTraversal(action, node.RightNode);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, head);
        }

        private void PostOrderTraversal(Action<T> action, Node<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.LeftNode);
                PostOrderTraversal(action, node.RightNode);
                action(node.Value);
            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, head);
        }

        private void InOrderTraversal(Action<T> action, Node<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.LeftNode);
                action(node.Value);
                InOrderTraversal(action, node.RightNode);
            }
        }

        #endregion

        public IEnumerator<T> InOrderTraversal()
        {
            if (head != null)
            {
                //Store the nodes we've skipped in the stack (to avoid recursion)
                var nodes = new Stack<Node<T>>();

                Node<T> currentNode = head;

                //When removing recursion we need to keep track of whether ot not
                //we should be going to the left ot the right nodes next
                bool goLeftNext = true;

                nodes.Push(head);

                while (nodes.Count > 0)
                {
                    //If we are heading left
                    if (goLeftNext)
                    {
                        //push everithing but the leftmost node to the stack
                        //we'll yield the leftmost after this bock
                        while (currentNode.LeftNode != null)
                        {
                            nodes.Push(currentNode);
                            currentNode = currentNode.LeftNode;
                        }

                        yield return currentNode.Value;

                        //if we can go right then do so
                        if (currentNode.RightNode != null)
                        {
                            currentNode = currentNode.RightNode;

                            //once we've gone right once, we need to start
                            //going left again
                            goLeftNext = true;
                        }
                        else
                        {
                            // if we can't go right then we need to pop off the parent node
                            // so we can process it and then go to it's right child
                            currentNode = nodes.Pop();
                            goLeftNext = false;
                        }
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public int Count => count;

    }
}