using CrossCutting;
using System;
using TreeLibrary.MarshalledTrees;
using TreeLibrary.Tests.Constants;
using TreeLibrary.Tests.TestData;
using Xunit;

namespace TreeLibrary.Tests
{
    public class MBSTTests
    {
        [Theory]
        [ClassData(typeof(MarshalMbstData))]
        public void Given_MbstWithNodes_Marshals(string delimiter, int numberOfNodes)
        {
            if (numberOfNodes < 0) throw new ApplicationException("Number of nodes must be > 0");

            // arrange
            var tree = new MarshalledBinarySearchTree<int>(delimiter);
            var input = DataGenerator.RandomTreeData(numberOfNodes);
            tree.AddRange(input);

            // act
            var actual = tree.Marshall();

            // assert
            var expected = String.Join(delimiter, tree.TraversePreOrder());
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(UnmarshalMbstCorrectData))]
        public void Given_CorrectString_UnmashalsTree(MarshalledBinarySearchTree<int> tree, string str)
        {
            // arrange
            var unmarshalledTree = new MarshalledBinarySearchTree<int>(tree.Delimiter);

            // act
            unmarshalledTree.Unmarshal(str);

            // assert
            Assert.True(tree.Equals(unmarshalledTree));
        }

        [Theory]
        [MemberData(nameof(TestConstants.ObjectDelimiters), MemberType = typeof(TestConstants))]
        public void Given_EmptyString_UnmarshalsTree(string delimiter)
        {
            // arrange
            var expectedTree = new MarshalledBinarySearchTree<int>(delimiter);
            var unmarshalledTree = new MarshalledBinarySearchTree<int>(delimiter);

            // act
            unmarshalledTree.Unmarshal(String.Empty);

            // assert
            Assert.True(expectedTree.Equals(unmarshalledTree));
        }

        [Theory]
        [ClassData(typeof(UnmarshalMbstIncorrectData))]
        public void Given_IncorrectString_UnmarshalsIntoEmptyTree(string delimiter, string str)
        {
            // arrange
            var expectedTree = new MarshalledBinarySearchTree<int>(delimiter);
            var unmarshalledTree = new MarshalledBinarySearchTree<int>(delimiter);

            // act
            unmarshalledTree.Unmarshal(str);

            // assert
            Assert.True(expectedTree.Equals(unmarshalledTree));
        }
    }
}
