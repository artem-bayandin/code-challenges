using System;
using System.Collections.Generic;
using TreeLibrary.Tree;

namespace TreeLibrary.TraversalStrategies
{
    public class PostOrderTraversal<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        public IEnumerable<T> Traverse(Node<T> node)
        {
            var stack = new Stack<Node<T>>();
            Node<T> lastNodeVisited = null;

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    var peekNode = stack.Peek();
                    if (peekNode.Right != null && lastNodeVisited != peekNode.Right)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        yield return peekNode.Value;
                        lastNodeVisited = stack.Pop();
                    }
                }
            }
        }
    }
}
