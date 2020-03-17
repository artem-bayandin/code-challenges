using TreeLibrary.Common;
using TreeLibrary.Tree;
using static System.Console;

namespace TreePlayer
{
    public static class SimulatorBST
    {
        public static void Play()
        {
            // create tree
            var tree = new BinarySearchTree<int>();
            WriteLine(" # # # # ");
            WriteLine(" BinarySearchTree created");
            WriteLine(" # # # # ");


            var converter = new TreeTypeConverter<int>(typeof(int)); // input type should be the same as tree has
            ShowMenuBST(tree, converter);


            static void ShowMenuBST(BinarySearchTree<int> tree, TreeTypeConverter<int> converter)
            {
                WriteLine();
                WriteLine("BST Menu:");
                WriteLine("0           : Create new");
                WriteLine("1           : Add value");
                WriteLine("2           : Remove value");
                WriteLine("3           : Traverse: Pre-Order");
                WriteLine("4           : Traverse: In-Order");
                WriteLine("5           : Traverse: Post-Order");
                WriteLine("6           : Fill: FullTreeData");
                WriteLine("7           : Fill: RandomTreeData");
                WriteLine("<any other> : Exit from BST");

                var read = ReadLine();
                int value = default;
                bool exit = false;
                switch (read)
                {
                    case "0":
                        WriteLine("Enter value of a future Root node or press Enter to create without Root:");
                        read = ReadLine();
                        if (string.IsNullOrEmpty(read))
                        {
                            tree = new BinarySearchTree<int>();
                            WriteLine("Tree created");
                            break;
                        }
                        if (!converter.TryParse(read, out value))
                        {
                            WriteLine("Unable to convert input value. Tree will not be created");
                            break;
                        }
                        else
                        {
                            tree = new BinarySearchTree<int>(value);
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
                        tree = new BinarySearchTree<int>();
                        tree.AddRange(DataGenerator.FullTreeData());
                        break;
                    case "7":
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
                        tree = new BinarySearchTree<int>();
                        tree.AddRange(DataGenerator.RandomTreeData(numberOfRoots));
                        break;
                    default:
                        exit = true;
                        break;
                }

                if (exit)
                {
                    return;
                }

                ShowMenuBST(tree, converter);
            }
        }
    }
}
