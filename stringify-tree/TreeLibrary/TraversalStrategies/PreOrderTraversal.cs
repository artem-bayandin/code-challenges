using System;
using System.Collections.Generic;
using TreeLibrary.Tree;

namespace TreeLibrary.TraversalStrategies
{
    public class PreOrderTraversal<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        public IEnumerable<T> Traverse(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            var stack = new Stack<Node<T>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                node = stack.Pop();

                yield return node.Value;

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }
    }
}
