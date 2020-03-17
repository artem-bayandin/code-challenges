using CrossCutting;
using System.Collections;
using System.Collections.Generic;
using TreeLibrary.MarshalledTrees;
using TreeLibrary.Tests.Constants;

namespace TreeLibrary.Tests.TestData
{
    public class UnmarshalMbstCorrectData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var delimiter in TestConstants.Delimiters)
            {
                foreach (var amount in TestConstants.NumbersOfNodes)
                {
                    var tree = new MarshalledBinarySearchTree<int>(delimiter);
                    tree.AddRange(DataGenerator.RandomTreeData(amount));
                    yield return new object[] { tree, tree.Marshall() };
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
