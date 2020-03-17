using System.Linq;
using TreeLibrary.Common;
using TreeLibrary.MarshalledTrees;
using static System.Console;

namespace TreePlayer
{
    public static class SimulatorMarshalledBST
    {
        public static void Play()
        {
            // create tree
            var tree = new MarshalledBinarySearchTree<int>("_");
            WriteLine(" # # # # ");
            WriteLine(" Marshaled BinarySearchTree created. Delimiter used: '_'");
            WriteLine(" # # # # ");


            var converter = new TreeTypeConverter<int>(typeof(int)); // input type should be the same as tree has
            ShowMenuMarshaled(tree, converter);


            static void ShowMenuMarshaled(MarshalledBinarySearchTree<int> tree, TreeTypeConverter<int> converter)
            {
                WriteLine();
                WriteLine("Marshaled Menu:");
                WriteLine("0           : Create new");
                WriteLine("1           : Add value");
                WriteLine("2           : Remove value");
                WriteLine("3           : Traverse: Pre-Order");
                WriteLine("4           : Traverse: In-Order");
                WriteLine("5           : Traverse: Post-Order");
                WriteLine("6           : Fill: FullTreeData");
                WriteLine("7           : Fill: RandomTreeData");
                WriteLine("8           : Marshal");
                WriteLine("9           : Unmarshal");
                WriteLine("<any other> : Exit from MBST");

                var read = ReadLine();
                int value = default;
                string delimiter = string.Empty;
                bool exit = false;
                switch (read)
                {
                    case "0":
                        WriteLine("Enter value of a Delimiter, used for Marshaling:");
                        delimiter = ReadLine();
                        if (string.IsNullOrEmpty(delimiter) || delimiter.Length != 1)
                        {
                            WriteLine("Delimiter must contain exact 1 char, tree will not be created");
                            break;
                        }
                        WriteLine("Enter value of a future Root node or press Enter to create without Root:");
                        read = ReadLine();
                        if (delimiter == read)
                        {
                            WriteLine("Unable to create a tree with Delimiter equal to Root value");
                            break;
                        }
                        if (string.IsNullOrEmpty(read))
                        {
                            tree = new MarshalledBinarySearchTree<int>(delimiter);
                            WriteLine("Tree was created");
                            break;
                        }
                        if (!converter.TryParse(read, out value))
                        {
                            WriteLine("Unable to convert input value, tree will not be created");
                            break;
                        }
                        else
                        {
                            tree = new MarshalledBinarySearchTree<int>(delimiter, value);
                            break;
                        }
                    case "1":
                        WriteLine("Enter value to add:");
                        read = ReadLine();
                        if (!converter.TryParse(read, out value))
                        {
                            WriteLine("Unable to convert input value");
                            break;
                        }
                        tree.Add(value);
                        break;
                    case "2":
                        WriteLine("Enter value to remove:");
                        read = ReadLine();
                        if (!converter.TryParse(read, out value))
                        {
                            WriteLine("Unable to convert input value");
                            break;
                        }
                        tree.Remove(value);
                        break;
                    case "3":
                        WriteLine(string.Join(" | ", tree.TraversePreOrder()));
                        break;
                    case "4":
                        WriteLine(string.Join(" | ", tree.TraverseInOrder()));
                        break;
                    case "5":
                        WriteLine(string.Join(" | ", tree.TraversePostOrder()));
                        break;
                    case "6":
                        WriteLine("Enter value of a Delimiter, used for Marshaling:");
                        delimiter = ReadLine();
                        if (string.IsNullOrEmpty(delimiter) || delimiter.Length != 1)
                        {
                            WriteLine("Delimiter must contain exact 1 char, tree will not be created");
                            break;
                        }
                        tree = new MarshalledBinarySearchTree<int>(delimiter);
                        var data1 = DataGenerator.FullTreeData().ToList();
                        if (data1.Any(item => item.ToString().Contains(delimiter)))
                        {
                            WriteLine("Data to be added contains value(s) that include Delimiter, not all nodes will be created");
                            data1 = data1.Where(item => !item.ToString().Contains(delimiter)).ToList();
                        }
                        tree.AddRange(data1);
                        break;
                    case "7":
                        WriteLine("Enter value of a Delimiter, used for Marshaling:");
                        delimiter = ReadLine();
                        if (string.IsNullOrEmpty(delimiter) || delimiter.Length != 1)
                        {
                            WriteLine("Delimiter must contain exact 1 char, tree will not be created");
                            break;
                        }
                        WriteLine($"Enter number of nodes, max is {DataGenerator.MaxRandomItemsCount} :");
                        read = ReadLine();
                        if (!int.TryParse(read, out int numberOfRoots))
                        {
                            WriteLine("Unable to convert input value");
                            break;
                        }
                        if (numberOfRoots < 1)
                        {
                            WriteLine("Number of nodes must be greater than 0");
                            break;
                        }
                        tree = new MarshalledBinarySearchTree<int>(delimiter);
                        var data2 = DataGenerator.RandomTreeData(numberOfRoots).ToList();
                        if (data2.Any(item => item.ToString().Contains(delimiter)))
                        {
                            WriteLine("Data to be added contains value(s) that include Delimiter, not all nodes will be created");
                            data2 = data2.Where(item => !item.ToString().Contains(delimiter)).ToList();
                        }
                        tree.AddRange(data2);
                        break;
                    case "8":
                        WriteLine("Marshaled tree:");
                        WriteLine(tree.Marshall());
                        break;
                    case "9":
                        WriteLine("Enter string to unmarshal:");
                        var unmarshalInput = ReadLine();
                        tree.Unmarshal(unmarshalInput);
                        WriteLine("Tree loaded");
                        break;
                    default:
                        exit = true;
                        break;
                }

                if (exit)
                {
                    return;
                }

                ShowMenuMarshaled(tree, converter);
            }
        }
    }
}
