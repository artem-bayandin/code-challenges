using System;
using TreeLibrary.Common;
using TreeLibrary.Tree;

namespace TreeLibrary.MarshalledTrees
{
    public class MarshalledBinarySearchTree<T> : BinarySearchTree<T>, IMarshalledTree where T : IComparable<T>
    {
        public string Delimiter { get; private set; }

        public MarshalledBinarySearchTree(string delimiter)
            : base()
        {
            SetDelimiter(delimiter);
        }

        public MarshalledBinarySearchTree(string delimiter, T value)
            : base(value)
        {
            SetDelimiter(delimiter);
            if (!ValueIsValidToBeAdded(value))
            {
                throw new ApplicationException("Value cannot contain Delimiter.");
            }
        }

        #region Marshal / Unmarshal

        public string Marshall()
        {
            if (Root == null)
            {
                return string.Empty;
            }

            return string.Join(Delimiter, TraversePreOrder());
        }

        public void Unmarshal(string data)
        {
            Root = null;

            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            if (data.Contains($"{Delimiter}{Delimiter}"))
            {
                return;
            }

            var converter = new TreeTypeConverter<T>(typeof(T));

            foreach (var item in data.Split(Delimiter))
            {
                if (string.IsNullOrEmpty(item) || !converter.TryParse(item, out T value))
                {
                    Root = null;
                    break;
                }
                else
                {
                    Add(value);
                }
            }
        }

        #endregion

        protected override bool ValueIsValidToBeAdded(T value)
        {
            if (value.ToString().Contains(Delimiter))
            {
                return false;
            }
            return true;
        }

        private void SetDelimiter(string delimiter)
        {
            if (string.IsNullOrEmpty(delimiter))
            {
                throw new ApplicationException("Delimiter cannot be empty.");
            }

            if (delimiter.Length != 1)
            {
                throw new ApplicationException("Delimiter must contain exact 1 char.");
            }

            Delimiter = delimiter;
        }
    }
}
