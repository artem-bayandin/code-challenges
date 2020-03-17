using CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TreeLibrary.MarshalledTrees;
using TreeLibrary.Tests.Constants;

namespace TreeLibrary.Tests.TestData
{
    public class UnmarshalMbstIncorrectData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var delimiter in TestConstants.Delimiters)
            {
                foreach (var amount in TestConstants.NumbersOfNodes)
                {
                    var tree = new MarshalledBinarySearchTree<int>(delimiter);
                    var dataItems = DataGenerator.RandomTreeData(amount);
                    tree.AddRange(dataItems);
                    var str = tree.Marshall();
                    if (string.IsNullOrEmpty(str))
                    {
                        yield return new object[] {
                            delimiter, 
                            "abc"
                        };
                    }
                    else
                    {
                        // replace int with string
                        var itemToReplace = dataItems.Where(x => !x.ToString().Contains(delimiter)).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                        yield return new object[] {
                            delimiter,
                            str.Replace(itemToReplace.ToString(), "abc")
                        };

                        // replace int with delimiter
                        yield return new object[] { 
                            delimiter,
                            str.Replace(itemToReplace.ToString(), delimiter)
                        };
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
