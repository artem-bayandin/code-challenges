using System;
using System.Collections.Generic;
using TreeLibrary.Tree;

namespace TreeLibrary.TraversalStrategies
{
    public class InOrderTraversal<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        public IEnumerable<T> Traverse(Node<T> node)
        {
            var stack = new Stack<Node<T>>();

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
    }
}
