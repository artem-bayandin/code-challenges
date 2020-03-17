using System;

namespace TreeLibrary.Tree
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }
        public Node<T> Parent { get; private set; }

        public Node(T value) : this(value, null)
        {
        }

        public Node(T value, Node<T> parent)
        {
            Value = value;
            SetParent(parent);
        }

        #region Add Left/Right

        internal void AddLeft(T value) => SetLeft(new Node<T>(value, this));

        internal void AddRight(T value) => SetRight(new Node<T>(value, this));

        #endregion

        #region Set Left/Right/Parent

        internal void SetLeft(Node<T> node) => Left = node;

        internal void SetRight(Node<T> node) => Right = node;

        internal void SetParent(Node<T> node) => Parent = node;

        #endregion

        #region Compare Values

        internal int CompareValue(Node<T> otherNode)
        {
            if (otherNode == null)
            {
                throw new ApplicationException("Comparable node cannot be null");
            }

            return CompareValue(otherNode.Value);
        }

        internal int CompareValue(T otherValue) => Value.CompareTo(otherValue);

        #endregion

        #region ToString

        public override string ToString() => Value.ToString();

        #endregion

        #region Equality

        public override bool Equals(object other)
        {
            if (other == null) return false;

            var otherNode = other as Node<T>;
            if (otherNode == null) return false;

            return CompareNodes(this, otherNode);
        }

        public override int GetHashCode() => base.GetHashCode(); // TODO: ??

        private bool CompareNodes(Node<T> node1, Node<T> node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }
            if (node1 == null && node2 != null || node1 != null && node2 == null)
            {
                return false;
            }
            if (node1.CompareValue(node2.Value) != 0)
            {
                return false;
            }

            return CompareNodes(node1.Left, node2.Left) && CompareNodes(node1.Right, node2.Right);
        }

        #endregion
    }

}
