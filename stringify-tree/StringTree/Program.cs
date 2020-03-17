using System;
using static System.Console;

namespace TreePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in new string[]
            {
                " # # # # ",
                " Welcome ",
                " Here you may play with BinarySearchTree first and then with Marshaled BinarySearchTree.",
                " First menu shown - for standard BST.",
                " When you exit from BST, the second menu will be show - MBST.",
                " Hope you'll like it.",
                " Enjoy !",
                " # # # # ",
                ""
            })
            {
                WriteLine(line);
            }

            try
            {
                SimulatorBST.Play();
                SimulatorMarshalledBST.Play();
            }
            catch (Exception e)
            {
                WriteLine("Urgh, uncaught exception happened... Please contact your system administrator, haha.");
                WriteLine($"Exception message: {e.Message}");
                WriteLine($"Stack trace: {e.StackTrace}");
            }

            WriteLine("FIN");
            ReadLine();
        }
    }
}
