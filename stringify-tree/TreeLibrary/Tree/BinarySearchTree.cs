using System;
using System.Collections.Generic;
using TreeLibrary.TraversalStrategies;

namespace TreeLibrary.Tree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; protected set; }

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(T value)
        {
            Root = new Node<T>(value);
        }

        #region Add

        public void Add(T value)
        {
            if (!ValueIsValidToBeAdded(value))
            {
                return;
            }

            if (Root == null)
            {
                Root = new Node<T>(value);
            }
            else
            {
                AddTo(Root, value);
            }
        }

        public void AddRange(IEnumerable<T> values)
        {
            if (values == null)
            {
                return;
            }

            foreach (var value in values)
            {
                Add(value);
            }
        }

        protected virtual bool ValueIsValidToBeAdded(T value) => true;

        private void AddTo(Node<T> node, T value)
        {
            if (node.CompareValue(value) == 0)
            {
                // do nothing
            }
            else if (node.CompareValue(value) > 0)
            {
                if (node.Left == null)
                {
                    node.AddLeft(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.AddRight(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        #endregion

        #region Remove

        public void Remove(T value)
        {
            var node = FindByValue(value);
            var parent = node?.Parent;

            if (node == null)
            {
                return;
            }

            if (node.Right == null)
            {
                if (parent == null)
                {
                    SetRoot(node.Left);
                }
                else
                {
                    int result = parent.CompareValue(node.Value);
                    if (result > 0)
                    {
                        parent.SetLeft(node.Left);
                        node.Left?.SetParent(parent);
                    }
                    else if (result < 0)
                    {
                        parent.SetRight(node.Left);
                        node.Left?.SetParent(parent);
                    }
                }
            }
            else if (node.Right.Left == null)
            {
                node.Right.SetLeft(node.Left);
                node.Left?.SetParent(node.Right);

                if (parent == null)
                {
                    SetRoot(node.Right);
                }
                else
                {
                    int result = parent.CompareValue(node.Value);
                    if (result > 0)
                    {
                        parent.SetLeft(node.Right);
                        node.Right?.SetParent(parent);
                    }
                    else if (result < 0)
                    {
                        parent.SetRight(node.Right);
                        node.Right?.SetParent(parent);
                    }
                }
            }
            else
            {
                var leftmost = node.Right.Left;
                while (leftmost.Left != null)
                {
                    leftmost = leftmost.Left;
                }

                leftmost.SetLeft(node.Left);
                node.Left?.SetParent(leftmost);

                leftmost.SetRight(node.Right);
                node.Right?.SetParent(leftmost);
                leftmost.Parent?.SetLeft(null);

                if (parent == null)
                {
                    SetRoot(leftmost);
                }
                else
                {
                    int result = parent.CompareValue(node.Value);
                    if (result > 0)
                    {
                        parent.SetLeft(leftmost);
                        leftmost.SetParent(parent);
                    }
                    else if (result < 0)
                    {
                        parent.SetRight(leftmost);
                        leftmost.SetParent(parent);
                    }
                }
            }
        }

        private void SetRoot(Node<T> node)
        {
            Root = node;
            Root?.SetParent(null);
        }

        #endregion

        #region Find

        public Node<T> FindByValue(T value)
        {
            var node = Root;

            while (node != null)
            {
                var result = node.CompareValue(value);

                if (result > 0)
                {
                    node = node.Left;
                }
                else if (result < 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }
            return node;
        }

        #endregion

        #region Traverse

        public IEnumerable<T> TraversePreOrder() => Traverse(new PreOrderTraversal<T>());
        public IEnumerable<T> TraverseInOrder() => Traverse(new InOrderTraversal<T>());
        public IEnumerable<T> TraversePostOrder() => Traverse(new PostOrderTraversal<T>());

        private IEnumerable<T> Traverse(ITraversalStrategy<T> strategy)
        {
            return strategy.Traverse(Root);
        }

        #endregion

        #region Equality

        public override bool Equals(object other)
        {
            if (other == null) return false;

            var otherTree = other as BinarySearchTree<T>;
            if (otherTree == null) return false;

            if (Root == null && otherTree.Root == null) return true;

            if (Root != null && otherTree.Root == null || Root == null && otherTree.Root != null) return false;

            return Root.Equals(otherTree.Root);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode(); // TODO: ??
        }

        #endregion
    }

}
