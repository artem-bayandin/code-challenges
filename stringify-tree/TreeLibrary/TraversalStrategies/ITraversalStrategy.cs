using System;
using System.Collections.Generic;
using TreeLibrary.Tree;

namespace TreeLibrary.TraversalStrategies
{
    public interface ITraversalStrategy<T> where T : IComparable<T>
    {
        IEnumerable<T> Traverse(Node<T> node);
    }
}
